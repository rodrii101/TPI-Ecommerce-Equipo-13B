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
        public Usuario BuscarUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Usuario usuarioEncontrado = new Usuario();
                datos.setearProcedimiento("storedBuscarUsuario");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuarioEncontrado.Nombre = (string)datos.Lector["Nombre"];
                    usuarioEncontrado.Apellido = (string)datos.Lector["Apellido"];
                    usuarioEncontrado.DNI = (string)datos.Lector["Dni"];
                    usuarioEncontrado.Email = (string)datos.Lector["Email"];
                    usuarioEncontrado.Telefono = (string)datos.Lector["Telefono"];
                    usuarioEncontrado.TipoUsuario = new TipoUsuario();
                    usuarioEncontrado.TipoUsuario.IdTipoUsuario = (int)datos.Lector["IdTipoUsuario"];
                    usuarioEncontrado.Estado = (bool)datos.Lector["Estado"];
                }
                return usuarioEncontrado;
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

        public bool Loguer(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("VerificarLogin");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Pass", usuario.Pass);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
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

                    usuario.TipoUsuario = new TipoUsuario();
                    usuario.TipoUsuario.IdTipoUsuario = (int)(datos.Lector["IdTipoUsuario"]);
                    /*AGREGUE LA CARGA DE DESCRIPCION DEL TIPO DE DATO
                    usuario.TipoUsuario.Descripcion = (string)(datos.Lector["Descripcion"]);*/
                    usuario.Estado = (bool)datos.Lector["Estado"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { 
                datos.cerrarConexion();
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
                datos.setearParametro("@FechaNacimiento", usuario.FechaNacimiento == DateTime.MinValue ? (object)DBNull.Value : usuario.FechaNacimiento);
                //datos.setearParametro("@FechaNacimiento", usuario.FechaNacimiento);
                datos.setearParametro("@UrlImagen", usuario.ImagenPerfil != null ? usuario.ImagenPerfil : (object)DBNull.Value);
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

        public void RegistrarVendedor(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedRegistrarVendedor");
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Telefono", usuario.Telefono);
                datos.setearParametro("@Dni", usuario.DNI);
                datos.setearParametro("@FechaNacimiento", usuario.FechaNacimiento == DateTime.MinValue ? (object)DBNull.Value : usuario.FechaNacimiento);
                datos.setearParametro("@UrlImagen", usuario.ImagenPerfil != null ? usuario.ImagenPerfil : (object)DBNull.Value);
                datos.setearParametro("@Id", usuario.Id);
                datos.setearParametro("@IdTipoUsuario", 2);
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


        public void ActualizarPassword(int idUsuario, string nuevaPass)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuario SET Pass = @NuevaPass WHERE Id = @IdUsuario");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.setearParametro("@NuevaPass", nuevaPass);

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
