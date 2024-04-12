using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zad6
{
    

    class Program
    {
        static void Main(string[] args)
        {
            // Ścieżka do pliku źródłowego
            string sourceFilePath = "D:\\StasD\\Profil\\Desktop\\Nowy_Komp\\Dane\\Studia\\dotnet\\zad6\\plik1.txt";

            // Ścieżka do pliku docelowego
            string destinationFilePath = "D:\\StasD\\Profil\\Desktop\\Nowy_Komp\\Dane\\Studia\\dotnet\\zad6\\plik2.txt";

            try
            {
                // Otwarcie istniejącego pliku źródłowego w trybie do odczytu
                using (FileStream sourceFileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                {
                    // Otwarcie nowego lub istniejącego pliku docelowego w trybie do zapisu
                    using (FileStream destinationFileStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                    {
                        // Bufor do przechowywania danych
                        byte[] buffer = new byte[1024];
                        int bytesRead;

                        // Odczytaj dane z pliku źródłowego i zapisz je do pliku docelowego
                        while ((bytesRead = sourceFileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            destinationFileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                Console.WriteLine("Plik został pomyślnie skopiowany.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Plik źródłowy nie został znaleziony.");
            }
            catch (IOException e)
            {
                Console.WriteLine("Wystąpił błąd wejścia/wyjścia: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił nieoczekiwany błąd: " + e.Message);
            }
        }
    }

}
