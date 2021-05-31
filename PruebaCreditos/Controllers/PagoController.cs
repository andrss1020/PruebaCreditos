using Microsoft.AspNetCore.Mvc;
using PruebaCreditos.AccesoDatos.Repositorio.IRepositorio;
using PruebaCreditos.Modelos;
using PruebaCreditos.Modelos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCreditos.Controllers
{
    public class PagoController : Controller
    {
        public readonly IUnidadTrabajo _unidadTrabajo;
        public CreditoViewModel CreditoVM { get; set; }

        public PagoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index(Amortizacion to)
        {
            CreditoVM = new CreditoViewModel()
            {
                PagarCuota = to
            };
            return View(CreditoVM);
        }

        public IActionResult Update(Amortizacion to)
        {
            DateTime now = DateTime.Now;
            Amortizacion amortizacion = new Amortizacion();
            CreditoVM = new CreditoViewModel()
            {
                PagarCuota = to
            };
            if (CreditoVM.PagarCuota.FechaVencimiento == now.Date)
            {
                TempData["FechaIgual"] = "Pago realizado con Éxito";
                _unidadTrabajo.Amortizacion.Actualizar(to);
                return View(CreditoVM);
            }
            else
            {
                TempData["FechaDiferente"] = "Fecha de vencimiento no corresponde a la fecha actual";
                _unidadTrabajo.Amortizacion.Actualizar(to);
                return View(CreditoVM);
            }
            return View(CreditoVM);
        }


    }
}
