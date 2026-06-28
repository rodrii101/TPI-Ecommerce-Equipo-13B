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
                ProductoNegocio productoNegocio = new ProductoNegocio();
                List<Producto> listaProductos = productoNegocio.listarProductos();

                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                ImagenNegocio auxImagen = new ImagenNegocio();
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

                    auxProducto.Id = aux.IdProducto;
                    auxProducto.Nombre = (string)datos.Lector["Nombre"];
                    auxProducto.Precio = (decimal)datos.Lector["Precio"];
                    auxProducto.Imagenes_URL = new List<ImagenProducto>();
                    auxProducto.Imagenes_URL = auxImagen.listarImgProducto(aux.IdProducto);

                    Producto productoConNombreVendedor = listaProductos.FirstOrDefault(p => p.Id == aux.IdProducto); //Devuelve el producto que cumple la condicion
                    auxProducto.IdVendedor = productoConNombreVendedor.IdVendedor;
                    auxProducto.Stock = productoConNombreVendedor.Stock;

                    
                    Usuario usuarioEncontrado = usuarioNegocio.BuscarUsuario(auxProducto.IdVendedor);
                    //aux.Usuario = new Usuario();

                    aux.Producto = auxProducto;
                    aux.Usuario = usuarioEncontrado;
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


        public void EliminarProductoDetalleCarrito(int idCarrito, int idProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedEliminarProductoDetalleCarrito");
                datos.setearParametro("@IdCarrito", idCarrito);
                datos.setearParametro("@IdProducto", idProducto);
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


        public void modificarCantidad(int idCarritoDetalle, int nuevaCantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedModificarCantidad");
                datos.setearParametro("IdCarritoDetalle", idCarritoDetalle);
                /*datos.setearParametro("IdCarrito", idCarrito);
                datos.setearParametro("IdProducto", idProducto);*/
                datos.setearParametro("NuevaCantidad", nuevaCantidad);
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
