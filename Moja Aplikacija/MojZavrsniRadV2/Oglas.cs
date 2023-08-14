using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MojZavrsniRadV2
{
    internal class Oglas :Entitet
    {
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public List<Osoba> Osobe { get; set; }
        public List<Vozilo> Vozila { get; set; }
    }
}
