using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public string hello()
        {
            return "Hello world";
        }
        [HttpGet]
        [Route("pozdrav")]
        public string DrugaMetoda()
        {
            return "Pozdrav svijetu";
        }

        [HttpGet]
        [Route("pozdravParametar")]
        public string drugaMetoda1(string s)
        {
            return "Hello" + s;
        }
        [HttpGet]
        [Route("pozdravParametar2")]
        public string drugaMetoda2(string s = "", int i = 0)
        {
            return "Hello" + s + " " + i;
        }

        // Zadatak: 1
        // Kreirajte rutu /HelloWorld/zad1
        // koja ne prima parametre i vraća vaše ime

        [HttpGet]
        [Route("zad1")]
        public string trecaMetoda(string Domagoj)
        {
            return Domagoj;
        }

        // Zadatak: 2
        // Kreirajte rutu /HelloWorld/zad2
        // Koja prima dva broja i vraća njihov zbroj

        [HttpGet]
        [Route("zad2")]
        public int cetvrtaMetoda(int x, int y)
        {
            return x + y;
        }

        // Domaća Zadaća
        // kreirati rutu /HelloWorld/ciklicna
        // Koja prima dva parametra (x i y) a vraća 
        // cikličnu matricu kao dvodimenzionalni niz brojeva

        [HttpGet]
        [Route("ciklicna")]
        public IActionResult ciklicnaMatrica(int x, int y)
        {
            var m = new int[x, y];

            // moj kod koji to napuni!

            int n = 5;

            int[,] matrica = new int[n, n];
            int broj = 1;

            int redak = 0, stupac = 0;
            int maxRedak = n - 1, maxStupac = n - 1;
            int minRedak = 0, minStupac = 0;

            while (broj <= n * n)
            {

                for (int i = minStupac; i <= maxStupac; i++)
                {
                    matrica[minStupac, i] = broj++;
                }
                minRedak++;


                for (int i = minRedak; i <= maxRedak; i++)
                {
                    matrica[i, maxStupac] = broj++;
                }
                maxStupac--;


                for (int i = maxStupac; i >= minStupac; i--)
                {
                    matrica[maxRedak, i] = broj++;
                }
                maxRedak--;


                for (int i = maxRedak; i >= minRedak; i--)
                {
                    matrica[i, minStupac] = broj++;
                }
                minStupac++;
            }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrica[i, j] + "\t");
                }
                Console.WriteLine();
            }

            return new JsonResult(JsonConvert.SerializeObject(m));            
           
        }


        [HttpGet]
        [Route("sifra:int")]
        public string PozdravRuta(int sifra)
        {
            return "Hello" + sifra;
        }

        [HttpGet]
        [Route("{sifra:int}/{kategorija}")]
        public string PozdravRuta2(int sifra, string kategorija)
        {
            return "Hello" + sifra + " " + kategorija;
        }

        [HttpPost]
        public string DodavanjeNovog(string ime)
        {
            return "Dodao" + ime;
        }

        [HttpPut]
        public string Promjena(int sifra, string naziv)
        {
            return "Na šifri" + sifra + " " + naziv;
        }

        [HttpDelete]
        public bool Obrisao(int sifra)
        {
            return true;
        }



    }
        
}






