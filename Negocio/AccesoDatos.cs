using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
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

            conexion = new SqlConnection("server=.\\SQLLaboratorio; database=POKEDEX_DB; integrated security=true;");
            comando = new SqlCommand();

        }

        public void setearConsulta(string consulta)
        {

            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarConsulta()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                //EJECUTO LA LECTURA
                lector = comando.ExecuteReader();


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void cerrarConexion()
        {

            if (lector != null)
                lector.Close();

            conexion.Close();


        }



    }
}
