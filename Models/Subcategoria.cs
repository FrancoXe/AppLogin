using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
    public class Subcategoria
    {
        public int IdSubcategoria { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }

        public int IdCategoria { get; set; }
        public required Categoria Categoria { get; set; }
    }
}
