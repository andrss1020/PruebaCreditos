using PruebaCreditos.AccesoDatos.Data;
using PruebaCreditos.AccesoDatos.Repositorio.IRepositorio;
using PruebaCreditos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCreditos.AccesoDatos.Repositorio
{
    public class AmortizacionRepositorio : Repositorio<Amortizacion>, IAmortizacionRepositorio
    {
        private readonly ApplicationDbContext _db;
        public AmortizacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Amortizacion amortizacion)
        {
            var amortizacionDb = _db.Amortizacion.FirstOrDefault(b => b.Id == amortizacion.Id);
            if (amortizacionDb != null) {
                amortizacionDb.Estado = "Cancelado";
                _db.SaveChanges();
            }
        }
    }
}
