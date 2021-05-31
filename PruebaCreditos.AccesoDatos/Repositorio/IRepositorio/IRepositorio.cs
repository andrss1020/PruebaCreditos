using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCreditos.AccesoDatos.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T: class
    {
        T Obtener(int id);

        IEnumerable<T> ObtenerTodos(
            Expression<Func<T, bool>> filter = null,
            string incluirPropiedades = null
            );
        T ObtenerPrimero(
            Expression<Func<T, bool>> filter = null,
            string incluirPropiedades = null
            );

        void Agregar(T entidad);

        void Remover(T entidad);
        void Remover(int id);

        void RemoverRango(IEnumerable<T> entidad);
    }
}
