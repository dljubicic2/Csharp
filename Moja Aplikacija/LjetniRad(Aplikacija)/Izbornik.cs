using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class Izbornik
    {
        private ObradaUpit ObradaUpit;
        public ObradaOsoba ObradaOsoba { get; }
        public ObradaVozilo ObradaVozilo { get; }
        private ObradaOglas ObradaOglas;
        public Izbornik() 
        {
            ObradaUpit = new ObradaUpit();
            ObradaOsoba = new ObradaOsoba();
            ObradaVozilo = new ObradaVozilo(this);
            ObradaOglas = new ObradaOglas();
            PozdravnaPoruka();
            PrikaziIzbornik();
        }

        private void PrikaziIzbornik()
        {
            Console.WriteLine("Glavni izbornik");
            Console.WriteLine("1. Upiti");
            Console.WriteLine("2. Osobe");
            Console.WriteLine("3. Oglasi");
            Console.WriteLine("4. Vozila");
            Console.WriteLine("5. Izlaz iz programa");
            
            switch(Pomocno.UcitajBrojRaspon("Odaberite stavku izbornika: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 1:
                    ObradaUpit.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 2:
                    ObradaOsoba.PrikaziIzbornik();
                    PrikaziIzbornik();
                   
                    break;
                case 3:
                    Console.WriteLine("Rad s oglasima");
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObradaVozilo.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Hvala na korištenju, doviđenja");
                    break;


            }
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("*** Edunova Console APP AUTO OGLASNIK ***");
            Console.WriteLine("*****************************************");
        }
    }
}

