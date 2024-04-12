using System;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zad2._2
{
    public partial class CalculatorForm : Form
    {
        private Stopwatch stopwatch;

        public CalculatorForm()
        {
            InitializeComponent();

            // Inicjalizacja stopera
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CalculatorForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "CalculatorForm";
            this.Text = "Simple Calculator";
            this.ResumeLayout(false);
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                textBox.Text += button.Text;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                double result = EvaluateExpression(textBox.Text);
                textBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                HandleError("Wystąpił błąd podczas obliczania: " + ex.Message);
            }
        }

        private double EvaluateExpression(string expression)
        {
            return Convert.ToDouble(new System.Data.DataTable().Compute(expression, null));
        }

        private void HandleError(string errorMessage)
        {
            EventLog eventLog = new EventLog("Application");
            eventLog.Source = "SimpleCalculator";
            eventLog.WriteEntry(errorMessage, EventLogEntryType.Error);

            MessageBox.Show(errorMessage, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void OnLoad(EventArgs e)
        {
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            if (elapsedTime.TotalMilliseconds > 1000)
            {
                EventLog eventLog = new EventLog("Application");
                eventLog.Source = "SimpleCalculator";
                eventLog.WriteEntry($"Czas inicjalizacji komponentów: {elapsedTime.TotalMilliseconds} ms", EventLogEntryType.Information);
            }

            base.OnLoad(e);
        }
    }
}
