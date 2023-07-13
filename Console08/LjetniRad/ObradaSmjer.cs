using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class ObradaSmjer
    {
        
       
        public List<Smjer>smjerovi { get; }
        public ObradaSmjer() 
        {
            smjerovi = new List<Smjer>();
            TesniPodaci();
         
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s smjerovima");
            Console.WriteLine("1. Pregled postojecih smjerova");
            Console.WriteLine("2. Unos novog smjera");
            Console.WriteLine("3. Promjena postojeceg smjera ");
            Console.WriteLine("4. Brisanje smjera");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch(Pomocno.UcitajBrojRaspon("Odaberite stavku izbornika smjera ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 1:
                    PrikaziSmjerove();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogSmjera();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s smjerovima");
                    break;
            }
        }

        private void UnosNovogSmjera()
        {
            var s =new Smjer();
            s.Sifra = Pomocno.UcitajCijeliBroj("Unesite naziv smjera",
                "Unos mora biti cijeli pozitivni broj");
            s.Naziv = Pomocno.UcitajString("Unesite naziv smjera",
                "Unos obavezan");
            s.Trajanje = Pomocno.UcitajCijeliBroj("Unesite trajanje smjera u satima",
                "Unos mora biti cijeli pozitivan broj");
            smjerovi.Add(s);

        }

        private void PrikaziSmjerove()
        {
            foreach(Smjer smjer in smjerovi)
            {
                Console.WriteLine(smjer.Naziv);
            }
        }
        private void TesniPodaci()
        {
            smjerovi.Add(new Smjer { Naziv: "Web programiranje" });
        }
    }
    
}
