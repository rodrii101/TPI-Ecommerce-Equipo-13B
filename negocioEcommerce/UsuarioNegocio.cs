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
        //public List<Usuario> listarusuarios(string id ="")
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
        //            auxusuario.DNI = (string)datos.Lector["DNI"];
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

        public bool Loguer(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("VerificarLogin");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Pass", usuario.Pass);
                datos.ejecutarLectura();
                while (datos.Lector.Read()){
                    usuario.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["Apellido"];

                    if (!(datos.Lector["Dni"] is DBNull))
                        usuario.DNI = (string)datos.Lector["Dni"];

                    if (!(datos.Lector["Telefono"] is DBNull))
                        usuario.Telefono = (string)datos.Lector["Telefono"];

                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                        usuario.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString());
        
                    if (!(datos.Lector["ImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["ImagenPerfil"];

                    usuario.TipoUsuario.IdTipoUsuario = (int)(datos.Lector["IdTipoUsuario"]);
                    usuario.Estado = (bool)datos.Lector["Estado"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EditarPerfil(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("EditarPerfil");
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Telefono", usuario.Telefono);
                datos.setearParametro("@Dni", usuario.DNI);
                datos.setearParametro("@FechaNacimiento", usuario.FechaNacimiento);
                datos.setearParametro("@UrlImagen", usuario.ImagenPerfil);
                datos.setearParametro("@Id", usuario.Id);
                
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
       

        public int Registrar(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedAltaUsuario");
                datos.setearParametro("@Email", user.Email);
                datos.setearParametro("@Pass", user.Pass);
                datos.setearParametro("@IdTipoUsuario", 1);
                datos.setearParametro("@Estado", 1);
                return datos.ejecutarScalar();

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

        public bool existeCuenta(string email)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Email FROM Usuario WHERE Email = @Email");
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    return true;
                }

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
