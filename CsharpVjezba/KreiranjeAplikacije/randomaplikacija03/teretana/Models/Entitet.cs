using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace teretana.Models
{
    public class Entitet
    {
        [Key]
        public int Sifra { get; set; }
    }
}
