using Microsoft.AspNetCore.Mvc;
using PruebaCreditos.AccesoDatos.Repositorio.IRepositorio;
using PruebaCreditos.Modelos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCreditos.Controllers
{
    public class AmortizacionController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public CreditoViewModel CreditoVM { get; set; }

        public AmortizacionController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index(int? Id)
        {
            
            CreditoVM = new CreditoViewModel()
            {
                Amortizacion = _unidadTrabajo.Amortizacion.ObtenerTodos(u => u.CreditoId == Id, incluirPropiedades: "Credito")
            };
            CreditoVM.IdCredito = (int)Id;
            foreach (Modelos.Amortizacion item in CreditoVM.Amortizacion) {
                if (item.Estado == "Vigente" ) {
                    CreditoVM.PagarCuota = item;
                    break;
                }
            }
            return View(CreditoVM);
        }
    }
}
