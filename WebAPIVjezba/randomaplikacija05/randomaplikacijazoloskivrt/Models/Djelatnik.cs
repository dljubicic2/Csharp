namespace randomaplikacijazoloskivrt.Models
{
    public class Djelatnik : Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set;}
        public string? Oib { get; set; }


        public ICollection<Zivotinja> Zivotinje { get; } = new List<Zivotinja>();
    }
}
