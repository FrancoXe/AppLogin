using System.ComponentModel.DataAnnotations;

namespace AppLogin.ViewModels
{
    public class UsuarioGestionVM
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre completo es requerido")]
        [Display(Name = "Nombre Completo")]
        public required string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        [Display(Name = "Correo Electrónico")]
        public required string Correo { get; set; }

        [Required(ErrorMessage = "El rol es requerido")]
        [Display(Name = "Rol")]
        public required string RolNombre { get; set; }

        [Display(Name = "Último Acceso")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", NullDisplayText = "Nunca")]
        public DateTime? UltimoAcceso { get; set; }
    }
}
