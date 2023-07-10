// 1. Korak
int redaka = 5;
int stupaca = 5;
int[,] matrica = new int[redaka, stupaca]; // Kreirana je tablica

// 2. Korak
int b = 1;
for (int i = 1; i <= stupaca; i++)
{
    matrica[redaka - 1, stupaca - i] = b++;
}

//3. Korak
for (int i = redaka - 2; i >= 0; i--)
{
    matrica[i, 0] = b++;
}

//4. Korak
for (int i = 1; i <= stupaca - 1; i++)

{
    matrica[0, i] = b++;
}

//5. Korak
for (int i = 1; i <= stupaca - 2; i++)
{
    matrica[i, stupaca - 1] = b++;
}

//6. Korak
for (int i = 3; i >= stupaca - 4; i--)
{
    matrica[3, i] = b++;
}

//7. Korak
for (int i = 2; i >= redaka - 4; i--)
{
    matrica[i, 1] = b++;
}

//8. Korak
for (int i = 2; i <= stupaca - 2; i++)
{
    matrica[1, i] = b++;
}

//9. Korak
for (int i = 2; i <= stupaca - 3; i++)
{
    matrica[i, stupaca - 2] = b++;
}

//10. Korak
string razmak;
for (int i = 3; i < stupaca - 1; i++)
{
    matrica[redaka - 3, stupaca - i] = b++;
}
for (int i = 0; i < redaka; i++)  // Ispis
{
    for (int j = 0; j < stupaca; j++)
    {
        razmak = "   " + matrica[i, j];
        Console.Write(razmak[^4..]);
    }
    Console.WriteLine();
}