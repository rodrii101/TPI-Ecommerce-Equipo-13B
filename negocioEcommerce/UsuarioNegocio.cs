using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominioEcommerce;

namespace negocioEcommerce
{
    internal class UsuarioNegocio
    {
       /*public List<Usuario> listarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("listarUsuarios");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Usuario auxUsuario = new Usuario();
                    auxUsuario.Nombre = (string)datos.Lector["Nombre"];
                    auxUsuario.Apellido = (string)datos.Lector["Apellido");
                    auxUsuario.DNI = (int)datos.Lector["DNI"];
                    auxUsuario.Email = (string)datos.Lector["Email"];
                    auxUsuario.Telefono = (string)datos.Lector["Telefono"];
                    auxUsuario.Domicilio = (Direccion)datos.Lector["Domicilio"];
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
        }*/

    }
}
