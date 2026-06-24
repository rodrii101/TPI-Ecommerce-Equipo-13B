using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using dominioEcommerce;

namespace negocioEcommerce
{
    public class ProductoNegocio
    {
        public List<Producto> listarProductos(string id="")
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            try
            {
                if (id != "")
                {
                    datos.setearProcedimiento("buscarProductoSeleccionado");
                    datos.setearParametro("@IdProducto", int.Parse(id));
                }
                else
                    datos.setearProcedimiento("listarProductos");
                
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["ProductoDescripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.IdCategoria = (int)datos.Lector["CatId"];
                    aux.Categoria.Descripcion = (string)datos.Lector["CatDescripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = (int)datos.Lector["MarcaId"];
                    aux.Marca.Descripcion = (string)datos.Lector["MarcaDescripcion"];
                    aux.Marca.UrlImagen = (string)datos.Lector["MarcaImagenLogo"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    aux.IdVendedor = (int)datos.Lector["IdVendedor"];
                    //CARGA IMAGENES
                    aux.Imagenes_URL = new List<ImagenProducto>();
                    aux.Imagenes_URL = imagenNegocio.listarImgProducto(aux.Id); 

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

        public void agregar(Producto nuevoProducto, List<ImagenProducto> listaImgenes)//lista
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearProcedimiento("storedAltaProducto");
                datos.setearParametro("@Nombre", nuevoProducto.Nombre);
                datos.setearParametro("@Descripcion", nuevoProducto.Descripcion);
                datos.setearParametro("@Precio", nuevoProducto.Precio);
                datos.setearParametro("@IdCategoria", nuevoProducto.Categoria.IdCategoria);
                datos.setearParametro("@IdMarca", nuevoProducto.Marca.IdMarca);
                datos.setearParametro("@Estado", 1);
                datos.setearParametro("@Stock", nuevoProducto.Stock);
                datos.setearParametro("@IdVendedor", 1);

                int idNuevo = datos.ejecutarScalar();
                datos.cerrarConexion();


                foreach (ImagenProducto imagen in listaImgenes)
                {
                    AccesoDatos datosImg = new AccesoDatos();

                    datosImg.setearProcedimiento("storedAltaImagen");
                    datosImg.setearParametro("@IdProducto", idNuevo);
                    datosImg.setearParametro("@ImagenURL", imagen.ImagenURL);
                    datosImg.setearParametro("@EsPrincipal", imagen.EsPrincipal);
                    datosImg.ejecutarAccion();
                    datosImg.cerrarConexion();
                }
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


        public void modificarProducto(Producto producto, string id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                    datos.setearProcedimiento("storedModificarProducto");
                    datos.setearParametro("@Id", int.Parse(id));
                    datos.setearParametro("@Nombre", producto.Nombre);
                    datos.setearParametro("@Descripcion", producto.Descripcion);
                    datos.setearParametro("@Precio", producto.Precio);
                    datos.setearParametro("@IdCategoria", producto.Categoria.IdCategoria);
                    datos.setearParametro("@IdMarca", producto.Marca.IdMarca);
                    datos.setearParametro("@Stock", producto.Stock);
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

        public void eliminarProducto(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedEliminarProducto");
                datos.setearParametro("@Id", id);
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

        public void desactivarProducto(int id, bool estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedDesactivarProducto");
                datos.setearParametro("@Id", id);
                if (estado)
                    datos.setearParametro("@Estado", false);
                else
                    datos.setearParametro("@Estado", true);

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