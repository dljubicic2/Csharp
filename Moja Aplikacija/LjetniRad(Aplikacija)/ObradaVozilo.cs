using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class ObradaVozilo
    {
        private List<Vozilo> Vozila;
        public ObradaVozilo()
        {
            Vozila = new List<Vozilo>();
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s vozilima");
            Console.WriteLine("1. Pregled postojecih vozila");
            Console.WriteLine("2. Unos novog vozila");
            Console.WriteLine("3. Promjena postojeceg vozila");
            Console.WriteLine("4. Brisanje vozila");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.UcitajBrojRaspon("Odaberite stavku izbornika vozila: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 2:
                    UnosNovogVozila();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s vozilima");
                    break;
               
            }
        }

        private void UnosNovogVozila()
        {
            var g = new Vozilo();
            g.Sifra = Pomocno.UcitajCijeliBroj("Unesite sifru vozila: ",
                "Unos mora biti pozitivni cijeli broj");
            g.Vrsta = Pomocno.UcitajString("Unesite vrstu vozila: ",
                "Unos obavezan");
            g.Marka = Pomocno.UcitajString("Unesite marku vozila:",
                "Unos obavezan");
            g.Model = Pomocno.UcitajString("Unesite model vozila: ",
                "Unos obavezan");
            g.Pogon = Pomocno.UcitajString("Unesite pogon vozila: ",
                "Unos obavezan");
            g.Kilometraza = Pomocno.UcitajCijeliBroj("Unesite kilometražu vozila: ",
                "Unos obavezan");
            g.Osobe = UcitajOsobu();
        


            Vozila.Add(g);
        }
    }
}
