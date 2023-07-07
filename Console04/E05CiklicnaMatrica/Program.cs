// Korak: 1
int Redaka, Stupaca;
Console.Write("Unesite broj stupaca");
Stupaca=int.Parse(Console.ReadLine());
Console.Write("Unesite broj redaka");
Redaka=int.Parse(Console.ReadLine());
int[,] matrica = new int[Redaka,Stupaca];

for(int i=0; i < Stupaca; i++)
{
    for(int j=0; j < Redaka; j++)
    {
        Console.Write(matrica[i,j]+" ");
    }
    Console.WriteLine();
}

Console.WriteLine("***********************");

// Korak: 2
int a = 1;
for ( int i =1; i<=Stupaca; i++)
{
    matrica[Redaka-1, Stupaca -i] = a++;
}

for (int i =0; i<Stupaca ; i++)  // Provjera
{
    for (int j=0; j<Redaka; j++)
    {
        Console.Write(matrica[i,j]+" ");
    }
    Console.WriteLine();
}

Console.WriteLine("***********************");

// Korak: 3
for(int i =Redaka-2;i>=0; i--)
{
    matrica[i,0] = a++;
}

for (int i =0; Stupaca>0; i++)  // Provjera
{
    for(int j =0; j < Redaka; j++)
    {
        Console.Write(matrica[i,j]+ " ");
    }
    Console.WriteLine();
}

Console.WriteLine("***********************");

// Korak: 4
for (int i =1; i<Stupaca; i++)
{
    matrica[0,1] = a++;
}

for(int i =0; i<Redaka; i++)  // Provjera
{
    for(int j =0; j < Redaka; j++)
    {
        Console.Write(matrica[i,j]+" ");
    }
    Console.WriteLine();
}

Console.WriteLine("***********************");

// Korak: 5
for(int i =1; i <=Redaka -2; i++)
{
    matrica[i, 4] = a++;
}

for(int i =0; i<Stupaca; i++)  // Provjera
{
    for(int j =0; j<Redaka; j++)
    {
        Console.Write(matrica[i,j]+" ");
    }
    Console.WriteLine();
}

Console.WriteLine("***********************");

// Korak: 6
for(int i = 3; i >= Stupaca - 4; i--)
{
    matrica[3,1]= a++;
}

for(int i =0; i< Stupaca ; i++)  // Provjera
{
    for(int j =0; j<Redaka; j++)
    {
        Console.Write(matrica[i,j]+" ");
    }
    Console.WriteLine();
}

Console.WriteLine("***********************");

// Korak: 7
for (int i = 2; i>= Redaka - 4; i--)
{
    matrica[i,1]= a++;
}

for (int i = 0; i< Stupaca ; i++)  // Provjera
{
    for(int j =0; j<Redaka; j++)
    {
        Console.Write(matrica[i,j]+" ");
    }
    Console.WriteLine();
}

Console.WriteLine("***********************");

// Korak: 8
for (int i =2; i<=Stupaca-2; i++)
{
    matrica[1,i]= a++;
}

for(int i =0; i<Stupaca ; i++)  // Provjera
{
    for(int j=0; j<Redaka; j++)
    {
        Console.Write(matrica[i,j]+" ");
    }
    Console.WriteLine();
}

Console.WriteLine("***********************");

// Korak:9
string ispis;
for(int i =3; i>=Stupaca-3; i--)
{
    matrica[2,i]= a++;
}

for(int i =0; i<Stupaca; i++)
{
    for(int j=0; j<Redaka; j++)
    {
        ispis = " " + matrica[i,j];
        Console.Write(ispis[^3..]);
    }
    Console.WriteLine();
}