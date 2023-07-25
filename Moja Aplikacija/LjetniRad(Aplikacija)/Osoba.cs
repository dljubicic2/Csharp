using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class Osoba : Entitet
    {
       
        public string Nadimak { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public int BrojTelefona { get; set; }

        public override string ToString()
        {
            return Nadimak+ " " + Email;
        }

    }
}
