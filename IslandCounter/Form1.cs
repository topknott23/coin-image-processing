using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IslandCounter
{
    public partial class Form1 : Form
    {
        private Bitmap? _rawBitmap;
        private Bitmap? _flattenedBitmap;
        private Bitmap? _annotatedBitmap;
        private CoinDetectionResult? _lastResult;
        private CoinInfo? _selectedCoin;
        private string? _currentImagePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbViewMode.SelectedIndex = 0; // Default to Annotated Overlay

            // Automatically load and analyze flattened blue coin image
            string defaultFlattened = ResolvePath("coins_flattened.png");
            if (File.Exists(defaultFlattened))
            {
                LoadImage(defaultFlattened, isFlattened: true);
                AnalyzeCurrent();
            }
            else
            {
                string defaultRaw = ResolvePath("coins.jpeg");
                if (File.Exists(defaultRaw))
                {
                    LoadImage(defaultRaw, isFlattened: false);
                    AnalyzeCurrent();
                }
                else
                {
                    statusLabel.Text = "Error: 'coins_flattened.png' not found.";
                }
            }
        }

        private void BtnAnalyze_Click(object sender, EventArgs e)
        {
            AnalyzeCurrent();
        }

        private void LoadImage(string filePath, bool? isFlattened = null)
        {
            try
            {
                _currentImagePath = filePath;

                // Load image into memory so file is not locked
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var temp = Image.FromStream(fs))
                {
                    Bitmap bmp = new Bitmap(temp);

                    bool looksFlattened = isFlattened ?? filePath.Contains("flattened", StringComparison.OrdinalIgnoreCase);
                    if (looksFlattened)
                    {
                        _flattenedBitmap?.Dispose();
                        _flattenedBitmap = bmp;
                    }
                    else
                    {
                        _rawBitmap?.Dispose();
                        _rawBitmap = bmp;
                        // Also automatically create flattened version if not present
                        _flattenedBitmap?.Dispose();
                        _flattenedBitmap = CoinDetector.ReduceColorToBlue(bmp);
                    }
                }

                lblImageInfo.Text = $"{Path.GetFileName(filePath)} ({_flattenedBitmap?.Width ?? 0} × {_flattenedBitmap?.Height ?? 0} px)";
                statusLabel.Text = $"Loaded '{Path.GetFileName(filePath)}'";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnalyzeCurrent()
        {
            Bitmap? working = _flattenedBitmap ?? _rawBitmap;
            if (working == null)
            {
                MessageBox.Show("Please load an image first.", "No Image Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            statusLabel.Text = "Running Breadth-First Search (BFS) island detection...";
            Application.DoEvents();

            try
            {
                int minArea = (int)this.numMinArea.Value;
                int groupsCount = (int)this.numGroups.Value;

                _lastResult = CoinDetector.AnalyzeImage(working, minArea, groupsCount);
                _selectedCoin = null;

                UpdateSummaryDashboard(_lastResult);
                PopulateBreakdownGrid(_lastResult);
                RefreshDisplayImage();

                statusLabel.Text = $"Analysis complete! Found {_lastResult.TotalCoins} coins in {_lastResult.ElapsedTime.TotalMilliseconds:F0} ms.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during coin analysis: {ex.Message}", "Analysis Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Analysis failed.";
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void UpdateSummaryDashboard(CoinDetectionResult res)
        {
            lblSummaryCoins.Text = $"{res.TotalCoins} Total Coins";
            lblSummaryValue.Text = $"₱{res.TotalValue:F2} Total";
            lblSummaryTime.Text = $"BFS Runtime: ~{res.ElapsedTime.TotalMilliseconds:F0} ms";
            lblSummaryBaseColor.Text = $"Background: RGB({res.BackgroundColor.R}, {res.BackgroundColor.G}, {res.BackgroundColor.B})";
        }

        private void PopulateBreakdownGrid(CoinDetectionResult res)
        {
            dgvGroups.Rows.Clear();

            foreach (var g in res.Groups)
            {
                int rowIndex = dgvGroups.Rows.Add(
                    "", // Color pill rendered in CellPainting
                    g.Denomination,
                    g.Count,
                    $"~{g.AverageArea:F0} px",
                    $"₱{g.UnitValue:F2}",
                    $"₱{g.TotalValue:F2}"
                );
                dgvGroups.Rows[rowIndex].Tag = g;
            }

            dgvGroups.ClearSelection();
        }

        private void RefreshDisplayImage()
        {
            if (_lastResult == null || _flattenedBitmap == null)
            {
                picPreview.Image = _flattenedBitmap ?? _rawBitmap;
                return;
            }

            int mode = cmbViewMode.SelectedIndex;
            if (mode == 1) // Clean Flattened
            {
                picPreview.Image = _flattenedBitmap;
                return;
            }
            if (mode == 2 && _rawBitmap != null) // Raw
            {
                picPreview.Image = _rawBitmap;
                return;
            }

            // Mode 0: Annotated
            _annotatedBitmap?.Dispose();
            _annotatedBitmap = CoinDetector.RenderAnnotatedImage(
                _flattenedBitmap,
                _lastResult.Coins,
                showBounding: chkShowBounding.Checked,
                showCentroids: chkShowCentroids.Checked,
                showLabels: chkShowLabels.Checked,
                showNumbers: chkShowNumbers.Checked,
                selectedCoinId: _selectedCoin?.Id
            );

            picPreview.Image = _annotatedBitmap;
        }

        private void OverlaySetting_Changed(object sender, EventArgs e)
        {
            if (cmbViewMode.SelectedIndex != 0)
            {
                cmbViewMode.SelectedIndex = 0; // Switch to annotated view
            }
            else
            {
                RefreshDisplayImage();
            }
        }

        private void CmbViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDisplayImage();
        }

        private void DgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count > 0)
            {
                var selectedGroup = dgvGroups.SelectedRows[0]?.Tag as CoinGroupSummary;
                if (selectedGroup != null)
                {
                    statusHoverInfo.Text = $"Group: {selectedGroup.Denomination} ({selectedGroup.Count} coins, Avg Area: ~{selectedGroup.AverageArea:F0} px)";
                }
            }
        }

        private void DgvGroups_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Graphics == null) return;
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // colColor
            {
                e.PaintBackground(e.ClipBounds, true);
                var group = dgvGroups.Rows[e.RowIndex].Tag as CoinGroupSummary;
                if (group != null)
                {
                    int pad = 5;
                    Rectangle circleRect = new Rectangle(e.CellBounds.X + pad, e.CellBounds.Y + pad, e.CellBounds.Height - (pad * 2), e.CellBounds.Height - (pad * 2));
                    using (Brush b = new SolidBrush(group.DisplayColor))
                    using (Pen p = new Pen(Color.FromArgb(100, 0, 0, 0), 1))
                    {
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        e.Graphics.FillEllipse(b, circleRect);
                        e.Graphics.DrawEllipse(p, circleRect);
                    }
                }
                e.Handled = true;
            }
        }

        private void PicPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (_lastResult == null || picPreview.Image == null) return;

            Point? imgPoint = TranslatePictureToImageCoord(e.Location);
            if (!imgPoint.HasValue)
            {
                statusHoverInfo.Text = "";
                return;
            }

            int ix = imgPoint.Value.X;
            int iy = imgPoint.Value.Y;

            // Find coin under mouse
            CoinInfo? hovered = FindCoinAt(ix, iy);
            if (hovered != null)
            {
                statusHoverInfo.Text = $"Coin #{hovered.Id}: {hovered.Denomination} | Value: ₱{hovered.UnitValue:F2} | Area: {hovered.Area:N0} px | Pos: ({ix}, {iy})";
                toolTip1.SetToolTip(picPreview, $"Coin #{hovered.Id}\nDenomination: {hovered.Denomination}\nValue: ₱{hovered.UnitValue:F2}\nArea: {hovered.Area:N0} px");
            }
            else
            {
                statusHoverInfo.Text = $"Cursor: ({ix}, {iy})";
                toolTip1.SetToolTip(picPreview, null);
            }
        }

        private void PicPreview_MouseClick(object sender, MouseEventArgs e)
        {
            if (_lastResult == null || picPreview.Image == null) return;

            Point? imgPoint = TranslatePictureToImageCoord(e.Location);
            if (!imgPoint.HasValue) return;

            CoinInfo? clicked = FindCoinAt(imgPoint.Value.X, imgPoint.Value.Y);
            if (clicked != null)
            {
                _selectedCoin = clicked;

                // Select corresponding group row in grid
                foreach (DataGridViewRow row in dgvGroups.Rows)
                {
                    if (row.Tag is CoinGroupSummary g && g.GroupIndex == clicked.GroupIndex)
                    {
                        row.Selected = true;
                        break;
                    }
                }

                statusLabel.Text = $"Selected Coin #{clicked.Id} ({clicked.Denomination}, Area: {clicked.Area} px)";
                RefreshDisplayImage();
            }
            else if (_selectedCoin != null)
            {
                _selectedCoin = null;
                dgvGroups.ClearSelection();
                RefreshDisplayImage();
            }
        }

        private CoinInfo? FindCoinAt(int x, int y)
        {
            if (_lastResult == null) return null;

            // Check if inside bounding box or radius
            foreach (var coin in _lastResult.Coins)
            {
                float dx = x - coin.Centroid.X;
                float dy = y - coin.Centroid.Y;
                float distSq = dx * dx + dy * dy;
                float radius = (float)Math.Sqrt(coin.Area / Math.PI) + 4f;

                if (distSq <= radius * radius || coin.BoundingBox.Contains(x, y))
                {
                    return coin;
                }
            }
            return null;
        }

        private Point? TranslatePictureToImageCoord(Point p)
        {
            if (picPreview.Image == null) return null;

            int imgW = picPreview.Image.Width;
            int imgH = picPreview.Image.Height;
            int boxW = picPreview.ClientSize.Width;
            int boxH = picPreview.ClientSize.Height;

            if (boxW <= 0 || boxH <= 0) return null;

            float ratioImg = (float)imgW / imgH;
            float ratioBox = (float)boxW / boxH;

            int renderedW, renderedH;
            int offsetX = 0, offsetY = 0;

            if (ratioImg > ratioBox)
            {
                renderedW = boxW;
                renderedH = (int)(boxW / ratioImg);
                offsetY = (boxH - renderedH) / 2;
            }
            else
            {
                renderedH = boxH;
                renderedW = (int)(boxH * ratioImg);
                offsetX = (boxW - renderedW) / 2;
            }

            if (p.X < offsetX || p.X > offsetX + renderedW || p.Y < offsetY || p.Y > offsetY + renderedH)
            {
                return null;
            }

            int imgX = (int)((p.X - offsetX) * (float)imgW / renderedW);
            int imgY = (int)((p.Y - offsetY) * (float)imgH / renderedH);

            if (imgX < 0 || imgX >= imgW || imgY < 0 || imgY >= imgH) return null;

            return new Point(imgX, imgY);
        }

        private static string ResolvePath(string filename)
        {
            string[] searchPaths = {
                filename,
                Path.Combine("..", filename),
                Path.Combine("..", "..", filename),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", filename),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", filename),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", filename),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", filename)
            };

            foreach (string p in searchPaths)
            {
                if (File.Exists(p)) return Path.GetFullPath(p);
            }
            return filename;
        }
    }
}
