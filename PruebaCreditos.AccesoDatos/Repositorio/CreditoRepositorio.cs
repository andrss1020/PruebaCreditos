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
    public class CreditoRepositorio : Repositorio<Credito>, ICreditoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public CreditoRepositorio(ApplicationDbContext db): base(db) {
            _db = db;
        }
        public void Actualizar(Credito credito)
        {
            var creditoOb = _db.Credito.FirstOrDefault(b => b.Id == credito.Id);
            if (creditoOb != null) {
                creditoOb.Monto = credito.Monto;
                creditoOb.Plazo = credito.Plazo;

                //_db.SaveChanges();
            }
        }


    }
}
