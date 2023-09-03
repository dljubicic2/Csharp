using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MojZavrsniRadV2
{
    internal class ObradaVozilo
    {
        public List<Vozilo> Vozila {get; set;}
        private Izbornik Izbornik;

        public ObradaVozilo()
        {
            Vozila = new List<Vozilo>();
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s vozilima");
            Console.WriteLine("1. Pregled postojećih vozila");
            Console.WriteLine("2. Unos novog vozila");
            Console.WriteLine("3. Brisanje vozila");
            Console.WriteLine("4. Promjena postojećih vozila");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (pomocno.UcitajBrojRaspon("Izaberite stavku izbornika vozilo: ",
                "Odabir mora biti od 1 - 5", 1, 5))
            {
                case 1:
                    PregledPostojecihVozila();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogVozila();
                    PrikaziIzbornik();
                    break;
                case 3:
                    BrisanjeVozila();
                    PrikaziIzbornik();
                    break;
                case 4:
                    PromjenaPostojecegVozila();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s vozilima");
                    break;
            }
        }

        private void PromjenaPostojecegVozila()
        {
            PregledPostojecihVozila();
            int index = pomocno.UcitajBrojRaspon("Odaberite broj vozila za promjenu: ",
               "Nije dobar odabir!", 1, Vozila.Count());
            var v = Vozila[index - 1];

            v.Vrsta = pomocno.UcitajString("Unesite vrstu vozila ("+ v.Vrsta +"):",
                "Unos obavezan!");
            v.Model = pomocno.UcitajString("Unesite model vozila ("+ v.Model +"):",
                "Unos obavezan!");
            v.Marka = pomocno.UcitajString("Unesite marku vozila ("+ v.Marka +"):",
                "Unos obavezan!");
            v.Pogon = pomocno.UcitajString("Unesite pogon vozila ("+ v.Pogon +"):",
                "Unos obavezan!");
            v.Godiste = pomocno.UcitajDatum("Unesite godište vozila ("+ v.Godiste +"):",
                "Unos obavezan!");
            v.Kilometraza = pomocno.UcitajCijeliBroj("Unesite kilometražu vozila ("+ v.Kilometraza +"):",
                "Unos obavezan!");
            v.Osobe = PostaviOsobe();
            Vozila.Add(v);
        }

        private void BrisanjeVozila()
        {
            PregledPostojecihVozila();
            int index = pomocno.UcitajBrojRaspon("Odaberite broj vozila za brisanje: ",
                "Nije dobar odabir!", 1, Vozila.Count());
            Vozila.RemoveAt(index - 1);
        }

        public void PregledPostojecihVozila()
        {
            int b = 1;
            foreach(Vozilo vozilo in Vozila)
            {
                Console.WriteLine("{0} {1}", b++, vozilo);
            }
        }

        private void UnosNovogVozila()
        {
            var v = new Vozilo();

            v.Vrsta = pomocno.UcitajString("Unesite vrstu vozila: ",
                "Unos obavezan!");
            v.Model = pomocno.UcitajString("Unesite model vozila: ",
                "Unos obavezan!");
            v.Marka = pomocno.UcitajString("Unesite marku vozila: ",
                "Unos obavezan!");
            v.Pogon = pomocno.UcitajString("Unesite pogon vozila: ",
                "Unos obavezan!");
            v.Godiste = pomocno.UcitajDatum("Unesite godište vozila: ",
                "Unos obavezan!");
            v.Kilometraza = pomocno.UcitajCijeliBroj("Unesite kilometražu vozila: ",
                "Unos obavezan!");
            v.Osobe = PostaviOsobe();
            Vozila.Add(v);
                
        }

        private List<Osoba> PostaviOsobe()
        {
            List<Osoba> osobe = new List<Osoba>();
            while (pomocno.UcitajBool("Želite li dodati osobe? (da ili bilo što drugo za ne):"))
            {
                osobe.Add(PostaviOsobu());
            }
            return osobe;
        }

        private Osoba PostaviOsobu()
        {
            Izbornik.ObradaOsoba.PregledPostojecihOsoba();
            int index = pomocno.UcitajBrojRaspon("Odaberite redni broj osobe: ",
                "Nije dobar odabir!", 1, Izbornik.ObradaOsoba.Osobe.Count());
            return Izbornik.ObradaOsoba.Osobe[index - 1];
        }
    }
}
