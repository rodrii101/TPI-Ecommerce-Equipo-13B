using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominioEcommerce;
namespace negocioEcommerce
{
    public class FormasDePagoNegocio
    {
        public List<FormasDePagos> listarFormasDePagos()
        {
            List<FormasDePagos> lista = new List<FormasDePagos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("listarFormasDePagos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    FormasDePagos aux = new FormasDePagos();
                    aux.IdFormasDePago = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = (bool)datos.Lector["Estado"];
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
        public List<FormasDePagos> listarFormasDePagos(string IdFormaDePago = "")
        {
            List<FormasDePagos> lista = new List<FormasDePagos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (IdFormaDePago != "")
                {
                    datos.setearProcedimiento("BuscarFormaDePago");
                    datos.setearParametro("@Id", int.Parse(IdFormaDePago));
                }
                else
                    datos.setearProcedimiento("listarFormasDePagos");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    FormasDePagos aux = new FormasDePagos();
                    aux.IdFormasDePago = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = (bool)datos.Lector["Estado"];  
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
        public void AgregarFormaDePago(FormasDePagos nuevoPago)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("AgregarFormaDePago");
                datos.setearParametro("@Descripcion", nuevoPago.Descripcion);
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
        public void ModificarFormaDePago(FormasDePagos modificarPago)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ModificarFormaDePago");
                datos.setearParametro("@Id", modificarPago.IdFormasDePago);
                datos.setearParametro("@Descripcion", modificarPago.Descripcion);
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
        public void DesactivarYActivarFormaDeProducto(int id, bool estado = false)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("CambiarEstadoFormaDePago");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@Estado", estado);
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
        public bool existeDescripcionFormaDePago(string descripcionFormaDePago)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Descripcion FROM FormaDePago WHERE Descripcion = @Descripcion");
                datos.setearParametro("@Descripcion", descripcionFormaDePago);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                    return true;

                return false;
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
