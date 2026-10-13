using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace IslandCounter
{
    public class CoinInfo
    {
        public int Id { get; set; }
        public int Area { get; set; }
        public Rectangle BoundingBox { get; set; }
        public PointF Centroid { get; set; }
        public string Denomination { get; set; } = "";
        public double UnitValue { get; set; }
        public Color CategoryColor { get; set; }
        public int GroupIndex { get; set; }
        public List<Point> Pixels { get; set; } = new List<Point>();
    }

    public class CoinGroupSummary
    {
        public int GroupIndex { get; set; }
        public string Denomination { get; set; } = "";
        public double UnitValue { get; set; }
        public Color DisplayColor { get; set; }
        public int Count => Coins.Count;
        public double AverageArea => Coins.Count > 0 ? Coins.Average(c => c.Area) : 0;
        public double TotalValue => Count * UnitValue;
        public List<CoinInfo> Coins { get; set; } = new List<CoinInfo>();
    }

    public class CoinDetectionResult
    {
        public Bitmap ProcessedImage { get; set; } = null!;
        public Color BackgroundColor { get; set; }
        public List<CoinInfo> Coins { get; set; } = new List<CoinInfo>();
        public List<CoinGroupSummary> Groups { get; set; } = new List<CoinGroupSummary>();
        public int TotalCoins => Coins.Count;
        public double TotalValue => Groups.Sum(g => g.TotalValue);
        public TimeSpan ElapsedTime { get; set; }
    }

    public static class CoinDetector
    {
        public static readonly string[] DefaultCoinNames = { "5 Cent", "10 Cent", "25 Cent", "1 Peso", "5 Peso" };
        public static readonly double[] DefaultCoinValues = { 0.05, 0.10, 0.25, 1.00, 5.00 };
        public static readonly Color[] DefaultGroupColors = {
            Color.FromArgb(245, 158, 11),   // 5 Cent: Amber / Orange
            Color.FromArgb(6, 182, 212),    // 10 Cent: Cyan
            Color.FromArgb(139, 92, 246),   // 25 Cent: Purple
            Color.FromArgb(37, 99, 235),    // 1 Peso: Royal Blue
            Color.FromArgb(16, 185, 129)    // 5 Peso: Emerald Green
        };

        /// <summary>
        /// Analyzes a bitmap image to find coins using BFS flood fill and groups them into denominations.
        /// </summary>
        public static CoinDetectionResult AnalyzeImage(Bitmap sourceBitmap, int minCoinArea = 1000, int numGroups = 5)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            int width = sourceBitmap.Width;
            int height = sourceBitmap.Height;

            Color bgColor = sourceBitmap.GetPixel(0, 0);

            // Fast pixel extraction using LockBits
            BitmapData data = sourceBitmap.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            int stride = data.Stride;
            byte[] rawBytes = new byte[Math.Abs(stride) * height];
            Marshal.Copy(data.Scan0, rawBytes, 0, rawBytes.Length);
            sourceBitmap.UnlockBits(data);

            byte bgB = rawBytes[0];
            byte bgG = rawBytes[1];
            byte bgR = rawBytes[2];

            bool[,] isCoin = new bool[width, height];
            for (int y = 0; y < height; y++)
            {
                int rowOffset = y * stride;
                for (int x = 0; x < width; x++)
                {
                    int offset = rowOffset + x * 4;
                    byte b = rawBytes[offset];
                    byte g = rawBytes[offset + 1];
                    byte r = rawBytes[offset + 2];

                    // Coin pixel if it differs from background
                    isCoin[x, y] = (Math.Abs(r - bgR) > 20 || Math.Abs(g - bgG) > 20 || Math.Abs(b - bgB) > 20);
                }
            }

            bool[,] visited = new bool[width, height];
            List<CoinInfo> rawCoins = new List<CoinInfo>();

            int[] dx = { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] dy = { 0, 0, -1, 1, -1, 1, -1, 1 };

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (visited[x, y] || !isCoin[x, y]) continue;

                    // BFS Flood Fill
                    int area = 0;
                    int minX = x, maxX = x;
                    int minY = y, maxY = y;
                    long sumX = 0, sumY = 0;
                    List<Point> islandPixels = new List<Point>();
                    Queue<Point> queue = new Queue<Point>();

                    visited[x, y] = true;
                    queue.Enqueue(new Point(x, y));

                    while (queue.Count > 0)
                    {
                        Point curr = queue.Dequeue();
                        area++;
                        sumX += curr.X;
                        sumY += curr.Y;
                        islandPixels.Add(curr);

                        if (curr.X < minX) minX = curr.X;
                        if (curr.X > maxX) maxX = curr.X;
                        if (curr.Y < minY) minY = curr.Y;
                        if (curr.Y > maxY) maxY = curr.Y;

                        for (int i = 0; i < 8; i++)
                        {
                            int nx = curr.X + dx[i];
                            int ny = curr.Y + dy[i];

                            if (nx >= 0 && nx < width && ny >= 0 && ny < height && !visited[nx, ny] && isCoin[nx, ny])
                            {
                                visited[nx, ny] = true;
                                queue.Enqueue(new Point(nx, ny));
                            }
                        }
                    }

                    if (area >= minCoinArea)
                    {
                        rawCoins.Add(new CoinInfo
                        {
                            Area = area,
                            BoundingBox = new Rectangle(minX, minY, Math.Max(1, maxX - minX + 1), Math.Max(1, maxY - minY + 1)),
                            Centroid = new PointF((float)sumX / area, (float)sumY / area),
                            Pixels = islandPixels
                        });
                    }
                }
            }

            // Sort coins by area ascending
            var sortedCoins = rawCoins.OrderBy(c => c.Area).ToList();
            List<CoinGroupSummary> groupSummaries = new List<CoinGroupSummary>();

            if (sortedCoins.Count > 0)
            {
                int k = Math.Min(numGroups, sortedCoins.Count);
                if (k <= 1 || sortedCoins.Count < k)
                {
                    var singleGroup = new CoinGroupSummary
                    {
                        GroupIndex = 0,
                        Denomination = DefaultCoinNames[0],
                        UnitValue = DefaultCoinValues[0],
                        DisplayColor = DefaultGroupColors[0],
                        Coins = sortedCoins
                    };
                    foreach (var c in sortedCoins)
                    {
                        c.Denomination = singleGroup.Denomination;
                        c.UnitValue = singleGroup.UnitValue;
                        c.CategoryColor = singleGroup.DisplayColor;
                        c.GroupIndex = 0;
                    }
                    groupSummaries.Add(singleGroup);
                }
                else
                {
                    // Find largest gaps
                    var gaps = new List<(int gapSize, int splitIndex)>();
                    for (int i = 1; i < sortedCoins.Count; i++)
                    {
                        gaps.Add((sortedCoins[i].Area - sortedCoins[i - 1].Area, i));
                    }

                    var splitIndices = gaps.OrderByDescending(g => g.gapSize)
                                           .Take(k - 1)
                                           .Select(g => g.splitIndex)
                                           .OrderBy(idx => idx)
                                           .ToList();

                    int startIndex = 0;
                    for (int gi = 0; gi < k; gi++)
                    {
                        int endIndex = (gi < splitIndices.Count) ? splitIndices[gi] : sortedCoins.Count;
                        var groupCoins = sortedCoins.GetRange(startIndex, endIndex - startIndex);
                        startIndex = endIndex;

                        string name = gi < DefaultCoinNames.Length ? DefaultCoinNames[gi] : $"Group {gi + 1}";
                        double val = gi < DefaultCoinValues.Length ? DefaultCoinValues[gi] : 0.0;
                        Color col = gi < DefaultGroupColors.Length ? DefaultGroupColors[gi] : Color.Gray;

                        var group = new CoinGroupSummary
                        {
                            GroupIndex = gi,
                            Denomination = name,
                            UnitValue = val,
                            DisplayColor = col,
                            Coins = groupCoins
                        };

                        foreach (var c in groupCoins)
                        {
                            c.Denomination = name;
                            c.UnitValue = val;
                            c.CategoryColor = col;
                            c.GroupIndex = gi;
                        }

                        groupSummaries.Add(group);
                    }
                }
            }

            // Assign unique 1-based IDs to coins for UI display (ordered by centroid or area)
            for (int i = 0; i < sortedCoins.Count; i++)
            {
                sortedCoins[i].Id = i + 1;
            }

            stopwatch.Stop();

            return new CoinDetectionResult
            {
                ProcessedImage = (Bitmap)sourceBitmap.Clone(),
                BackgroundColor = bgColor,
                Coins = sortedCoins,
                Groups = groupSummaries,
                ElapsedTime = stopwatch.Elapsed
            };
        }

        /// <summary>
        /// Flattens a colorful or noisy coin image into pure blue coins on white background.
        /// </summary>
        public static Bitmap ReduceColorToBlue(Bitmap inputBitmap, int threshold = 150)
        {
            int width = inputBitmap.Width;
            int height = inputBitmap.Height;

            Bitmap result = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            // Read source pixels
            BitmapData srcData = inputBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int srcStride = srcData.Stride;
            byte[] srcBytes = new byte[Math.Abs(srcStride) * height];
            Marshal.Copy(srcData.Scan0, srcBytes, 0, srcBytes.Length);
            inputBitmap.UnlockBits(srcData);

            Color[,] pixels = new Color[width, height];
            for (int y = 0; y < height; y++)
            {
                int rowOffset = y * srcStride;
                for (int x = 0; x < width; x++)
                {
                    int offset = rowOffset + x * 4;
                    byte b = srcBytes[offset];
                    byte g = srcBytes[offset + 1];
                    byte r = srcBytes[offset + 2];

                    int brightness = (int)(r * 0.299 + g * 0.587 + b * 0.114);
                    pixels[x, y] = brightness > threshold ? Color.White : Color.Blue;
                }
            }

            // Dilation pass to fill tiny reflection holes inside coins
            Color[,] dilated = new Color[width, height];
            int[] dx = { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] dy = { 0, 0, -1, 1, -1, 1, -1, 1 };

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color current = pixels[x, y];
                    dilated[x, y] = current;

                    if (current == Color.White)
                    {
                        bool adjacentToBlue = false;
                        for (int i = 0; i < 8; i++)
                        {
                            int nx = x + dx[i];
                            int ny = y + dy[i];
                            if (nx >= 0 && nx < width && ny >= 0 && ny < height)
                            {
                                if (pixels[nx, ny] == Color.Blue)
                                {
                                    adjacentToBlue = true;
                                    break;
                                }
                            }
                        }
                        if (adjacentToBlue)
                        {
                            dilated[x, y] = Color.Blue;
                        }
                    }
                }
            }

            // Write to result bitmap
            BitmapData dstData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            int dstStride = dstData.Stride;
            byte[] dstBytes = new byte[Math.Abs(dstStride) * height];

            for (int y = 0; y < height; y++)
            {
                int rowOffset = y * dstStride;
                for (int x = 0; x < width; x++)
                {
                    int offset = rowOffset + x * 4;
                    Color col = dilated[x, y];
                    dstBytes[offset] = col.B;
                    dstBytes[offset + 1] = col.G;
                    dstBytes[offset + 2] = col.R;
                    dstBytes[offset + 3] = 255;
                }
            }

            Marshal.Copy(dstBytes, 0, dstData.Scan0, dstBytes.Length);
            result.UnlockBits(dstData);

            return result;
        }

        /// <summary>
        /// Renders visual overlays (bounding circles, centroid dots, denomination labels) on top of an image.
        /// </summary>
        public static Bitmap RenderAnnotatedImage(
            Bitmap baseImage,
            List<CoinInfo> coins,
            bool showBounding,
            bool showCentroids,
            bool showLabels,
            bool showNumbers,
            int? selectedCoinId = null)
        {
            Bitmap annotated = new Bitmap(baseImage.Width, baseImage.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(annotated))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Draw base image
                g.DrawImage(baseImage, 0, 0, baseImage.Width, baseImage.Height);

                using Font fontLabel = new Font("Segoe UI", 9f, FontStyle.Bold);
                using Font fontNum = new Font("Segoe UI", 7.5f, FontStyle.Bold);
                using Brush shadowBrush = new SolidBrush(Color.FromArgb(180, 0, 0, 0));
                using Brush textWhiteBrush = new SolidBrush(Color.White);

                foreach (var coin in coins)
                {
                    bool isSelected = selectedCoinId.HasValue && coin.Id == selectedCoinId.Value;
                    Color strokeColor = isSelected ? Color.Yellow : coin.CategoryColor;
                    float penWidth = isSelected ? 4f : 2.5f;

                    // 1. Draw Bounding Shape (Circle enclosing coin or Bounding Box)
                    if (showBounding || isSelected)
                    {
                        Rectangle box = coin.BoundingBox;
                        // Calculate enclosing circle
                        float radius = (float)Math.Sqrt(coin.Area / Math.PI) + 4f;
                        float cx = coin.Centroid.X;
                        float cy = coin.Centroid.Y;

                        using (Pen pen = new Pen(strokeColor, penWidth))
                        {
                            g.DrawEllipse(pen, cx - radius, cy - radius, radius * 2, radius * 2);
                        }

                        if (isSelected)
                        {
                            using (Brush fillBrush = new SolidBrush(Color.FromArgb(40, 255, 255, 0)))
                            {
                                g.FillEllipse(fillBrush, cx - radius, cy - radius, radius * 2, radius * 2);
                            }
                        }
                    }

                    // 2. Draw Centroid dot
                    if (showCentroids || isSelected)
                    {
                        float dotRadius = isSelected ? 5f : 3.5f;
                        using (Brush dotBrush = new SolidBrush(Color.White))
                        using (Pen dotPen = new Pen(strokeColor, 1.5f))
                        {
                            g.FillEllipse(dotBrush, coin.Centroid.X - dotRadius, coin.Centroid.Y - dotRadius, dotRadius * 2, dotRadius * 2);
                            g.DrawEllipse(dotPen, coin.Centroid.X - dotRadius, coin.Centroid.Y - dotRadius, dotRadius * 2, dotRadius * 2);
                        }
                    }

                    // 3. Draw Denomination Badge
                    if (showLabels)
                    {
                        string badgeText = FormatShortDenomination(coin.Denomination);
                        if (showNumbers)
                        {
                            badgeText = $"#{coin.Id} {badgeText}";
                        }

                        SizeF textSize = g.MeasureString(badgeText, fontLabel);
                        float badgeW = textSize.Width + 8;
                        float badgeH = textSize.Height + 2;
                        float badgeX = coin.Centroid.X - (badgeW / 2);
                        float badgeY = coin.BoundingBox.Top - badgeH - 3;

                        // Ensure badge stays within image boundary
                        if (badgeY < 2) badgeY = coin.Centroid.Y - (badgeH / 2);
                        if (badgeX < 2) badgeX = 2;
                        if (badgeX + badgeW > baseImage.Width - 2) badgeX = baseImage.Width - badgeW - 2;

                        RectangleF badgeRect = new RectangleF(badgeX, badgeY, badgeW, badgeH);

                        // Pill background with category color
                        using (Brush badgeBg = new SolidBrush(coin.CategoryColor))
                        using (Pen borderPen = new Pen(Color.White, 1.2f))
                        {
                            g.FillRectangle(badgeBg, badgeRect);
                            g.DrawRectangle(borderPen, badgeRect.X, badgeRect.Y, badgeRect.Width, badgeRect.Height);
                        }

                        // Text inside badge
                        using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        {
                            g.DrawString(badgeText, fontLabel, textWhiteBrush, badgeRect, sf);
                        }
                    }
                    else if (showNumbers)
                    {
                        // Just coin number badge
                        string numText = $"#{coin.Id}";
                        SizeF textSize = g.MeasureString(numText, fontNum);
                        float badgeW = textSize.Width + 6;
                        float badgeH = textSize.Height + 2;
                        float badgeX = coin.Centroid.X - (badgeW / 2);
                        float badgeY = coin.Centroid.Y - (badgeH / 2);

                        RectangleF badgeRect = new RectangleF(badgeX, badgeY, badgeW, badgeH);
                        using (Brush badgeBg = new SolidBrush(Color.FromArgb(200, 15, 23, 42)))
                        using (Pen borderPen = new Pen(coin.CategoryColor, 1.2f))
                        {
                            g.FillRectangle(badgeBg, badgeRect);
                            g.DrawRectangle(borderPen, badgeRect.X, badgeRect.Y, badgeRect.Width, badgeRect.Height);
                        }
                        using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        {
                            g.DrawString(numText, fontNum, textWhiteBrush, badgeRect, sf);
                        }
                    }
                }
            }

            return annotated;
        }

        private static string FormatShortDenomination(string denom)
        {
            return denom switch
            {
                "5 Cent" => "5¢",
                "10 Cent" => "10¢",
                "25 Cent" => "25¢",
                "1 Peso" => "₱1",
                "5 Peso" => "₱5",
                _ => denom
            };
        }
    }
}
