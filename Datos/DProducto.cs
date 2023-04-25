using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DProducto
    {
        public List<Producto> ListarTodo()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, "ListarProductos", CommandType.StoredProcedure);

                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)reader["id"];
                    producto.Nombre = reader["nombre"].ToString();
                    producto.Precio = (decimal)reader["precio"];
                    producto.FechaCreacion = (DateTime)reader["fecha_creacion"];
                    producto.Estado = (bool)reader["estado"];
                    productos.Add(producto);
                }
                reader.Close();

                return productos;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Insertar(Producto producto)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@nombre", producto.Nombre),
                    new SqlParameter("@precio", producto.Precio),
                    new SqlParameter("@fecha_creacion", producto.FechaCreacion)
                };

                SqlHelper.ExecuteNonQuery2("InsertarProducto", parameters);
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
                SqlParameter parameter = new SqlParameter("@id", id);

                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, "EliminarProducto", CommandType.StoredProcedure, parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public void ActualizarProducto(Producto producto)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", producto.Id),
                    new SqlParameter("@nombre", producto.Nombre),
                    new SqlParameter("@precio", producto.Precio),
                    new SqlParameter("@fecha_creacion", producto.FechaCreacion)
                };

                SqlHelper.ExecuteNonQuery2("ActualizarProducto", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Producto> BuscarPorNombre(string nombre)
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@nombre", nombre)
        };

                SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, "BuscarProductoPorNombre", CommandType.StoredProcedure, parameters.ToArray());

                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)reader["id"];
                    producto.Nombre = reader["nombre"].ToString();
                    producto.Precio = (decimal)reader["precio"];
                    producto.FechaCreacion = (DateTime)reader["fecha_creacion"];
                    producto.Estado = (bool)reader["estado"];
                    productos.Add(producto);
                }
                reader.Close();

                return productos;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
