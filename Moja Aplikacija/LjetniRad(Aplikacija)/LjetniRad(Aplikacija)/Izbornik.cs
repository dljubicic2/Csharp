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
        public Izbornik() 
        {
            ObradaUpit = new ObradaUpit();
            PozdravnaPoruka();
            PrikaziIbornik();
        }

        private void PrikaziIbornik()
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
                    PrikaziIbornik();
                    break;
                case 2:
                    Console.WriteLine("Rad s osobama");
                    PrikaziIbornik();
                    break;
                case 3:
                    Console.WriteLine("Rad s oglasima");
                    PrikaziIbornik();
                    break;
                case 4:
                    Console.WriteLine("Rad s vozilima");
                    PrikaziIbornik();
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

