using System.ComponentModel.DataAnnotations;
using EdunovaWP1.Validations;

namespace EdunovaWP1.Models
{
    public class Osoba : Entitet
    {
        [Required(ErrorMessage = "Nadimak obavezan")]
        [NadimakNeMozeBitiBroj]
        public string? Nadimak { get; set; }
        public string? Email { get; set; }
        public string? Lozinka { get; set; }
        
        
    }
}
