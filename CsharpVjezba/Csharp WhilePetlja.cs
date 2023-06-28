// Primjer: 1
for(int i = 0; i<10; i++)
{
    Console.WriteLine("Nisam ušao");
}

Console.WriteLine("********************************");

// Primjer: 2
// U for se ne mora ući!
int b = 0;
while (b < 10)
{
    Console.WriteLine("Nisam ušao");
    {
        break;
    }
}

Console.WriteLine("********************************");

// Primjer: 3 logički operatori
int t = 2;
while(t==2 && b < 10)
{
    Console.WriteLine(++b);
}

Console.WriteLine("********************************");

// Zadatak: 1
// Program unosi broj između između 1 i 10
// Program ispisuje uneseni broj
while (true)
{
    Console.Write("Unesi cijeli broj");
    b = int.Parse(Console.ReadLine());
    if (b > 0 && b <= 10)
    {
        break;
    }
    Console.WriteLine("Morate unijeti broj između 1 i 10");
}
Console.WriteLine("Uneseni broj je: {0}", b);



Console.WriteLine("********************************");



// Zadatak: 2
// Napiši program koji pomoću while petlje ispisuje svaki treći broj između 2 i 97
int pb = 2;
while (pb < 97)
{
    Console.WriteLine(pb);
    pb = pb + 3;
}


Console.WriteLine("********************************");

// Zadatak: 3
// Zbrojite svih 100 brojeva sa while petljom
int zbroj = 0;
int a = 0;
while(a++ < 100)
{
    zbroj += b;
}
Console.WriteLine(zbroj);




