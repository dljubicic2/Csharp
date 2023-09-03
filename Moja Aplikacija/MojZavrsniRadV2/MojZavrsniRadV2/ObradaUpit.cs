using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojZavrsniRadV2
{
    internal class ObradaUpit
    {
        public List<Upit> Upiti { get; set; }
        private Izbornik Izbornik { get; set; }

        public ObradaUpit() 
        {
            Upiti = new List<Upit>();
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s oglasima");
            Console.WriteLine("1. Pregled postojećih upita");
            Console.WriteLine("2. Unos novog upita");
            Console.WriteLine("3. Brisanje upita");
            Console.WriteLine("4. Promjena postojećih upita");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (pomocno.UcitajBrojRaspon("Izaberite stavku izbornika oglas: ",
                "Odabir mora biti od 1 - 5", 1, 5))
            {
                case 1:
                    PregledPostojecihUpita();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogUpita();
                    PrikaziIzbornik();
                    break;
                case 3:
                    BrisanjeUpita();
                    PrikaziIzbornik();
                    break;
                case 4:
                    PromjenaPostojecegUpita();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s upitima");
                    break;
            }
        }

        private void PromjenaPostojecegUpita()
        {
            PregledPostojecihUpita();
            int index = pomocno.UcitajBrojRaspon("Odaberite broj upita za promjenu: ",
              "Nije dobar odabir!", 1, Upiti.Count());
            var u = Upiti[index - 1];

            u.Sifra = pomocno.UcitajCijeliBroj("Unesite cijeli pozitivan broj ("+ u.Sifra +"):",
               "Unos mora biti pozitivan broj!");
            u.Pitanje = pomocno.UcitajString("Unesite pitanje ("+ u.Pitanje +"):",
                "Unos obavezan!");
            u.Oglasi = PostaviOglase();
            u.Osobe = PostaviOsobe();

        }

        private void BrisanjeUpita()
        {
            PregledPostojecihUpita();
            int index = pomocno.UcitajBrojRaspon("Odaberite broj upita za brisanje: ",
                "Nije dobar odabir!", 1, Upiti.Count());
            Upiti.RemoveAt(index-1);
        }

        private void PregledPostojecihUpita()
        {
            int d = 1;
            foreach(Upit upit in Upiti)
            {
                Console.WriteLine("{0} {1}",d++,upit);
            }
        }

        private void UnosNovogUpita()
        {
            var u = new Upit();

            u.Sifra = pomocno.UcitajCijeliBroj("Unesite cijeli pozitivan broj: ",
                "Unos mora biti pozitivan broj!");
            u.Pitanje = pomocno.UcitajString("Unesite pitanje: ",
                "Unos obavezan!");
            u.Oglasi = PostaviOglase();
            u.Osobe = PostaviOsobe();
            Upiti.Add(u);
        }

        private List<Osoba> PostaviOsobe()
        {
            List<Osoba> osobe = new List<Osoba>();
            while(pomocno.UcitajBool("Želite li dodati osobu? (da ili bilo što drugo za ne):"))
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

        private List<Oglas> PostaviOglase()
        {
            List<Oglas> oglasi = new List<Oglas>();
            while (pomocno.UcitajBool("Želite li dodati upit? (da ili bilo što drugo za ne):"))
            {
                oglasi.Add(PostaviOglas());
            }
            return oglasi;
        }

        private Oglas PostaviOglas()
        {
            Izbornik.ObradaOglas.PregledPostojecihOglasa();
            int index = pomocno.UcitajBrojRaspon("Odaberite redni broj oglasa: ",
                "Nije dobar odabir!", 1, Izbornik.ObradaOglas.Oglasi.Count());
            return Izbornik.ObradaOglas.Oglasi[index - 1];
        }
    }
}
