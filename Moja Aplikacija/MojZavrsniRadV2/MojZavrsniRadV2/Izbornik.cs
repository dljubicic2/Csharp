using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojZavrsniRadV2
{
    internal class Izbornik
    {
        public ObradaOsoba ObradaOsoba { get; }
        public ObradaVozilo ObradaVozilo { get; }
        public ObradaOglas ObradaOglas { get; }
        public ObradaUpit ObradaUpit { get; }
        public Izbornik()
        {
            ObradaOglas = new ObradaOglas();
            ObradaVozilo = new ObradaVozilo();
            ObradaOsoba = new ObradaOsoba();
            ObradaUpit = new ObradaUpit();
            PozdravnaPoruka();
            PrikaziIzbornik();
        }
        private void PrikaziIzbornik()
        {
            Console.WriteLine("Glavni izbornik: ");
            Console.WriteLine("1. Upit");
            Console.WriteLine("2. Osoba");
            Console.WriteLine("3. Vozilo");
            Console.WriteLine("4. Oglas");
            Console.WriteLine("5. Izlaz iz programa");
            switch(pomocno.UcitajBrojRaspon("Odaberite stavku izbornika: ",
                "Odabir mora biti 1 - 5", 1, 5))
            {
                case 1:
                    ObradaUpit.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 2:
                    ObradaOsoba.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 3:
                    ObradaVozilo.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObradaOglas.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Hvala na korištenju!");
                    break;

            }
        }
        private void PozdravnaPoruka()
        {
            Console.WriteLine("************************");
            Console.WriteLine("***MOJ ZAVRSNI RAD V2***");
            Console.WriteLine("************************");
        }
    }
}
