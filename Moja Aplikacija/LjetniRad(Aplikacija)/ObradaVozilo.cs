using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class ObradaVozilo
    {
        private List<Vozilo> Vozila;
        private Izbornik Izbornik;
        public ObradaVozilo()
        {
            Vozila = new List<Vozilo>();
        }
        public ObradaVozilo(Izbornik izbornik):this() 
        {
            this.Izbornik=izbornik;
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
                case 1:
                    PrikaziVozila();
                    break;
                case 2:
                    UnosNovogVozila();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaVozila();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeVozila();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s vozilima");
                    break;
               
            }
        }

        private void BrisanjeVozila()
        {
            BrisanjeVozila();
            int broj = Pomocno.UcitajBrojRaspon("Odaberi redni broj vozila za brisanje: ",
                "Nije dobro", 1, Vozila.Count());
            Vozila.RemoveAt(broj - 1);
        }

        private void PromjenaVozila()
        {
            int broj = Pomocno.UcitajBrojRaspon("Odaberi redni broj vozila za promjenu: ",
               "Nije dobro", 1, Vozila.Count());
            var s = Vozila[broj - 1];
            s.Sifra = Pomocno.UcitajCijeliBroj("Unesi sifru upita: (" + s.Sifra + "): ",
               "Unos mora biti pozitivni cijeli broj");
            s.Marka = Pomocno.UcitajString("Unesi nadimak osobe: (" + s.Marka + "): ",
            "Unos obavezan");
            s.Model = Pomocno.UcitajString("Unesi email: (" + s.Model + ") ",
            "Unos obavezan");
            s.Pogon = Pomocno.UcitajString("Unesi lozinku: (" + s.Pogon + "): ",
            "Unos obavezan");
            s.Godiste = Pomocno.UcitajCijeliBroj("Unesi godište vozila: (" + s.Kilometraza + "): ",

            s.Kilometraza = Pomocno.UcitajCijeliBroj("Unesi kilometažu vozila: (" + s.Kilometraza + "): ",
            "Unos obavezan"),
            s.Osobe = UcitajOsobu();
        }

        private void PrikaziVozila()
        {
            foreach(Vozilo vozilo in Vozila) 
            {
                Console.WriteLine("\t{0} ({1})",vozilo.Vrsta,vozilo.Marka,vozilo.Model,vozilo.Pogon,vozilo.Godiste,vozilo.Kilometraza,vozilo.Osobe);
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

        private List<Osoba> UcitajOsobu()
        {
            Izbornik.ObradaOsoba.PregledOsobe();
            int broj = Pomocno.UcitajBrojRaspon("Odaberi redni broj osobe za postavljanje na vozilu: ",
               "Nije dobro", 1, Izbornik.ObradaOsoba.Osobe.Count());
            return Izbornik.ObradaOsoba.Osobe[broj - 1];
        }
    }
}
