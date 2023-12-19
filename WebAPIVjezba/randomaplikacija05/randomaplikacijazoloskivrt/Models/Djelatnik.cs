namespace randomaplikacijazoloskivrt.Models
{
    public class Djelatnik : Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set;}
        public string? Oib { get; set; }

        public static implicit operator string(Djelatnik v)
        {
            throw new NotImplementedException();
        }
    }
}
