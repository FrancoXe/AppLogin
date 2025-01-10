using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppLogin.Models
{
    public class Reclamo
    {
        [Key]
        public int IdReclamo { get; set; }

        [Required(ErrorMessage = "El DNI es requerido")]
        [StringLength(20, ErrorMessage = "El DNI no puede exceder los 20 caracteres")]
        public required string DNI { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public required Categoria Categoria { get; set; }

        [Required(ErrorMessage = "La subcategoría es requerida")]
        public int IdSubcategoria { get; set; }

        [ForeignKey("IdSubcategoria")]
        public required Subcategoria Subcategoria { get; set; }

        [Required(ErrorMessage = "El barrio es requerido")]
        public int IdBarrio { get; set; }

        [ForeignKey("IdBarrio")]
        public required Barrio Barrio { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres")]
        public required string Direccion { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
        public required string Descripcion { get; set; }

        [StringLength(200)]
        public string? RutaArchivo { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public DateTime? FechaActualizacion { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Pendiente";

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }
    }
}
