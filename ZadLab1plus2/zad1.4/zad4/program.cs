using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zad4
{

    class Program
    {
        static void Main(string[] args)
        {
            
            string filePath = "D:\\StasD\\Profil\\Desktop\\Nowy_Komp\\Dane\\Studia\\dotnet\\zad4\\test.txt";

            try
            {
                
                using (StreamReader reader = new StreamReader(filePath))
                {
                    
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        
                        char[] reversedLine = line.ToCharArray();
                        Array.Reverse(reversedLine);
                        string reversedString = new string(reversedLine);

                        
                        Console.WriteLine(reversedString);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Plik nie został znaleziony.");
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
