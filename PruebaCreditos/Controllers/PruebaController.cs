using Microsoft.AspNetCore.Mvc;
using PruebaCreditos.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCreditos.Controllers
{
    public class PruebaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public PruebaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API
        [HttpGet]
        public IActionResult ObtenerTodos() {
            var todos = _unidadTrabajo.Credito.ObtenerTodos();
            return Json(new { data = todos });
        }
        #endregion API
    }
}
