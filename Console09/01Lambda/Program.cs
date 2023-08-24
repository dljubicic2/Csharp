// Vježba:
// Napiši metodu tipa int naziva Klasicna Metoda
// Koja prima parametar tipa int
// I vraća primljeni broj na kvadrat


using _01Lambda;

int KlasicnaMetoda(int b)
{
    return b * b;
}

// U konzolu ispišite poziv definirane metode s parametrom 5

Console.WriteLine(KlasicnaMetoda(5));

// Vrste lambdi:
// 1. Lambda expression:
 
var kvadrat = (int b) => b*b;
Console.WriteLine(kvadrat(5));

// 2. Lambda statement:

var algoritam = (int x, int y) =>
{
    var t = x++ + --y;
    return x + y - t;
};
Console.WriteLine(algoritam(1,2));


// Preborijite koliko ima brojeva u nizu s vrijednošću 
int[] brojevi = { 2, 3, 4, 3, 2, 3, 4, 3 };

int ukupno  = 0;
foreach (int k in brojevi)
{
    if (k == 3)
    {
        ukupno++;
    }

}
Console.WriteLine(ukupno);

Console.WriteLine("*****************************");

// Primjer s lambdom

Console.WriteLine(brojevi.Count(b=>b==3));

Console.WriteLine("*****************************");

// Primjer s for petljom

for (int i =0; i< brojevi.Length; i++)
{
    Console.WriteLine(brojevi[i]);
}

Console.WriteLine("*****************************");

// Foreach primjer

foreach (int k in brojevi)
{
    Console.WriteLine(k);
}

Console.WriteLine("*****************************");

// Primjer s Array

Array.ForEach(brojevi, Console.WriteLine);

Console.WriteLine("*****************************");

// Ispiši svaki broj uvećan za 1

Array.ForEach(brojevi, b =>
{
    Console.WriteLine(b + 1);
});

Console.WriteLine("*****************************");

// Deklarijate listu slijedećim elementima
// 2,3,4,5,4

var Lista = new List<int>() {2,3,4,5,4};
Lista.ForEach(Console.WriteLine);

Console.WriteLine("*****************************");

var smjerovi = new List<Smjer>()
{
    new () {Naziv = "Prvi", Sifra =1},
    new () {Naziv = "Drugi", Sifra =2}
};
smjerovi.ForEach(Console.WriteLine);

Console.WriteLine("*****************************");

// Lambda primjer

smjerovi.ForEach(s =>
{
    int b = s.Sifra + new Random().Next();
    Console.WriteLine(s.Naziv + " " + b);
});

string s = null;
Console.WriteLine(s?.Replace("a","b"));

