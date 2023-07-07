// 1. Korak
int redaka, stupaca;

Console.Write("Unesite broj redaka");
redaka=int.Parse(Console.ReadLine());

Console.Write("Unesite broj stupaca");
stupaca=int.Parse(Console.ReadLine());

int[,] matrica = new int[redaka, stupaca];  // Tablica je napravljena

// 2. Korak
int a = 1; // Brojac
for(int i =1; i<=stupaca; i++)
{
    matrica[redaka - 1, stupaca - i] = a++;
}

for(int i =0; i<redaka; i++)  // Provjera
{
    for(int j =0; j<stupaca; j++)
    {
        Console.Write(matrica[i,j]+"  ");
    }
    Console.WriteLine();
}

Console.WriteLine("********************************");

// 3. Korak
for(int i = redaka -2; i>0; i--)
{
    matrica[i,0] = a++;
}

for (int i = 0; i < redaka; i++)  // Provjera
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] + "  ");
    }
    Console.WriteLine();
}

Console.WriteLine("*************************************");

// 4. Korak
for(int i =1; i<stupaca; i++)
{
    matrica[0,i] = a++;
}

for (int i = 0; i < redaka; i++)  // Provjera
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] + "  ");
    }
    Console.WriteLine();
}

Console.WriteLine("*************************");

// 5. Korak
for(int i =1; i<=redaka-2; i++)
{
    matrica[i, 4] = a++;
}

for (int i = 0; i < redaka; i++)  // Provjera
{
    for (int j = 0; j < stupaca; j++)
    { 
        Console.Write(matrica[i, j] + "  ");
    }
    Console.WriteLine();
}

Console.WriteLine("*************************************");

// 6. Korak
for(int i =3; i>=stupaca-4; i--)
{
    matrica[3,i] = a++;
}

for (int i = 0; i < redaka; i++)  // Provjera
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] + "  ");
    }
    Console.WriteLine();
}

Console.WriteLine("******************************************");

// 7. Korak
for(int i =2; i>=redaka-4; i--)
{
    matrica[i, 1] = a++;
}

for (int i = 0; i < redaka; i++)  // Provjera
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] + "  ");
    }
    Console.WriteLine();
}

Console.WriteLine("********************************************");

// 8. Korak
for(int i=2; i<=stupaca-2; i++)
{
    matrica[1,i] = a++;
}

for (int i = 0; i < redaka; i++)  // Provjera
{
    for (int j = 0; j < stupaca; j++)
    {
        Console.Write(matrica[i, j] + "  ");
    }
    Console.WriteLine();
}

Console.WriteLine("**************************************************");

// 9. Korak
for(int i =3; i>=stupaca-3; i--)
{
    matrica[2,i] = a++;
}

string ispis;

for(int i =0; i<redaka; i++)
{
    for(int j=0; j<stupaca; j++)
    {
        ispis="  " + matrica[i,j];
        Console.Write(ispis[^3..]);
    }
    Console.WriteLine();
}