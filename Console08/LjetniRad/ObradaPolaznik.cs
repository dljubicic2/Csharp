using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class ObradaPolaznik
    {
        public List<Polaznik> polaznici { get;  }
        public ObradaPolaznik() 
        {
            polaznici= new List<Polaznik>();
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s polaznicima");
            Console.WriteLine("1. Pregled postojecih polaznika");
            Console.WriteLine("2. Unos novog polaznika");
            Console.WriteLine("3. Promjena postojeceg polanzika ");
            Console.WriteLine("4. Brisanje polaznika");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.UcitajBrojRaspon("Odaberite stavku izbornika polaznika ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 1:
                    UcitajPolaznika();
                    PrikaziIzbornik();
                    break;
                case 2:
                    PregledPolaznika();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s polaznicima");
                    break;
            }
        }

        private void PregledPolaznika()
        {
            foreach(Polaznik polaznik in polaznici)
            {
                Console.WriteLine(polaznik);
            }
        }

        private void UcitajPolaznika()
        {
            var p =new Polaznik();
            p.Ime = Pomocno.UcitajString("Unesi ime polaznika: ", "Ime obavezno");
            p.Prezime = Pomocno.UcitajString("Unesi Prezime polaznika: ", "Prezime obavezno");
        }
    }
    
}
