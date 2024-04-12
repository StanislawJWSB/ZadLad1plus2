using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace zad2._2
{
    public partial class Form1 : Form
    {
        private TextBox textBox;
        private Button[] numberButtons;
        private Button addButton;
        private Button subtractButton;
        private Button multiplyButton;
        private Button divideButton;
        private Button clearButton;
        private Button calculateButton;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBox = new TextBox();
            this.addButton = new Button();
            this.subtractButton = new Button();
            this.multiplyButton = new Button();
            this.divideButton = new Button();
            this.clearButton = new Button();
            this.calculateButton = new Button();
            this.numberButtons = new Button[10];

            this.SuspendLayout();

            // TextBox
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(260, 20);
            this.textBox.TabIndex = 0;

            // Number buttons
            for (int i = 0; i < 10; i++)
            {
                this.numberButtons[i] = new Button();
                this.numberButtons[i].Location = new System.Drawing.Point(12 + (i % 3) * 56, 38 + (i / 3) * 56);
                this.numberButtons[i].Name = "button" + i;
                this.numberButtons[i].Size = new System.Drawing.Size(50, 50);
                this.numberButtons[i].TabIndex = 1 + i;
                this.numberButtons[i].Text = i.ToString();
                this.numberButtons[i].UseVisualStyleBackColor = true;
                this.numberButtons[i].Click += new EventHandler(button_Click);
            }

            // AddButton
            this.addButton.Location = new System.Drawing.Point(200, 38);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(50, 50);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new EventHandler(operatorButton_Click);

            // SubtractButton
            this.subtractButton.Location = new System.Drawing.Point(200, 94);
            this.subtractButton.Name = "subtractButton";
            this.subtractButton.Size = new System.Drawing.Size(50, 50);
            this.subtractButton.TabIndex = 12;
            this.subtractButton.Text = "-";
            this.subtractButton.UseVisualStyleBackColor = true;
            this.subtractButton.Click += new EventHandler(operatorButton_Click);

            // MultiplyButton
            this.multiplyButton.Location = new System.Drawing.Point(200, 150);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(50, 50);
            this.multiplyButton.TabIndex = 13;
            this.multiplyButton.Text = "*";
            this.multiplyButton.UseVisualStyleBackColor = true;
            this.multiplyButton.Click += new EventHandler(operatorButton_Click);

            // DivideButton
            this.divideButton.Location = new System.Drawing.Point(200, 206);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(50, 50);
            this.divideButton.TabIndex = 14;
            this.divideButton.Text = "/";
            this.divideButton.UseVisualStyleBackColor = true;
            this.divideButton.Click += new EventHandler(operatorButton_Click);

            // ClearButton
            this.clearButton.Location = new System.Drawing.Point(12, 206);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(118, 50);
            this.clearButton.TabIndex = 15;
            this.clearButton.Text = "C";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new EventHandler(clearButton_Click);

            // CalculateButton
            this.calculateButton.Location = new System.Drawing.Point(136, 206);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(114, 50);
            this.calculateButton.TabIndex = 16;
            this.calculateButton.Text = "=";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new EventHandler(calculateButton_Click);

            // CalculatorForm
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.divideButton);
            this.Controls.Add(this.multiplyButton);
            this.Controls.Add(this.subtractButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.textBox);
            for (int i = 0; i < 10; i++)
            {
                this.Controls.Add(this.numberButtons[i]);
            }
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

        private void operatorButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                textBox.Text += " " + button.Text + " ";
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
    }
}
