using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01KlasaObjekt
{
    // Objekt je instanca/pojavnost klase
    // Klasa je opisnik objekta.
    internal class Osoba
    {
        // Ovako se ne smiju deklarirati svojstva uklasi
        // Zato što nije zadovoljen OOP princip učahirivanja
        /*
        public string ime;
        internal string prezime;
        int godine;
        */

        // Zadnja vrsta metoda: konsturktor
        // poziva se u trenutku instanciranja novog objekta (ključna riječ new)
        // Ona nije obavezna! Ako nije definirana poziva se konstruktor iz 
        public Osoba() 
       {
            Console.WriteLine("Konstruktor klase Osoba");
        }
        public Osoba (string ime)
        {
            Console.WriteLine(ime);
        }

    }
}
