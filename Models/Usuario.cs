using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre completo es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public required string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        public required string Correo { get; set; }

        [Required(ErrorMessage = "La clave es requerida")]
        public required string Clave { get; set; }

        public int IdRol { get; set; } = 2;
        
        public required Rol Rol { get; set; }
        
        public DateTime? UltimoAcceso { get; set; }
    }
}
