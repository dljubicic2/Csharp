using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojZavrsniRadV2
{
    internal class Osoba :Entitet
    {
        public string Nadimak { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public int BrojTelefona { get; set; }
        
    }
}
