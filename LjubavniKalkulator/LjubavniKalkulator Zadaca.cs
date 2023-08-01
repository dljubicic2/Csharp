using System.Threading.Channels;

string SvojeIme;
string ImeSimpatije;

Console.Write("Unesite svoje ime: ");
SvojeIme = Console.ReadLine();

Console.Write("Unesite ime simpatije: ");
ImeSimpatije = Console.ReadLine();

Sansa(BrojanjeSlova(SvojeIme, ImeSimpatije, " " + ImeSimpatije));

int[] Konverzija(string z)
{
    int pretvarac = z.Length;
    int[] IzradiNiz = new int[pretvarac];

    for (int i = 0; i < pretvarac; i++)
    {
        IzradiNiz[i] = Convert.ToInt32(z[i]) - 48;
        Console.Write(IzradiNiz[i] + " ");
    }
    Console.WriteLine();
    Console.WriteLine();
    return IzradiNiz;
}


int[] BrojanjeSlova(string x, string y, string v)
{
    string NizSlovo = x + y;
    Console.WriteLine();
    Console.WriteLine(NizSlovo);

    string z = " ";
    int d = NizSlovo.Length;
    int[] NizBroj = new int[d];

    for (int i = 0; i < d; i++)
    {
        NizBroj[i] = 1;
    }
    for (int i = 0; i < d; i++)
    {
        int n = 1;
        while (n <= 1)
        {
            if (NizSlovo[i] == NizSlovo[i - n])
            {
                NizBroj[i - n]++;
                NizBroj[i] = NizBroj[i - n];
            }
            n++;
        }
    }
    Console.WriteLine();

    for (int i = 0; i < d; i++)
    {
        Console.Write(NizBroj[i] + " ");
        z += NizBroj[i];
    }
    Console.WriteLine();
    NizBroj = Konverzija(z);
    return NizBroj;
}


int[] Sansa(int[] niz)
{
    string r = " ";
    int k = niz.Length;
    int l = (k % 2 == 0) ? (k / 2) : (k / 2 + 1);
    int[] dniz = new int[l];

    for (int i = 0; i < l; i++)
    {
        if (i == k - i - 1)
        {
            dniz[i] = niz[i];
        }
        else
        {
            dniz[i] = niz[i] + niz[k - i - 1];
            Console.WriteLine(dniz[i] + " ");
            r += dniz[i];
        }

    }
    Console.WriteLine();
    dniz = Konverzija(r);

    if (dniz.Length <= 2)
    {
        Console.WriteLine("Postotak za razvoj vaše ljubavi: {0}{1} %", dniz[0], dniz[1]);
        return dniz;
    }
    else
    {
        return Sansa(dniz);
    }
}