using System.Drawing;

namespace DancingProgressBars
{
    public partial class MainForm : Form
    {
        private List<ProgressBar> progressBars = new List<ProgressBar>();
        private CancellationTokenSource cancellationTokenSource;
        private object numericUpDownBars;
        private object panelBars;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void btnCreateBars_Click(object sender, EventArgs e)
        {
            int numberOfBars = (int)numericUpDownBars.Value;
            CreateProgressBars(numberOfBars);
        }

        private void CreateProgressBars(int numberOfBars)
        {
            progressBars.Clear();
            panelBars.Controls.Clear();

            for (int i = 0; i < numberOfBars; i++)
            {
                ProgressBar progressBar = new ProgressBar();
                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Value = 0;
                progressBar.Width = 200;
                progressBar.Height = 20;
                progressBar.Margin = new Padding(0, 5, 0, 5);
                progressBars.Add(progressBar);
                panelBars.Controls.Add(progressBar);
            }
        }

        private async void btnStartDancing_Click(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            await DanceAsync();
        }

        private async Task DanceAsync()
        {
            Random random = new Random();

            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                foreach (var progressBar in progressBars)
                {
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                        break;

                    int value = random.Next(progressBar.Minimum, progressBar.Maximum + 1);
                    progressBar.Value = value;
                    progressBar.BackColor = GetRandomColor();
                    await Task.Delay(200);
                }
            }
        }

        private Color GetRandomColor()
        {
            Random random = new Random();
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
