using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02Ucahurivanje
{
    internal class Smjer
    {
        public int Sifra { get; set; }
        public string naziv { get; set; }
        public decimal cijena { get; set; }
        public decimal upisnina { get; set; }
        public bool certificiran { get; set; }

        public Smjer() { 
        
        }
    }
}
