using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojZavrsniRadV2
{
    internal class Upit :Entitet
    {
        public string Pitanje { get; set; }
        public List<Oglas> Oglasi { get; set; }
        public List<Osoba> Osobe { get; set; }
    }
}
