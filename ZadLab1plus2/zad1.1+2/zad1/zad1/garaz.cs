using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    

    public class Garaz
    {
        private string adres;
        private int pojemnosc;
        private int liczbaSamochodow;
        private Samochod[] samochody;

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        public int Pojemnosc
        {
            get { return pojemnosc; }
            set
            {
                pojemnosc = value;
                samochody = new Samochod[pojemnosc];
            }
        }

        public Garaz()
        {
            adres = "nieznany";
            pojemnosc = 0;
            liczbaSamochodow = 0;
            samochody = null;
        }

        public Garaz(string adres_, int pojemnosc_)
        {
            adres = adres_;
            pojemnosc = pojemnosc_;
            liczbaSamochodow = 0;
            samochody = new Samochod[pojemnosc];
        }

        public void WprowadzSamochod(Samochod nowySamochod)
        {
            if (liczbaSamochodow >= pojemnosc)
            {
                Console.WriteLine("Garaż jest pełny. Nie można dodać więcej samochodów.");
            }
            else
            {
                samochody[liczbaSamochodow] = nowySamochod;
                liczbaSamochodow++;
            }
        }

        public Samochod WyprowadzSamochod()
        {
            if (liczbaSamochodow == 0)
            {
                Console.WriteLine("Garaż jest pusty. Nie można wyprowadzić samochodu.");
                return null;
            }
            else
            {
                Samochod ostatniSamochod = samochody[liczbaSamochodow - 1];
                samochody[liczbaSamochodow - 1] = null;
                liczbaSamochodow--;
                return ostatniSamochod;
            }
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Adres garażu: " + adres);
            Console.WriteLine("Pojemność garażu: " + pojemnosc);
            Console.WriteLine("Liczba garażowanych samochodów: " + liczbaSamochodow);
            Console.WriteLine("Informacje o garażowanych samochodach:");
            for (int i = 0; i < liczbaSamochodow; i++)
            {
                samochody[i].WypiszInfo();
            }
        }
    }

}
