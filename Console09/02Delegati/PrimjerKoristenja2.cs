﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Delegati
{
    internal class PrimjerKoristenja2
    {
        public PrimjerKoristenja2()
        {
            ObradaSmjer os = new();
            os.IspisSmjer(nijeBitno);
        }
        private void nijeBitno(Smjer s)
        {
            Console.WriteLine("Drugi način: " + s.Naziv);
        }
    }
}
