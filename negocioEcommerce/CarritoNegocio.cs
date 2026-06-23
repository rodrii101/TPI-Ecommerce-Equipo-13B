using dominioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocioEcommerce
{
    public class CarritoNegocio
    {
        public List<CarritoDetalle> listarDetalleCarritoUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                List<CarritoDetalle> lista = new List<CarritoDetalle>();
                datos.setearProcedimiento("ListarDetalleCarritoPorUsuario");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    CarritoDetalle aux = new CarritoDetalle();
                    Producto auxProducto = new Producto();
                    aux.IdCarritoDetalle = (int)datos.Lector["IdDetalleCarrito"];
                    aux.IdCarrito = (int)datos.Lector["IdCarrito"];
                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Cantidad = (int)datos.Lector["CantidadProducto"];
                    aux.IdProducto = aux.IdProducto;
                    auxProducto.Nombre = (string)datos.Lector["Nombre"];
                    auxProducto.Precio = (decimal)datos.Lector["Precio"];
                    aux.Producto = auxProducto;
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int CrearCarritoUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("CrearCarritoUsuario");
                datos.setearParametro("@IdUsuario", idUsuario);

                int IdCarrito = datos.ejecutarScalar();
                return IdCarrito;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int BuscarCarritoDelUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("BuscarUsuarioCarrito");
                datos.setearParametro("@IdUsuario", idUsuario);

                int IdCarrito = datos.ejecutarScalar();
                return IdCarrito;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void AgregarProductosDetalleCarrito(int IdCarrito, int IdProducto, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("AgregarProductoAlDetalleCarrito");
                datos.setearParametro("@IdCarrito", IdCarrito);
                datos.setearParametro("@IdProducto", IdProducto);
                datos.setearParametro("@Cantidad", cantidad);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
