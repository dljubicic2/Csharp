namespace EdunovaWP1.Models
{
    public class Osoba : Entitet
    {
        public string? Nadimak { get; set; }
        public string? Email { get; set; }
        public string? Lozinka { get; set; }
        public int BrojTelefona { get; set; }
        public ICollection<Vozilo> Vozila { get; } = new List<Vozilo>();
        
    }
}
