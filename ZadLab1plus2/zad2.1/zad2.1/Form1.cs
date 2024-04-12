using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace DivisionApp
{
    public partial class MainForm : Form
    {
        private TextBox dividendTextBox;
        private TextBox divisorTextBox;
        private TextBox resultTextBox;
        private Button divideButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dividendTextBox = new TextBox();
            this.divisorTextBox = new TextBox();
            this.resultTextBox = new TextBox();
            this.divideButton = new Button();
            this.SuspendLayout();
            // 
            // dividendTextBox
            // 
            this.dividendTextBox.Location = new System.Drawing.Point(50, 50);
            this.dividendTextBox.Name = "dividendTextBox";
            this.dividendTextBox.Size = new System.Drawing.Size(100, 20);
            this.dividendTextBox.TabIndex = 0;
            // 
            // divisorTextBox
            // 
            this.divisorTextBox.Location = new System.Drawing.Point(50, 100);
            this.divisorTextBox.Name = "divisorTextBox";
            this.divisorTextBox.Size = new System.Drawing.Size(100, 20);
            this.divisorTextBox.TabIndex = 1;
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(50, 150);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(100, 20);
            this.resultTextBox.TabIndex = 2;
            // 
            // divideButton
            // 
            this.divideButton.Location = new System.Drawing.Point(50, 200);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(75, 23);
            this.divideButton.TabIndex = 3;
            this.divideButton.Text = "Divide";
            this.divideButton.UseVisualStyleBackColor = true;
            this.divideButton.Click += new EventHandler(this.divideButton_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(200, 250);
            this.Controls.Add(this.divideButton);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.divisorTextBox);
            this.Controls.Add(this.dividendTextBox);
            this.Name = "MainForm";
            this.Text = "Division App";
            this.ResumeLayout(false);
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            try
            {
                double dividend = double.Parse(dividendTextBox.Text);
                double divisor = double.Parse(divisorTextBox.Text);

                if (divisor == 0)
                {
                    throw new DivideByZeroException("Nie można dzielić przez zero.");
                }

                double result = dividend / divisor;

                resultTextBox.Text = result.ToString();
            }
            catch (FormatException ex)
            {
                HandleError("Błąd formatu liczby: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                HandleError("Błąd przepełnienia: " + ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                HandleError("Błąd dzielenia przez zero: " + ex.Message);
            }
            catch (Exception ex)
            {
                HandleError("Wystąpił nieoczekiwany błąd: " + ex.Message);
            }
        }

        private void HandleError(string errorMessage)
        {
            EventLog eventLog = new EventLog("Application");
            eventLog.Source = "DivisionApp";
            eventLog.WriteEntry(errorMessage, EventLogEntryType.Error);

            MessageBox.Show(errorMessage, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
