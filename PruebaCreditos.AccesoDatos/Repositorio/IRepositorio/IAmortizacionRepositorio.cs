using PruebaCreditos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCreditos.AccesoDatos.Repositorio.IRepositorio
{
    public interface IAmortizacionRepositorio : IRepositorio<Amortizacion>
    {
        void Actualizar(Amortizacion amortizacion);
    }
}
