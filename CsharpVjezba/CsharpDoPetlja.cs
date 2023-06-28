// Primjer: 1
// Do petlja osigurava minimalno jedno izvođenje.
// Uvjet je na kraju petlje.
do
{
    Console.WriteLine("Ušao u petlju");
} while (false);

Console.WriteLine("********************************");

// Primjer: 2
// Korisnik unosi 2 cijela broja između 10 i 20
// Program ispisuje sve parne brojeve između unesenih brojeva 
// Koristiti do petlju
int b = 0;
int c = 0;
do
{
    Console.Write("Unesi prvi cijeli broj između 10 i 20");
    b = int.Parse(Console.ReadLine());
    if (b >= 10 && b <= 20)
    {
        break;
    }
    Console.Write("Nisi unjeo traženi broj");
}
while (true);
do
{
    Console.Write("Unesi drugi cijeli broj između 10 i 20");
    c=int.Parse(Console.ReadLine());
    if (c>=10 && c <= 10)
    {
        break;
    }
    Console.WriteLine("Nisi unjeo traženi broj");
}
while (true);

int manji = b < c ? b : c;
int veci = b > c ? b : c;
int i = manji;

do
{
    if (i % 2 == 0)
        Console.WriteLine(i);
}
while (++i <= veci);