using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class ObradaUpit
    {
        public List<Upit> Upiti { get; }

        public ObradaUpit()
        {
            Upiti = new List<Upit>();
            if (Pomocno.DEV)
            {
                TestniPodaci();
            }
            



        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s upitima");
            Console.WriteLine("1. Pregled postojecih upita");
            Console.WriteLine("2. Unos novog upita");
            Console.WriteLine("3. Promjena postojeceg upita");
            Console.WriteLine("4. Brisanje upita");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.UcitajBrojRaspon("Odaberite stavku izbornika upita: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 1:
                    PrikaziUpite();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogUpita();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaUpita();
                    PrikaziIzbornik();
                    break;
                case 4:
                    if (Upiti.Count == 0)
                    {
                        Console.WriteLine("Nema upita za brisanje");
                    }
                    else
                    {
                        BrisanjeUpita();
                    }
                    BrisanjeUpita();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s upitima");
                    break;


            }
        }

        private void BrisanjeUpita()
        {
            PrikaziUpite();
            int broj = Pomocno.UcitajBrojRaspon("Odaberi redni broj upita za brisanje: ",
                "Nije dobro", 1, Upiti.Count());
            Upiti.RemoveAt(broj-1);


        }

        private void PromjenaUpita()
        {
            PrikaziUpite();
            int broj = Pomocno.UcitajBrojRaspon("Odaberi redni broj upita za promjenu: ",
                "Nije dobro", 1, Upiti.Count());
            var s = Upiti[broj - 1];
            s.Sifra = Pomocno.UcitajCijeliBroj("Unesite sifru upita ("+ s.Sifra+ "): ",
                "Unos mora biti pozitivni cijeli broj");
                s.Oglas = Pomocno.UcitajCijeliBroj("Unesite broj oglasa ("+ s.Oglas+ "): ",
                "Unos obavezan");
                s.Pitanje = Pomocno.UcitajString("Unesi pitanje: ("+ s.Pitanje+ ") ",
                "Unos obavezan");
                s.VrijemeUpita = Pomocno.UcitajCijeliBroj("Unesi vrijeme upita ("+ s.VrijemeUpita+ "): ",
                "Unos obavezan");
             
                s.Osoba = Pomocno.UcitajCijeliBroj("Unesi broj osobe ("+ s.Osoba + "): ",
                "Unos obavezan");




        }

        private void UnosNovogUpita()
        {
            var s = new Upit
            {
                Sifra = Pomocno.UcitajCijeliBroj("Unesite sifru upita: ",
                "Unos mora biti pozitivni cijeli broj"),
                Oglas = Pomocno.UcitajCijeliBroj("Unesite broj oglasa: ",
                "Unos obavezan"),
                Pitanje = Pomocno.UcitajString("Unesi pitanje: ",
                "Unos obavezan"),
                VrijemeUpita = Pomocno.UcitajCijeliBroj("Unesi vrijeme upita: ",
                "Unos obavezan"),
             
                Osoba = Pomocno.UcitajCijeliBroj("Unesi broj osobe: ",
                "Unos obavezan")
            };

        }

        private void PrikaziUpite()
        {
            Console.WriteLine("************************************************");
            Console.WriteLine("*****************Dostupni upiti*****************");
            Console.WriteLine("************************************************");
            int b = 1;
            foreach (Upit upit in Upiti)
            {
                Console.WriteLine("\t{0}. {1}",b++,upit.Pitanje);
            }
            Console.WriteLine("************************************************");

        }
        private void TestniPodaci()
        {
            Upiti.Add(new Upit { Pitanje = "Koliko je prešao?" });
            Upiti.Add(new Upit { Pitanje = "Da li je cijena fiksna?" });
            Upiti.Add(new Upit { Pitanje = "Kada se može doći pogledati vozilo?" });

        }





    }
}

