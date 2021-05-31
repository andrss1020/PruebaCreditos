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
    public class ClientesRepositorio : Repositorio<Clientes>, IClientesRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ClientesRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
