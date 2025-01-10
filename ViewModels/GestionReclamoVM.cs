using System.ComponentModel.DataAnnotations;

namespace AppLogin.ViewModels
{
    public class GestionReclamoVM
    {
        [Required]
        public int IdReclamo { get; set; }

        [Required]
        public string Estado { get; set; } = string.Empty;
    }
}
