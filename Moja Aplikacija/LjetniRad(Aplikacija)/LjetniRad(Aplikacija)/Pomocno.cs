using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad_Aplikacija_
{
    internal class Pomocno
    {
        public static int UcitajBrojRaspon(string poruka, string greska, int pocetak, int kraj)
        {
            int b;
            while (true)
            {
                Console.Write(poruka);
                try
                {
                    b = int.Parse(Console.ReadLine());
                    if (b >= pocetak && b <= kraj)
                    {
                        return b;
                    }
                    Console.WriteLine(greska);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(greska);
                }
            }

        }
    }

}
           
            
        
    

