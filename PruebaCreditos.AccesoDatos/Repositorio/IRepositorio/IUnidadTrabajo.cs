using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCreditos.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        ICreditoRepositorio Credito { get; }
        IAmortizacionRepositorio Amortizacion { get; }
        IClientesRepositorio Clientes { get; }

        void Guardar();
    }
}
