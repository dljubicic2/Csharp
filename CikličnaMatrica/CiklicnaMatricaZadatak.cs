// Prvi korak
using System.Collections.Concurrent;

int stupaca, redaka;
Console.Write("Unesite broj stupaca");
stupaca=int.Parse(Console.ReadLine());
Console.Write("Unesite broj redaka");
redaka=int.Parse(Console.ReadLine());
int[,] matrica = new int[stupaca,redaka];

for (int i = 0; i<stupaca; i++)
{
    for(int j = 0; j<redaka; j++)
    {
        Console.Write(matrica[i,j]+" ");
    }
    Console.WriteLine();
}

// Drugi korak
int a = 1;
Console.WriteLine("***************************");
matrica[stupaca - 1, redaka - 1] = a++;
matrica[stupaca - 1, redaka - 2] = a++;
matrica[stupaca - 1, redaka - 3] = a++;
matrica[stupaca - 1, redaka - 4] = a++;
matrica[stupaca - 1, redaka - 5] = a++;

for(int i =1; i<=stupaca; i++)
{
    matrica[redaka - 1, stupaca - i] = a++;
}

for(int i =0; i<stupaca; i++)
{
    for(int j =0; j<redaka; j++)
    {
        Console.Write(matrica[i,j]+" ");
    }
    Console.WriteLine();
}

Console.WriteLine("***************************");

// Treći korak
for (int i = redaka-2; i>=0; i--)
{
    matrica[i, 0] = a++;
}

for(int i =0; i<stupaca; i++)
{
    for(int j =0; j < redaka; j++)
    {
        Console.Write(matrica[i,j]+" ");
    }
    Console.WriteLine();
}
