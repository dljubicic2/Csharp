namespace EdunovaWP1.Models.DTO
{
    public class UpitDTO
    {
        public int Sifra { get; set; }
        public string? Pitanje { get; set; }
        public int SifraOsoba { get; set; }
        public Osoba? Osoba  { get; set; }
        public Oglas? Oglas { get; set; }
        public int SifraOglas { get; set; }
    }
}
