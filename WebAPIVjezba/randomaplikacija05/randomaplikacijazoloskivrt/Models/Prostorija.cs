﻿namespace randomaplikacijazoloskivrt.Models
{
    public class Prostorija : Entitet
    {
        public string? Dimenzije { get; set; }
        public int MaksBroj { get; set; }
        public string? Mjesto { get; set; }

        public ICollection<Zivotinja> Zivotinje { get; } = new List<Zivotinja>();
    }
}
