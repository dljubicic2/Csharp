using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class ObradaUpit
    {
        public List<Upit> Upiti {get;}

        public ObradaUpit() 
        {
            Upiti = new List<Upit>();
            
            
            
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s upitima");
            Console.WriteLine("1. Pregled postojecih upita");
            Console.WriteLine("2. Unos novog upita");
            Console.WriteLine("3. Promjena postojeceg upita");
            Console.WriteLine("4. Brisanje upita");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch(Pomocno.UcitajBrojRaspon("Odaberite stavku izbornika upita: ",
                "Odabir mora biti 1-5", 1,5))
                {
                case 1:
                    PrikaziUpite();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s upitima");
                    break;
                    

            }
        }

        private void PrikaziUpite()
        {
            foreach(Upit upit in Upiti)
            {
                Console.WriteLine(upit.Pitanje);
            }
        }
    }
    
    
        
        
    
}

