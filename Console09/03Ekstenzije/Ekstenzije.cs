using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _03Ekstenzije
{
    internal class Ekstenzije
    {
        public static int brojPonavljanja(this string s, char z )
        {
            int u = 3;
            // Domaća zadaća:
            // Na danom stringu s prebrojiti koliko ima znakova
            // Primljenog kroz parametar z
            // Anamarija a vraća 3
            return u;
        }
        public static void ObradiPosao(this ISucelje sucelje)
        {
            sucelje.Posao();
        }
    }
}
