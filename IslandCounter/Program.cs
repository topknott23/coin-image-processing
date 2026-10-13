using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IslandCounter
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Launches the Windows Forms UI (Form1) by default.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // If run from command line with --cli, output to console
            if (args.Length > 0 && (args[0] == "--cli" || args[0] == "-c"))
            {
                RunConsoleMode();
                return;
            }

            // Standard Windows Forms initialization and launch
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        static void RunConsoleMode()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string inputPath = ResolvePath("coins_flattened.png");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file '{inputPath}' not found.");
                return;
            }

            Console.WriteLine("Loading image...");
            using (Bitmap bitmap = new Bitmap(inputPath))
            {
                var result = CoinDetector.AnalyzeImage(bitmap, minCoinArea: 1000, numGroups: 5);

                Console.WriteLine($"Background base color: C({result.BackgroundColor.R}, {result.BackgroundColor.G}, {result.BackgroundColor.B})");
                Console.WriteLine("Finding islands using BFS...");
                Console.WriteLine($"\nFound {result.TotalCoins} total coins.");

                if (result.TotalCoins == 0)
                {
                    Console.WriteLine("No valid coins found to group.");
                    return;
                }

                Console.WriteLine($"Grouped into {result.Groups.Count} coin denominations:");
                foreach (var g in result.Groups)
                {
                    Console.WriteLine($"- {g.Denomination,-8} (~{g.AverageArea:F0} pixels): {g.Count,2} coins  (Unit: ₱{g.UnitValue:F2} | Subtotal: ₱{g.TotalValue:F2})");
                }

                Console.WriteLine($"\nTotal Coins:  {result.TotalCoins}");
                Console.WriteLine($"Total Amount: ₱{result.TotalValue:F2}");
            }
        }

        static string ResolvePath(string filename)
        {
            string[] searchPaths = {
                filename,
                Path.Combine("..", filename),
                Path.Combine("..", "..", filename),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", filename)
            };

            foreach (string p in searchPaths)
            {
                if (File.Exists(p)) return p;
            }
            return filename;
        }
    }
}
