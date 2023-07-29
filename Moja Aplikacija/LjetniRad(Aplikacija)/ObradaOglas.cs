using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class ObradaOglas
    {
        private List<Oglas> Oglasi;
        private Izbornik Izbornik;
        public ObradaOglas() 
        {
            Oglasi = new List<Oglas>();
        }
        private void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s oglasima");
            Console.WriteLine("1. Pregled postojecih oglasa");
            Console.WriteLine("2. Unos novog oglasa");
            Console.WriteLine("3. Promjena postojeceg oglasa");
            Console.WriteLine("4. Brisanje oglasa");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.UcitajBrojRaspon("Odaberite stavku izbornika vozila: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 1:
                    
                    PrikaziOglase();
                    break;
                case 2:
                    UnosNovogOglasa();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaOglasa();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeOglasa();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s oglasima");
                    break;


            }
        }

        private void BrisanjeOglasa()
        {
            BrisanjeOglasa();
            int broj = Pomocno.UcitajBrojRaspon("Odaberi redni broj vozila za brisanje: ",
                "Nije dobro", 1, Oglasi.Count());
            Oglasi.RemoveAt(broj - 1);
        }

        private void PromjenaOglasa()
        {
            int broj = Pomocno.UcitajBrojRaspon("Odaberi redni broj oglasa za promjenu: ",
              "Nije dobro", 1, Oglasi.Count());
            var s = Oglasi[broj - 1];
            s.Sifra = Pomocno.UcitajCijeliBroj("Unesi sifru upita: (" + s.Sifra + "): ",
               "Unos mora biti pozitivni cijeli broj");
            s.Vozila = UnosNovogVozila();
            s.Naslov = Pomocno.UcitajString("Unesi naslov oglasa: (" + s.Naslov + ") ",
            "Unos obavezan");
            s.Opis = Pomocno.UcitajString("Unesi opis oglasa: (" + s.Opis + "): ",
            "Unos obavezan");
            s.Slika = Pomocno.UcitajString("Unesi sliku vozila: (" + s.Slika + "): ",
            s.Osobe = UcitajOsobu(),

            s.Cijena = Pomocno.UcitajCijeliBroj("Unesi cijenu vozila: (" + s.Cijena + "): ",
            "Unos obavezan");
            
        }

        private void PrikaziOglase()
        {
            foreach (Oglas Oglas in Oglasi)
            {
                Console.WriteLine("\t{0} ({1})", Oglas.Vozila, Oglas.Naslov, Oglas.Opis, Oglas.Slika, Oglas.Osobe, Oglas.Cijena);
            }
        }

        private void UnosNovogOglasa()
        {
            var g = new Oglas();
            g.Vozila = UnosNovogVozila();
               
            g.Naslov = Pomocno.UcitajString("Unesite naslov oglasa: ",
                "Unos obavezan");
            g.Opis = Pomocno.UcitajString("Unesite opis vozila:",
                "Unos obavezan");
            g.Slika = Pomocno.UcitajString("Ucitajte sliku vozila: ",
                "Unos obavezan");
            g.Osobe = UcitajOsobu();

            g.Cijena = Pomocno.UcitajCijeliBroj("Unesite cijenu vozila: ",
                "Unos obavezan");

            Oglas.Add(g);


        }
        private List<Osoba> UcitajOsobu()
        {
            Izbornik.ObradaOsoba.PregledOsobe();
            int broj = Pomocno.UcitajBrojRaspon("Odaberi redni broj osobe za postavljanje na oglas: ",
               "Nije dobro", 1, Izbornik.ObradaOsoba.Osobe.Count());
            return Izbornik.ObradaOsoba.Osobe[broj - 1];
        }
        private List<Vozilo> UnosNovogVozila()
        {
            Izbornik.ObradaOsoba.PregledOsobe();
            int broj = Pomocno.UcitajBrojRaspon("Odaberi redni broj vozila za postavljanje na vozilu: ",
               "Nije dobro", 1, Izbornik.ObradaVozilo.Vozila.Count());
            return Izbornik.ObradaVozilo.Vozila[broj - 1];
        }
    }
    
    
    

    
    
}


