using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojZavrsniRadV2
{
    internal class ObradaOglas
    {
        public List<Oglas> Oglasi { get; set; }
        private Izbornik Izbornik { get; set; }
        

        public ObradaOglas() 
        {
            Oglasi = new List<Oglas>();
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s oglasima");
            Console.WriteLine("1. Pregled postojećih oglasa");
            Console.WriteLine("2. Unos novog oglasa");
            Console.WriteLine("3. Brisanje oglasa");
            Console.WriteLine("4. Promjena postojećih oglasa");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (pomocno.UcitajBrojRaspon("Izaberite stavku izbornika oglas: ",
                "Odabir mora biti od 1 - 5", 1, 5))
            {
                case 1:
                    PregledPostojecihOglasa();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogOglasa();
                    PrikaziIzbornik();
                    break;
                case 3:
                    BrisanjeOglasa();
                    PrikaziIzbornik();
                    break;
                case 4:
                    PromjenaPostojecegOglasa();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s oglasima");
                    break;
            }
        }

        private void PromjenaPostojecegOglasa()
        {
            PregledPostojecihOglasa();
            int index = pomocno.UcitajBrojRaspon("Odaberite broj oglasa za promjenu: ",
              "Nije dobar odabir!", 1, Oglasi.Count());
            var l = Oglasi[index - 1];

            l.Sifra = pomocno.UcitajCijeliBroj("Unesite sifru oglasa ("+ l.Sifra +"):",
                "Unos mora biti pozitivan broj!");
            l.Naslov = pomocno.UcitajString("Unesite naslov oglasa ("+ l.Naslov +"):",
              "Unos obavezan!");
            l.Opis = pomocno.UcitajString("Unesite opis oglasa ("+ l.Opis +"):",
                "Unos obavezan!");
            l.Cijena = pomocno.UcitajDecimalniBroj("Unesite cijenu oglasa ("+ l.Cijena +"):",
                "Unos obavezan!");
            l.Osobe = PostaviOsobe();
            l.Vozila = PostaviVozila();


        }

        private void BrisanjeOglasa()
        {
            PregledPostojecihOglasa();
            int index = pomocno.UcitajBrojRaspon("Odaberite broj oglasa za brisanje: ",
                "Nije dobar odabir!", 1, Oglasi.Count());
            Oglasi.RemoveAt(index - 1);
        }

        public void PregledPostojecihOglasa()
        {
            int c = 1;
            foreach(Oglas oglas in Oglasi)
            {
                Console.WriteLine("{0} {1}",c++,oglas);
            }
        }

        private void UnosNovogOglasa()
        {
            var l = new Oglas();

            l.Sifra = pomocno.UcitajCijeliBroj("Unesite sifru oglasa: ",
                "Unos mora biti pozitivan broj!");
            l.Naslov = pomocno.UcitajString("Unesite naslov oglasa: ",
                "Unos obavezan!");
            l.Opis = pomocno.UcitajString("Unesite opis oglasa: ",
                "Unos obavezan!");
            l.Cijena = pomocno.UcitajDecimalniBroj("Unesite cijenu oglasa: ",
                "Unos obavezan!");
            l.Osobe = PostaviOsobe();
            l.Vozila = PostaviVozila();
            Oglasi.Add(l);
        }

        private List<Vozilo> PostaviVozila()
        {
            List<Vozilo> vozila = new List<Vozilo>();
            while (pomocno.UcitajBool("Želite li dodati vozilo? (da ili bilo što drugo za ne):"))
            {
                vozila.Add(PostaviVozilo());
            }
            return vozila;
        }

        private Vozilo PostaviVozilo()
        {
            Izbornik.ObradaVozilo.PregledPostojecihVozila();
            int index = pomocno.UcitajBrojRaspon("Odaberite redni broj vozila: ",
                "Nije dobar odabir!", 1, Izbornik.ObradaVozilo.Vozila.Count());
            return Izbornik.ObradaVozilo.Vozila[index-1];
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
