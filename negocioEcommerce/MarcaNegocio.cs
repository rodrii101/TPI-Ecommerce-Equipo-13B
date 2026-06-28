using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominioEcommerce;
namespace negocioEcommerce
{
    public class MarcaNegocio
    {
        public List<Marca> listarMarca(string idMarca = "")
        {
            AccesoDatos datos = new AccesoDatos();
            List<Marca> lista = new List<Marca>();
            try
            {
                if (idMarca != "")
                {
                    datos.setearProcedimiento("BuscarMarca");
                    datos.setearParametro("@Id", int.Parse(idMarca));
                }
                else
                    datos.setearProcedimiento("ListarMarcas");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IdMarca = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
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
        public List<Marca> filtradoAvanzadoMarca(string campo, string criterio, string filtro, string estado)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Marca> listaMarca = new List<Marca>();
            try
            {
                string consulta = " SELECT Id, Descripcion, UrlImagen, Estado  FROM Marca WHERE 1 = 1 AND ";
                if (campo == "Descripcion")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Descripcion LIKE '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Descripcion LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Descripcion LIKE '%" + filtro + "%'";
                            break;
                    }
                }
                if (estado == "Activo")
                    consulta += " AND Estado = 1";
                else if(estado == "Inactivo")
                    consulta += " AND Estado = 0";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IdMarca = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    listaMarca.Add(aux);
                }
                return listaMarca;
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
        public void AgregarMarca(Marca nuevaMarca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("AgregarMarca");
                datos.setearParametro("@Descripcion", nuevaMarca.Descripcion);
                datos.setearParametro("@UrlImagen", nuevaMarca.UrlImagen);
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
        public void ModificarMarca(Marca modificarMarca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ModificarMarca");
                datos.setearParametro("@Id", modificarMarca.IdMarca);
                datos.setearParametro("@Descripcion", modificarMarca.Descripcion);
                datos.setearParametro("@UrlImagen", modificarMarca.UrlImagen);
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
        public void DesativarYActivar(int id, bool estado = false)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("CambiarEstadoMarca");
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
        public bool existeDescripcion(string descripcionMarca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Descripcion FROM Marca WHERE Descripcion = @Descripcion");
                datos.setearParametro("@Descripcion", descripcionMarca);
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
