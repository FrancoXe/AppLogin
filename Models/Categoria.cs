using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }

        public ICollection<Subcategoria> Subcategorias { get; set; } = new List<Subcategoria>();
    }
}
