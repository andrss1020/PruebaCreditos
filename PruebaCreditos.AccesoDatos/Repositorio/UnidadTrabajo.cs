using PruebaCreditos.AccesoDatos.Data;
using PruebaCreditos.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCreditos.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ICreditoRepositorio Credito { get; private set; }
        public IAmortizacionRepositorio Amortizacion { get; private set; }
        public IClientesRepositorio Clientes { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Credito = new CreditoRepositorio(_db);
            Amortizacion = new AmortizacionRepositorio(_db);
            Clientes = new ClientesRepositorio(_db);
        }
        public void Guardar() {
            _db.SaveChanges();
        }

        public void Dispose() {
            _db.Dispose();
        }
    }
}
