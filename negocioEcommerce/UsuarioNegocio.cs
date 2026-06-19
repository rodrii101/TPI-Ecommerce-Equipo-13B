using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominioEcommerce;

namespace negocioEcommerce
{
    public class UsuarioNegocio
    {
        //public List<Usuario> listarusuarios()
        //{
        //    List<Usuario> lista = new List<Usuario>();
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setearProcedimiento("listarusuarios");
        //        datos.ejecutarLectura();
        //        while (datos.Lector.Read())
        //        {
        //            Usuario auxusuario = new Usuario();
        //            auxusuario.Nombre = (string)datos.Lector["Nombre"];
        //            auxusuario.Apellido = (string)datos.Lector["Apellido"];
        //            auxusuario.DNI = (int)datos.Lector["DNI"];
        //            auxusuario.Email = (string)datos.Lector["Email"];
        //            auxusuario.Telefono = (string)datos.Lector["Telefono"];
        //            lista.Add(auxusuario);
        //        }
        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
        
        public bool Loguer(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("VerificarLogin");
                datos.setearParametro("@Email", user.Email);
                datos.setearParametro("@Pass", user.Pass);
                datos.ejecutarLectura();
                while (datos.Lector.Read()){
                    user.Id = (int)datos.Lector["Id"];
                    user.TipoUsuario.IdTipoUsuario = (int)(datos.Lector["IdTipoUsuario"]);
                    user.Estado = (bool)datos.Lector["Estado"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
