

using E02Ucahurivanje;

Osoba osoba = new Osoba();
osoba.setIme("Pero");
osoba.prezime = "Perić"; // ovako ćemo u nastavku koristiti

Console.WriteLine("{0} {1}",osoba.prezime, osoba.getIme());

Smjer smjer = new Smjer();
smjer.Sifra = 1;
smjer.naziv = "Web programiranje";
smjer.upisnina = 250;
// .. ostala svojstva

// brža sintaksa
smjer = new Smjer
{
    Sifra = 1,
    naziv = "Web programiranje"
    // .. ostale vrijednosti
};

Zupanija zupanija = new Zupanija
{
    Naziv = "Osječko baranjska",
    Zupan = "Anušić"
};

Grad grad = new Grad
{
    Naziv = "Osijek",
    zupanija = zupanija
};

// Ispis svojstava kada jedna klasa sadrži instancu druge klase
Console.WriteLine("Grad je {0}, Županija je {1}", grad.Naziv, grad.zupanija.Naziv);


