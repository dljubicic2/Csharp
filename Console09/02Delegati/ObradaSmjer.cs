using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _02Delegati
{
    internal class ObradaSmjer
    {
        private readonly List<Smjer> smjerovi;
        
        public ObradaSmjer()
        {
            smjerovi = new()
            {
                new () {Sifra=1, Naziv="Prvi"},
                new () {Sifra=2, Naziv="Drugi"}
            };
        }
        public void IspisSmjer(IspisPozivSmjer poziv)
        {
            smjerovi.ForEach(s => poziv(s));
        }
        public void IspisPozivSmjerAction(Action<Smjer> poziv)
        {
            smjerovi.ForEach(s => poziv(s));
        }

        
    }
    
}
