using System.ComponentModel.DataAnnotations;

namespace AppLogin.ViewModels
{
    public class UsuarioVM
    {
        [Required(ErrorMessage = "El nombre completo es requerido")]
        [Display(Name = "Nombre Completo")]
        public required string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        [Display(Name = "Correo Electrónico")]
        public required string Correo { get; set; }

        [Required(ErrorMessage = "La clave es requerida")]
        [Display(Name = "Contraseña")]
        public required string Clave { get; set; }

        [Required(ErrorMessage = "Debe confirmar la clave")]
        [Compare("Clave", ErrorMessage = "Las contraseñas no coinciden")]
        [Display(Name = "Confirmar Contraseña")]
        public required string ConfirmarClave { get; set; }
    }
}
