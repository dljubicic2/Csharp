using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Lambda
{
    internal class Smjer
    {
        public int Sifra { get; set; }
        public string? Naziv { get; set; } // ? Označava da Naziv može biti null

        public override string ToString()
        {
            // return Naziv == null ? "" : Naziv;

            return Naziv ?? ""; // Ova linija je ekvivalent gornjoj!
        }
    }
}
