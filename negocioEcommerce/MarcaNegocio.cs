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
        public void AgregarMarca(Marca nuevaMarca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("AgregarMarca");
                datos.setearParametro("@Descripcion", nuevaMarca.Descripcion);
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
        public void DesativarYActivar(int id,bool estado = false)
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
    }
}
