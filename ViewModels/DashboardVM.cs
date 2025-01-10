using AppLogin.Models;

namespace AppLogin.ViewModels
{
    public class DashboardVM
    {
        public int TotalReclamos { get; set; }
        public int ReclamosPendientes { get; set; }
        public int ReclamosAceptados { get; set; }
        public int ReclamosRechazados { get; set; }
        public List<Reclamo> UltimosReclamos { get; set; } = new();
        
        // Propiedades para administradores
        public bool IsAdmin { get; set; }
        public int TotalReclamosGlobal { get; set; }
        public int ReclamosPendientesGlobal { get; set; }
        public int ReclamosAceptadosGlobal { get; set; }
        public int ReclamosRechazadosGlobal { get; set; }
        public int TotalUsuarios { get; set; }
        public List<Reclamo> UltimosReclamosGlobal { get; set; } = new();
    }
}
