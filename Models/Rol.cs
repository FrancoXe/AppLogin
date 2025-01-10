using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
    public class Rol
    {
        [Required(ErrorMessage = "El id del rol es requerido")]
        public int IdRol { get; set; }
        
        [Required(ErrorMessage = "El nombre del rol es requerido")]
        [Display(Name = "Nombre del Rol")]
        public string NombreRol { get; set; }

        public Rol()
        {
            NombreRol = string.Empty;
        }
    }
}
