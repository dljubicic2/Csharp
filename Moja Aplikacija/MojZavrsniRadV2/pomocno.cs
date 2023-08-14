using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MojZavrsniRadV2
{
    internal class pomocno
    {
        public static bool dev;
        internal static decimal UcitajDecimalniBroj (string poruka, string greska)
        {
            decimal d;
            while (true)
            {
                Console.WriteLine(poruka);
                try
                {
                    d = int.Parse(Console.ReadLine());
                    if (d > 0)
                    {
                        return d;
                    }
                    Console.WriteLine(greska);
                }catch (Exception ex) 
                {
                    Console.WriteLine(greska);
                }
            }
        }
        internal static bool UcitajBool (string poruka)
        {
            Console.WriteLine(poruka);
            return Console.ReadLine().Trim().ToLower().Equals("da") ? true : false;
        }
        internal static DateTime UcitajDatum(string poruka, string greska)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(poruka);
                    return DateTime.Parse(Console.ReadLine());
                }catch (Exception ex) 
                {
                    Console.WriteLine(greska);
                }
            }
        }
        internal static int UcitajBrojRaspon(string poruka, string greska, int pocetak, int kraj)
        {
            int b;
            while(true)
            {
                Console.WriteLine(poruka);
                try
                {
                    b = int.Parse(Console.ReadLine());
                    if(b>=pocetak && b<=kraj)
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
        internal static string UcitajString(string poruka, string greska)
        {
            string s = " ";
            while(true)
            {
                Console.WriteLine(poruka);
                s = Console.ReadLine();
                if(s!=null && s.Trim().Length > 0 )
                {
                    return s;
                }
                Console.WriteLine(greska);
            }
        }
        internal static int UcitajCijeliBroj(string poruka, string greska)
        {
            int a;
            while (true)
            {
                Console.WriteLine(poruka);
                try
                {
                    a = int.Parse(Console.ReadLine());
                    if (a > 0)
                    {
                        return a;
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

