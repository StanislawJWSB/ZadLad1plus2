using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zad3
{
    
    

    class Program
    {
        static void Main(string[] args)
        {
           
            string filePath = "D:\\StasD\\Profil\\Desktop\\Nowy_Komp\\Dane\\Studia\\dotnet\\zad3\\123.txt";

            try
            {
                
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        
                        Console.WriteLine("Zawartość pliku:");

                        
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
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
