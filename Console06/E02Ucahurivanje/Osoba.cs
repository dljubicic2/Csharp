using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02Ucahurivanje
{
    internal class Osoba
    {
        // Učahurivanje
        // Klasa će sakriti svoja svojstva
        private string ime;

        // Klasa će učiniti svojstvo putem tzv. get i set metoda
        public void setIme(string ime)
        {
            this.ime = ime;
        }

        public string getIme()
        {
            return this.ime;
        }

        // U nastavku nastave koristi će mo ovaj način za učahurivanje
        public string prezime { get; set; }
        public Osoba() { }
    }
    
    
}
