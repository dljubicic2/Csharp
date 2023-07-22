using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class ObradaOsoba
    {
        public List<Osoba> Osobe { get; }
        public ObradaOsoba()
        {
            Osobe = new List<Osoba>();
        }
        private void PrikaziIzbornik()
        {


            Console.WriteLine("Izbornik za rad s osobama");
            Console.WriteLine("1. Pregled postojecih osoba");
            Console.WriteLine("2. Unos nove osobe");
            Console.WriteLine("3. Promjena postojecih osoba");
            Console.WriteLine("4. Brisanje osoba");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.UcitajBrojRaspon("Odaberite stavku izbornika osobe: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 1:
                    PregledOsobe();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UcitajOsobu();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s osobama");
                    break;
            }

        }

        private void PregledOsobe()
        {
            foreach(Osoba Osoba in Osobe)
            {
                Console.WriteLine(Osoba);
            }
        }

        private void UcitajOsobu()
        {
            var p = new Osoba();
            p.Nadimak = Pomocno.UcitajString("Unesi nadimak osobe: ",
                "Unos obavezan");
            p.Email = Pomocno.UcitajString("Unesi email osobe: ",
                "email obavezan");
            p.Lozinka = Pomocno.UcitajString("Unesi lozinku osobe:",
                "Unos obavezan");
            Osobe.Add(p);
        }
    }
}
