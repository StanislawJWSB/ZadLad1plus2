﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    internal class test1
    {
        Samochod s1 = new Samochod(); 
        s1.WypiszInfo(); s1.Marka = "Fiat"; s1.Model = "126p"; s1.IloscDrzwi = 2; s1.PojemnoscSilnika = 650; s1.SrednieSpalanie = 6.0; s1.WypiszInfo(); Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6); s2.WypiszInfo(); double kosztPrzejazdu = s2.ObliczKosztPrzejazdu(30.5, 4.85); Console.WriteLine("Koszt przejazdu: " + kosztPrzejazdu);
Samochod.WypiszIloscSamochodow(); Console.ReadKey();
    }
}
