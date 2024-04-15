using System.Drawing;

namespace DancingProgressBars
{
    internal class ProgressBar
    {
        public int Minimum { get; internal set; }
        public int Maximum { get; internal set; }
        public int Value { get; internal set; }
        public int Width { get; internal set; }
        public int Height { get; internal set; }
        public Padding Margin { get; internal set; }
        public Color BackColor { get; internal set; }
    }
}