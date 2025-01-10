using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
    public class Barrio
    {
        public int IdBarrio { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }
    }
}
