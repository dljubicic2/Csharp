using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojZavrsniRadV2
{
    internal class ObradaOsoba
    {
        public List<Osoba> Osobe { get; }

        public ObradaOsoba()
        {
            Osobe = new List<Osoba>();
            if (pomocno.dev)
            {
                TestniPodaci();
            }
            
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s osobama");
            Console.WriteLine("1. Pregled postojećih osoba");
            Console.WriteLine("2. Unos nove osobe");
            Console.WriteLine("3. Brisanje osobe");
            Console.WriteLine("4. Promjena postojeće osobe");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (pomocno.UcitajBrojRaspon("Izaberite stavku izbornika osoba: ",
                "Odabir mora biti od 1 - 5", 1, 5))
            {
                case 1:
                    PregledPostojecihOsoba();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNoveOsobe();
                    PrikaziIzbornik();
                    break;
                case 3:
                    BrisanjeOsobe();
                    PrikaziIzbornik();
                    break;
                case 4:
                    PromjenaPostojeceOsobe();
                    PrikaziIzbornik();
                    break;

                case 5:
                    Console.WriteLine("Gotov rad s osobama");
                    break;
            }
        }

        private void PromjenaPostojeceOsobe()
        {
            PregledPostojecihOsoba();
            int index = pomocno.UcitajBrojRaspon("Odaberite broj osobe za promjenu: ",
                "Nije dobar odabir!", 1, Osobe.Count());
            var o = Osobe[index - 1];

            o.Sifra = pomocno.UcitajCijeliBroj("Unesite sifru osobe (" + o.Sifra + "):",
                "Unos mora biti cijeli pozitivan broj!");
            o.Nadimak = pomocno.UcitajString("Unesite nadimak osobe (" + o.Nadimak + "):",
                "Unos obavezan! ");
            o.Email = pomocno.UcitajString("Unesite Email osobe (" + o.Email + "):",
                "Unos obavezan!");
            o.Lozinka = pomocno.UcitajString("Unesite lozinku osobe (" + o.Lozinka + "):",
                "Unos obavezan!");
            o.BrojTelefona = pomocno.UcitajCijeliBroj("Unesite broj telefona (" + o.BrojTelefona + "):",
                "Unos obavezan");
        }

        private void BrisanjeOsobe()
        {
            PregledPostojecihOsoba();
            int index = pomocno.UcitajBrojRaspon("Odaberite broj osobe za brisanje: ",
                "Nije dobar odabir!", 1, Osobe.Count());
            Osobe.RemoveAt(index - 1);
        }

        public void PregledPostojecihOsoba()
        {
            int a = 1;
            foreach (Osoba osoba in Osobe)
            {
                Console.WriteLine("{0} {1}", a++, osoba);
            }
        }

        private void UnosNoveOsobe()
        {
            var o = new Osoba();


            o.Sifra = pomocno.UcitajCijeliBroj("Unesite sifru osobe: ",
                "Unos mora biti cijeli pozitivan broj!");
            o.Nadimak = pomocno.UcitajString("Unesite nadimak osobe: ",
                "Unos obavezan! ");
            o.Email = pomocno.UcitajString("Unesite Email osobe: ",
                "Unos obavezan!");
            o.Lozinka = pomocno.UcitajString("Unesite lozinku osobe: ",
                "Unos obavezan!");
            o.BrojTelefona = pomocno.UcitajCijeliBroj("Unesite broj telefona: ",
                "Unos obavezan");
            Osobe.Add(o);

        }
        private void TestniPodaci()
        {
            Osobe.Add(new Osoba
            {
                Sifra = 1,
                Nadimak = "Anica123",
                Email = "AnaAnica123@gmail.com",
                Lozinka = "anaana123",
                BrojTelefona = 0991236734
            });
            Osobe.Add(new Osoba
            {
                Sifra = 2,
                Nadimak = "Domac13",
                Email = "dljubicic2@gmail.com",
                Lozinka = "Domac13",
                BrojTelefona = 0993276689
            });
        }
    }
}

