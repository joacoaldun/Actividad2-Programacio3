using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {

        public List<Marca> listar() {

            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select id, descripcion from MARCAS");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Marca aux = new Marca();

                    aux.Id = (int)datos.Lector["id"];
                    aux.NombreMarca = (string)datos.Lector["descripcion"];

                    lista.Add(aux);

                }




                return lista;
            }
            catch (Exception)
            {

                throw;
            }

            finally { 
            datos.cerrarConexion();
            }

           
        
        }

    }
}
