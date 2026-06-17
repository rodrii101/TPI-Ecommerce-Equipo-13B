using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominioEcommerce;

namespace negocioEcommerce
{
    public class ImagenNegocio
    {
        public List<ImagenProducto> listarImgProducto(int id)
        {
            List<ImagenProducto> lista = new List<ImagenProducto>();
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearProcedimiento("storedBuscarImagen");
                datos.setearParametro("@IdProducto", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ImagenProducto imagen = new ImagenProducto();
                    
                    imagen.Id = (int)datos.Lector["Id"];
                    imagen.IdProducto = (int)datos.Lector["IdProducto"];
                    imagen.ImagenURL = (string)datos.Lector["ImagenURL"];
                    imagen.EsPrincipal = (bool)datos.Lector["EsPrincipal"];
                    lista.Add(imagen);
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

        public void agregarImagen(int idProducto, string url)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedAltaImagen");
                datos.setearParametro("@IdProducto", idProducto);
                datos.setearParametro("@ImagenURL", url);
                datos.setearParametro("@EsPrincipal", 0);
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

        public void eliminarImagen(int idImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedEliminarImagen");
                datos.setearParametro("@Id", idImagen);
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

        public void establecerImagenPrincipal(string idProducto, int idImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedResetPrincipalImg");
                datos.setearParametro("@IdProducto", int.Parse(idProducto));
                datos.ejecutarAccion();

                datos.limpiarParametros();
                datos.setearProcedimiento("storedActivarPrincipalImg");
                datos.setearParametro("@Id", idImagen);
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

        public void añadirImagenes(List<ImagenProducto> listaImagenesNuevas)
        {
            ImagenNegocio negocioImg = new ImagenNegocio();
            
            try
            {
                foreach (ImagenProducto imagen in listaImagenesNuevas)
                {
                    AccesoDatos datos = new AccesoDatos();

                    datos.setearProcedimiento("storedAltaImagen");
                    datos.setearParametro("@IdProducto", imagen.IdProducto);
                    datos.setearParametro("@ImagenURL", imagen.ImagenURL);
                    datos.setearParametro("@EsPrincipal", imagen.EsPrincipal);
                    datos.ejecutarAccion();
                    datos.cerrarConexion();
                }
            }
            catch
            {

            }
        }

    }
}
