using dominioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocioEcommerce
{
    public class FormasDeEntregaNegocio
    {
        public List<FormasDeEntrega> listarFormasDeEntrega()
        {
            List<FormasDeEntrega> lista = new List<FormasDeEntrega>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedListarFormasDeEntrega");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    FormasDeEntrega aux = new FormasDeEntrega();
                    aux.IdFormasDePago = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Direccion = (string)datos.Lector["DireccionLocal"];
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

    }
}
