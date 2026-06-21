using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominioEcommerce;

namespace negocioEcommerce
{
    public class DireccionNegocio
    {
        /* public List<Direccion> listarDireccionUsuario(int idUsuario)//podria cambiar a idCliente
         {

         }*/
        public List<DireccionUsuario> listarDomiciliosUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                List<DireccionUsuario> lista = new List<DireccionUsuario>();
                datos.setearProcedimiento("listarDomiciliosUsuarios");
                datos.setearParametro("@IdUsuario", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DireccionUsuario aux = new DireccionUsuario();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Altura = (int)datos.Lector["Altura"];
                    aux.Piso = (string)datos.Lector["Piso"];
                    aux.Departamento = (string)datos.Lector["Departamento"];
                    aux.CodigoPostal = (string)datos.Lector["CodigoPostal"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Observacion = (string)datos.Lector["Observacion"];
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
        public void AgregarDireccion(int id, DireccionUsuario nuevaDireccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("AgregarDireccionUsuario");
                datos.setearParametro("@IdUsuario", id);
                datos.setearParametro("@Calle", nuevaDireccion.Calle);
                datos.setearParametro("@Altura", nuevaDireccion.Altura);
                datos.setearParametro("@Piso", nuevaDireccion.Piso);
                datos.setearParametro("@Departamento", nuevaDireccion.Departamento);
                datos.setearParametro("@CodPostal", nuevaDireccion.CodigoPostal);
                datos.setearParametro("@Localidad", nuevaDireccion.Localidad);
                datos.setearParametro("@Observacion", nuevaDireccion.Observacion);
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
        public void ModificarDireccion(DireccionUsuario nuevaDireccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("ModificarDireccion");
                datos.setearParametro("@Id", nuevaDireccion.Id);
                datos.setearParametro("@Calle", nuevaDireccion.Calle);
                datos.setearParametro("@Altura", nuevaDireccion.Altura);
                datos.setearParametro("@Piso", nuevaDireccion.Piso);
                datos.setearParametro("@Departamento", nuevaDireccion.Departamento);
                datos.setearParametro("@CodPostal", nuevaDireccion.CodigoPostal);
                datos.setearParametro("@Localidad", nuevaDireccion.Localidad);
                datos.setearParametro("@Observacion", nuevaDireccion.Observacion);
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
        public DireccionUsuario BuscarDireccion(int idDireccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("BuscarDireccion");
                datos.setearParametro("@IdDireccion", idDireccion);
                datos.ejecutarLectura();
                DireccionUsuario aux = new DireccionUsuario();
                if (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Altura = (int)datos.Lector["Altura"];
                    aux.Piso = (string)datos.Lector["Piso"];
                    aux.Departamento = (string)datos.Lector["Departamento"];
                    aux.CodigoPostal = (string)datos.Lector["CodigoPostal"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Observacion = (string)datos.Lector["Observacion"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                }
                return aux;
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