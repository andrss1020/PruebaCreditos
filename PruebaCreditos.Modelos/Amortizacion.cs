using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCreditos.Modelos
{
    public class Amortizacion
    {
        public int Id { get; set; }
        [Display(Name = "Dividendo")]
        public int Dividendo { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public double Monto { get; set; }
        public double Capital { get; set; }
        public double Interes { get; set; }
        public double Seguros { get; set; }
        public double CuotaPagar { get; set; }
        public string Estado { get; set; }
        [Required]
        public int CreditoId { get; set; }
        [ForeignKey("CreditoId")]
        public Credito Credito { get; set; }
    }
}
