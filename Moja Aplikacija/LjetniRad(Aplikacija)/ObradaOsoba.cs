using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class ObradaOsoba
    {
        private List<Osoba> Osobe { get; }
        public ObradaOsoba()
        {
            Osobe = new List<Osoba>();
            TestniPodaci();
        }

        private void TestniPodaci()
        {
            Osobe.Add(new Osoba
            {
                Nadimak = "Anita66",
                Email = "Anita66@gmail.com"

            });
            Osobe.Add(new Osoba
            {
                Nadimak = "Lukaluks123",
                Email = "lluka@gmail.com"

            });
        }

        public void PrikaziIzbornik()
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
                case 3:
                    PromjenaOsobe();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeOsobe();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s osobama");
                    break;
            }

        }

        private void BrisanjeOsobe()
        {
            PregledOsobe();
            int broj = Pomocno.UcitajBrojRaspon("Odaberi redni broj osobe za brisanje: ",
                "Nije dobro", 1, Osobe.Count());
            Osobe.RemoveAt(broj - 1);
        }

        public void PromjenaOsobe()
        {
            int broj = Pomocno.UcitajBrojRaspon("Odaberi redni broj osobe za promjenu: ",
               "Nije dobro", 1, Osobe.Count());
            var s = Osobe[broj - 1];
            s.Sifra = Pomocno.UcitajCijeliBroj("Unesi sifru upita: (" + s.Sifra + "): ",
                "Unos mora biti pozitivni cijeli broj");
            s.Nadimak = Pomocno.UcitajString("Unesi nadimak osobe: (" + s.Nadimak + "): ",
            "Unos obavezan");
            s.Email = Pomocno.UcitajString("Unesi email: (" + s.Email + ") ",
            "Unos obavezan");
            s.Lozinka = Pomocno.UcitajString("Unesi lozinku: (" + s.Lozinka + "): ",
            "Unos obavezan");

            s.BrojTelefona = Pomocno.UcitajCijeliBroj("Unesi broj telefona osobe: (" + s.BrojTelefona + "): ",
            "Unos obavezan");
        }

        public void PregledOsobe()
        {
            int b = 1;
            foreach(Osoba Osoba in Osobe)
            {
                Console.WriteLine("\t{0}. {1}", b++, Osoba);
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
