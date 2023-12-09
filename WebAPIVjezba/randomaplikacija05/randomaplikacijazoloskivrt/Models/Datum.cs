using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;

namespace randomaplikacijazoloskivrt.Models
{
    [Keyless]
    [NotMapped]
    public class Datum 
    {
        
        public DateTime DatumRodenja { get; set; }
        public DateTime DatumDolaska { get; set; }
        public DateTime DatumSmrti { get; set; }

    }
}
