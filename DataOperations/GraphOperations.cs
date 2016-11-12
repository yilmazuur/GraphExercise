using DataModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataOperations
{
    public class GraphOperations : IGraphOperations
    {
        public IDataFile inputFile { get; set; }

        public GraphOperations(IDataFile inputFileAsParameter)
        {
            inputFile = inputFileAsParameter;
        }

        public string DrawGraphAsImage()
        {
            var xvals = inputFile.Graph.Select(x => x.Name).ToArray();
            var yvals = inputFile.Graph.Select(x => x.Value).ToArray();

            var chart = new Chart();
            chart.Size = new Size(400, 150);

            var chartArea = new ChartArea();
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font(Constants.LABEL_FONT, 8);
            chartArea.AxisY.LabelStyle.Font = new Font(Constants.LABEL_FONT, 8);
            chart.ChartAreas.Add(chartArea);

            var series = new Series();
            series.Name = Constants.SERIES_1;
            series.ChartType = SeriesChartType.Bar;
            series.XValueType = ChartValueType.String;
            chart.Series.Add(series);

            chart.Series[Constants.SERIES_1].Points.DataBindXY(xvals, yvals);
            for (int i = 0; i < chart.Series[Constants.SERIES_1].Points.Count; i++)
            {
                chart.Series[Constants.SERIES_1].Points[i].Color = Color.FromName(inputFile.Graph[i].Color);
            }
            chart.Invalidate();

            string imagePath = Path.Combine(inputFile.FileDirectory, Constants.CHART_NAME);
            chart.SaveImage(imagePath, ChartImageFormat.Png);
            return imagePath;
        }

        public void VisualizeChart(string graphPath)
        {
            Point location = new Point(0, 100);
            using (Graphics g = Graphics.FromHwnd(GetConsoleWindow()))
            {
                using (Image image = Image.FromFile(graphPath))
                {
                    // translating the character positions to pixels
                    Rectangle imageRect = new Rectangle(
                        location.X,
                        location.Y,
                        image.Width,
                        image.Height);
                    g.DrawImage(image, imageRect);
                }
            }
        }

        #region Hack Console Application Window

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateFile(
            string lpFileName,
            int dwDesiredAccess,
            int dwShareMode,
            IntPtr lpSecurityAttributes,
            int dwCreationDisposition,
            int dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetCurrentConsoleFont(
            IntPtr hConsoleOutput,
            bool bMaximumWindow,
            [Out][MarshalAs(UnmanagedType.LPStruct)]ConsoleFontInfo lpConsoleCurrentFont);

        [StructLayout(LayoutKind.Sequential)]
        internal class ConsoleFontInfo
        {
            internal int nFont;
            internal Coord dwFontSize;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct Coord
        {
            [FieldOffset(0)]
            internal short X;
            [FieldOffset(2)]
            internal short Y;
        }

        #endregion
    }
}
