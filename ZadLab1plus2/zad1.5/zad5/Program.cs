using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zad5
{
    using System;
    

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Zapisz dane do pliku binarnego");
            Console.WriteLine("2. Odczytaj dane z pliku binarnego");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ZapiszDoPlikuBinarnego();
                    break;
                case 2:
                    OdczytajZPlikuBinarnego();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja.");
                    break;
            }
        }

        static void ZapiszDoPlikuBinarnego()
        {
            Console.WriteLine("Podaj imię:");
            string imie = Console.ReadLine();

            Console.WriteLine("Podaj wiek:");
            int wiek = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj adres:");
            string adres = Console.ReadLine();

            try
            {
                using (FileStream fileStream = new FileStream("dane.bin", FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter writer = new BinaryWriter(fileStream))
                    {
                        writer.Write(imie);
                        writer.Write(wiek);
                        writer.Write(adres);
                    }
                }
                Console.WriteLine("Dane zostały zapisane do pliku.");
            }
            catch (IOException e)
            {
                Console.WriteLine("Wystąpił błąd wejścia/wyjścia: " + e.Message);
            }
        }

        static void OdczytajZPlikuBinarnego()
        {
            try
            {
                using (FileStream fileStream = new FileStream("dane.bin", FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        string imie = reader.ReadString();
                        int wiek = reader.ReadInt32();
                        string adres = reader.ReadString();

                        Console.WriteLine("Imię: " + imie);
                        Console.WriteLine("Wiek: " + wiek);
                        Console.WriteLine("Adres: " + adres);
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
        }
    }

}
