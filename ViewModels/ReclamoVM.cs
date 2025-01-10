using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using AppLogin.Models;

namespace AppLogin.ViewModels
{
    public class ReclamoVM
    {
        [Required(ErrorMessage = "El DNI es requerido")]
        [StringLength(20, ErrorMessage = "El DNI no puede exceder los 20 caracteres")]
        public string DNI { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es requerida")]
        [Display(Name = "Categoría")]
        public int IdCategoria { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; } = new List<Categoria>();

        [Required(ErrorMessage = "La subcategoría es requerida")]
        [Display(Name = "Subcategoría")]
        public int IdSubcategoria { get; set; }
        public IEnumerable<Subcategoria> Subcategorias { get; set; } = new List<Subcategoria>();

        [Required(ErrorMessage = "El barrio es requerido")]
        [Display(Name = "Barrio")]
        public int IdBarrio { get; set; }
        public IEnumerable<Barrio> Barrios { get; set; } = new List<Barrio>();

        [Required(ErrorMessage = "La dirección es requerida")]
        [Display(Name = "Dirección")]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es requerida")]
        [Display(Name = "Descripción del problema")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Display(Name = "Imagen/Video")]
        public IFormFile? Archivo { get; set; }
    }
}
