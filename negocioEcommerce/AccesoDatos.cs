using dominioEcommerce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace negocioEcommerce
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=localhost; database=DB_Ecommerce; user id=sa; password=BaseDatos#2;");
            //conexion = new SqlConnection("server=localhost; database=DB_Ecommerce; user id=sa; password=Sql1234!;");
            comando = new SqlCommand();
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if (lector != null)
            {
                conexion.Close();
            }
            conexion.Close();
        }
        public void setearProcedimiento(string procedimiento)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedimiento;
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public int ejecutarScalar()//conseguir el nuevo id
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                return Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void limpiarParametros()
        {
            comando.Parameters.Clear();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
    }
}
