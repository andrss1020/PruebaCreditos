using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCreditos.Modelos
{
    public class Credito
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tipo Crédito")]
        public string TipoCredito { get; set; }
        [Required]
        [Range(400, 2000)]
        [Display(Name = "Monto")]
        public double Monto { get; set; }
        [Required]
        [Range(12, 36)]
        [Display(Name = "Plazo")]
        public int Plazo { get; set; }
        [Required]
        [Display(Name = "Tasa")]
        public double Tasa { get; set; }
        [Required]
        [Display(Name = "Tipo Amortización")]
        public string TipoAmortizacion { get; set; }
        [Required]
        public string ClientesId { get; set; }
        [ForeignKey("ClientesId")]
        public Clientes Clientes { get; set; }
        public virtual List<Amortizacion> Amortizacion { get; set; }
        
    }
}
