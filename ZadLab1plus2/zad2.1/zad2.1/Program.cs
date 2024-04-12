using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace zad2._1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Konwersja danych z pól tekstowych na liczby
                double dividend = double.Parse(dividendTextBox.Text);
                double divisor = double.Parse(divisorTextBox.Text);

                // Sprawdzenie, czy dzielnik nie jest równy zero
                if (divisor == 0)
                {
                    throw new DivideByZeroException("Nie można dzielić przez zero.");
                }

                // Wykonanie operacji dzielenia
                double result = dividend / divisor;

                // Wyświetlenie wyniku
                resultTextBox.Text = result.ToString();
            }
            catch (FormatException ex)
            {
                // Obsługa błędów formatu liczby
                HandleError("Błąd formatu liczby: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                // Obsługa błędów przepełnienia
                HandleError("Błąd przepełnienia: " + ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                // Obsługa błędów dzielenia przez zero
                HandleError("Błąd dzielenia przez zero: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Obsługa innych nieoczekiwanych błędów
                HandleError("Wystąpił nieoczekiwany błąd: " + ex.Message);
            }
        }

        private void HandleError(string errorMessage)
        {
            // Dodanie błędu do dziennika zdarzeń systemu Windows
            EventLog eventLog = new EventLog("Application");
            eventLog.Source = "DivisionApp";
            eventLog.WriteEntry(errorMessage, EventLogEntryType.Error);

            // Wyświetlenie komunikatu o błędzie
            MessageBox.Show(errorMessage, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
