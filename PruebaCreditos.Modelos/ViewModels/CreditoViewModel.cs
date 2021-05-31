using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCreditos.Modelos.ViewModels
{
    public class CreditoViewModel
    {
        public IEnumerable<Amortizacion> Amortizacion { get; set; }
        public int IdCredito { get; set; }
        public Amortizacion PagarCuota { get; set; }
    }
}
