// Zadatak:1
// Za unesena dva cijela broja. Program ispisuje veći
// 3 i 5 > 5
// 3 i 5 > -5
// 5 i 5 ->

int i = 3;
int i2 = 4;
int i3 = 6;

if (i2 > i) 
{
    Console.WriteLine(i);
}

{
    Console.WriteLine(i2);
}

// Zadatak: 2
// Za upisana tri cijela broja program ispisuje najveći

if (i > i2) ;
{
    Console.WriteLine(i);
}
if (i2 > i3) 
{
    Console.WriteLine(i2);
}
if (i > i3) 
{
    Console.WriteLine(i3);
}

// Zadatak: 3
// Program unosi broj između 1 i 999. U slučaju da je između tog raspona ispiši grešku i prekini program.
// Program ispisuje jednu znamenku upisanog broja

Console.Write("Izaberi broj između 1 i 999");
int br = int.Parse(Console.ReadLine());

if (br > 999) 
{
    Console.WriteLine("Greška");
}
{
    Console.WriteLine(br / 10);
}

// Zadatak:4
// Program unosi 2 broja.
// Ako su oba broja parni ispisuje njihov zbroj
// Inače ispisuje njihovu razliku

Console.Write("Unesi prvi broj");
Console.Write("Unesi drugi broj");
int pb = int.Parse(Console.ReadLine());

if (pb %2==0) ;
{
    Console.WriteLine("Broj je paran");
}

{
    Console.WriteLine("Broj je neparan");
}