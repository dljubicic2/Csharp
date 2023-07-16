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
        public Izbornik() 
        {
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
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("*** Edunova Console APP AUTO OGLASNIK ***");
            Console.WriteLine("*****************************************");
        }
    }
}

