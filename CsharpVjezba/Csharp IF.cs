// Primjer: 1
using System.ComponentModel.Design;

int a = 0;
bool uvjet = a > 0;
if (uvjet)
{
    Console.WriteLine("Veće od 0");
}

if(a > 0)
{
    Console.WriteLine("Opet veće od 0");
}


// Primjer: 2
string grad = "Osijek";
if(grad == "Osijek")
{
    Console.WriteLine("Super");
}
else
{
    Console.WriteLine("Ok");
}

Console.WriteLine("***********************");

int b = 0;

if(grad != "Zagreb")
{
    b = b + 1;
} else if (grad == "Osijek")
{
    b += 2;
}
else
{
    b++;
} 
Console.WriteLine(b);

Console.WriteLine("***********************");

// Primjer: 3 IF ugnježđivanje

int c = 0;
int d = 2;

if (c > 0)
{
    if (d == 2)
    {
        Console.WriteLine("Oba uvijeta su zadovoljena");
    }
}

// Primjer: 4 Logički operatori

int e = 2;
int f = 4;

if(e==4 || f < 0)
{
    Console.WriteLine("Oba uvjeta su zadovoljena");
}


if (e == 2)
{
    Console.WriteLine("Prvi uvjet je zadovoljen");
}
else if (f <=6)
{
    Console.WriteLine("Drugi uvjet je zadovoljen");
}

Console.WriteLine("***********************");

// Primjer 5 parni i neparni brojevi
int g = 10;
if (g % 2 == 0)
{
    Console.WriteLine("Broj je paran");
}
else
{
    Console.WriteLine("Broj je neparan");
}

Console.WriteLine("***********************");

// Primjer 6
int broj = 0;
Console.Write("Unesite cijeli broj");
int.Parse(Console.ReadLine());
if (broj < 10)
{
    Console.WriteLine("Osijek");
}
else
{
    Console.WriteLine("Zagreb");
}

Console.WriteLine("***********************");

Console.Write("Unesite cijeli broj");
int.Parse(Console.ReadLine());
if (broj % 2 == 0)
{
    Console.WriteLine("Broj je paran");
}
else 
{
    Console.WriteLine("Broj je neparan");
}

