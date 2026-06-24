using dominioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocioEcommerce
{
    public class EstadoPedidoNegocio
    {
        public List<EstadoPedido> listarEstadoPedido(string id = "")
        {
            AccesoDatos datos = new AccesoDatos ();
            List<EstadoPedido> listaPedido = new List<EstadoPedido>();
            try
            {
                if(id != "")
                {
                    datos.setearProcedimiento("BuscarEstadoPedido");
                    datos.setearParametro("@IdEstadoPedido", int.Parse(id));
                } else
                    datos.setearConsulta("SELECT Id, Descripcion, Estado FROM EstadoPedido");
                
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    EstadoPedido aux = new EstadoPedido();
                    aux.IdEstadoPedido = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    listaPedido.Add(aux);
                }
                return listaPedido;
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
        public void AgregarEstadoPedido(EstadoPedido nuevoEstadoPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("AgregarEstadoPedido");
                datos.setearParametro("@Descripcion", nuevoEstadoPedido.Descripcion);
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
        public void ModificarEstadoPedido(EstadoPedido modificarEstadoPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ModificarEstadoPedido");
                datos.setearParametro("@Id", modificarEstadoPedido.IdEstadoPedido);
                datos.setearParametro("@Descripcion", modificarEstadoPedido.Descripcion);
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
        public void ActivarODesativarEstadoPedido(int id, bool estado = false)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("CambiarElEstadoPedido");
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

    }
}
