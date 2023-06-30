// Zadatak: 1
// Zbroj prvih 100 brojeva
// Koristeći for petlju
using System.Runtime.InteropServices;

int zbroj = 0;
for (int i = 1; i<=100; i++)
{
    zbroj += i;
}
Console.WriteLine(zbroj);

Console.WriteLine("************************************");

// Zadatak:2
// Ispiši sve parne brojeve od 1 do 57
// Koristeći for petlju
for (int i =1; i<=57; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }
}

Console.WriteLine("************************************");

// Zadatak: 3
// Ispiši zbroj svih parnih brojeva između 2 i 18
// Koristeći for petlju
int zbroj2 = 0;
for (int i =2; i<=18; i++)
{
    if (i % 2 == 0)
    {
        zbroj2 += i;
    }
    
    
}
Console.WriteLine(zbroj2);


Console.WriteLine("************************************");


// Zadatak:4
// Program učitava koliko će se brojeva unijeti
// Program učitava brojeve za provjeru
// Program isipisuje najveći uneseni broj
// Koristiti while petlju
Console.Write("Unesi koliko će se brojeva unjeti");
int brojeva=int.Parse(Console.ReadLine());
int broj;
int najveci = int.MinValue;
for(int i = 1; i<brojeva; i++)
{
    Console.WriteLine("Unesi {0}. broj:", i+1);
    broj=int.Parse(Console.ReadLine());
    if (broj > najveci)
    {
        najveci = broj;
    }
}
Console.WriteLine("Najveci broj je {0}", najveci);

Console.WriteLine("************************************");

// Zadatak: 5
// Korisnik unosi 2 cijela broja
// Program ispisuje zbroj svih parnih brojeva između ta dva broja
// Koristiti for petlju

int zbroj3 = 0;
Console.Write("Unesite prvi cijeli broj");
int a = int.Parse((string)Console.ReadLine());
Console.Write("Unesite drugi cijeli broj");
int b = int.Parse((string)Console.ReadLine());
int manji = a < b ? a : b;
int veci = a > b ? b : a;
for (int i=manji; i<=veci; i++)
{
    zbroj3 = i % 2 == 0 ? zbroj + i : zbroj3;
}
Console.WriteLine(zbroj3);

Console.WriteLine("************************************");

// Zadatak: 6
// Program unosi broj između 1 i 10
// Program isipisuje navedeni broj
// Koristiti while petlju

while (true)
{
    Console.WriteLine("Unesi cijeli broj");
    b=int.Parse((string)Console.ReadLine());
    if (b >0 && b <= 10)
    {
        break;
    }
    Console.WriteLine("Morate unijeti broj između 1 i 10");
}
Console.WriteLine("Unesi broj je: {0}", b);

// Zadatak 8
// Napišite program koji pomoću while petlje ispisuje svaki treći broj između 2 i 97
int c = 2;
while (c<=97)
{
    Console.WriteLine(c);
    c = c + 3;
}

Console.WriteLine("************************************");

// Zadatak: 9
// Zbrojite prvih 100 brojeva sa while petljom
zbroj = 0;
int d = 1;
while (d <= 100)
{
    zbroj += d;
}
Console.WriteLine(zbroj);

// Zadatak: 10
// Korisnik unosi 2 cijela broja između 10 i 20
// Program ispisuje sve parne brojeve između unesenih brojeva
// Koristiti do petlju

int pb = 0;
int db = 0;
do
{
    Console.Write("Unesite prvi cijeli broj između 10 i 20");
    pb = int.Parse(Console.ReadLine());
    if (pb >= 10 && pb <= 20)
    {
        break;
    }
    Console.WriteLine("Broj nije između 10 i 20");
    }
    while (true);
    do
    {
        Console.Write("Unesite drugi cijeli broj između 10 i 20");
        db=int.Parse(Console.ReadLine());
        if(db>=10 && db <= 20)
    {
        break;
    }
    Console.WriteLine("Uneseni broj nije između 10 i20");
}
    while (true);
int manji2 = pb < db ? pb : db;
int veci2 = pb > db ? db : pb;
int i = manji;
do
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }
}
while (++i <= veci2);
    
  







