

using E01KlasaObjekt;

string ime = "Pero";
string prezime = "Perić";
int godine = 24;

ime = "Marija";

string ime1 = "marija";

// Ovo morate znati nakon svatova u 4 ujutro!!!
// Objekt je instanca/pojavnost klase
// Osoba je naziv klase (tip podatka)
// o je instanca klase, o je objekt, o je varijabla
// new je ključna riječ koja poziva posebnu metodu: konstruktor
Osoba o = new Osoba();

o = new Osoba("Pero");

// Eksplicitni način deklariranja varijable
Osoba natjecatelj = new Osoba();

// Implicitni način deklariranja varijable

var prijavitelj = new Osoba("Marija"); // Desna strana određuje tip podatka varijable
var i = 1;

// Drugi dio Z01
Dokument[] dokumenti = new Dokument[3];
dokumenti[0] = new Dokument();
dokumenti[1] = new Dokument();
dokumenti[2] = new Dokument("Račun");

Smjer smjer = new Smjer("mora biti string",3);

Grupa grupa;
for(int j =0; j<128; j++)
{
    grupa = new Grupa();
}

