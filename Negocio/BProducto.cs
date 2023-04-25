using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BProducto
    {
        DProducto datos = new DProducto();
        public List<Producto> ListarTodo()
        {
            return datos.ListarTodo();
        }

        public void Insertar(Producto producto)
        {
            try
            {
                datos.Insertar(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Eliminar(int id)
        {
            try
            {
                DProducto datos = new DProducto();
                datos.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Actualizar(Producto producto)
        {
            DProducto datos = new DProducto();
            datos.ActualizarProducto(producto);
        }

        public List<Producto> BuscarProductoPorNombre(string nombre)
        {
            try
            {
                DProducto datos = new DProducto();
                return datos.BuscarPorNombre(nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
