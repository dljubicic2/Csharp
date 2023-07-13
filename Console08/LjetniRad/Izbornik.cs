using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class Izbornik
    {
        private ObradaSmjer ObradaSmjer;
        public Izbornik() 
        {
            ObradaSmjer=new ObradaSmjer();
            ObradaPolaznik =new ObradaPolaznik();
            PozdravnaPoruka();
            PrikaziIzbornik();

        }

        
    }
    private void PozdravnaPoruka()
    {
        Console.WriteLine("*******************************************");
        Console.WriteLine("******** Edunova Conosle APP v 1.0 ********");
        Console.WriteLine("*******************************************");
    }
    private void PrikaziIzbornik()
    {
        Console.WriteLine("Glavni izbornik");
        Console.WriteLine("1. Smjerovi");
        Console.WriteLine("2. Polaznici");
        Console.WriteLine("3. Grupe");
        Console.WriteLine("4. Izlaz iz programa");
        Console.Write("Odaberite stavku izbornika");

        switch(Pomocno.UcitajBrojRaspon("Odaberite stavku izbornika: ",
            "Odabir mora biti 1 - 4", 1, 4))
        {
            case 1:
                ObradaSmjer.PrikaziIzbornik();
                Console.WriteLine("Rad s smjerovima");
                PrikaziIzbornik();
                break;
            case 2:
                Console.WriteLine("Rad s polaznicima");
                PrikaziIzbornik();
                break;
            case 3:
                Console.WriteLine("Rad s grupama");
                PrikaziIzbornik();
                break;
            case 4:
                Console.WriteLine("Hvala na korištenju doviđenja");
                break;

        }

    }
    
}
