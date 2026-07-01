using dominioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocioEcommerce
{
    public class HistorialEstadoPedidoNegocio
    {
        public void RegistrarCambio(HistorialEstadoPedido nuevoEstado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedRegistrarHistorialEstado");

                datos.setearParametro("@IdPedido", nuevoEstado.IdPedido);
                datos.setearParametro("@IdEstadoPedido", nuevoEstado.Estado.IdEstadoPedido);
                datos.setearParametro("@Observaciones", (object)nuevoEstado.Observaciones ?? DBNull.Value);

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



        public List<HistorialEstadoPedido> ListarHistorialPedido(int idPedido)
        {
            List<HistorialEstadoPedido> lista = new List<HistorialEstadoPedido>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedListarHistorialPorPedido");
                datos.setearParametro("@IdPedido", idPedido);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    HistorialEstadoPedido aux = new HistorialEstadoPedido();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdPedido = (int)datos.Lector["IdPedido"];
                    aux.IdEstado = (int)datos.Lector["IdEstadoPedido"];
                    aux.Estado = new EstadoPedido();
                    aux.Estado.Descripcion = datos.Lector["DescripcionEstado"] == DBNull.Value ? "" : (string)datos.Lector["DescripcionEstado"];
                    aux.FechaCambio = (DateTime)datos.Lector["FechaCambio"];
                    aux.Observaciones = datos.Lector["Observaciones"] == DBNull.Value ? "" : (string)datos.Lector["Observaciones"];

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
    }
}
