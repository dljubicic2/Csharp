Console.WriteLine("1. ***************");
for (int i = 0; i < 10; i++) 
{
    Console.WriteLine("Osijek");
}

Console.WriteLine("2.. ***************");
int j = 0;
for(int j2 = 10; j > 0; j--)
{
    Console.WriteLine("Edunova");
}

Console.WriteLine("3. ***************");
for (int i = 0; i < 10; i = i + 2)
{
    Console.WriteLine("CSHARP");
}


Console.WriteLine("4. ***************");   // Mijenjanje vrijednosti
for (int i =0; i<10; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("5. ***************");
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine("i+1");
}

Console.WriteLine("6. ***************");
for (int i = 1; i < 10; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("7. ***************"); // Zbroj prvih 100 brojeva
int zbroj = 0;
for (int i = 1; i <= 100; i++)
{
    zbroj += i;
}
Console.WriteLine(zbroj);

// Zadatak: 1 Ispiši sve parne brojeve od 1 do 57
Console.WriteLine("8. ***************");
for(int i =1; i <= 57; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }
}

// Zadatak 2: Ispiši zbroj svih parnih brojeva od 2 do 18
Console.WriteLine("9. ***************");
for(int i =2; i <=18; i++)
{
    zbroj += 1;
    {
        if(i % 2 == 0)
        {
            Console.WriteLine(zbroj);
        }
    }
}



