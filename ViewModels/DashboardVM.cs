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
    }
}
