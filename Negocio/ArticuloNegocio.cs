using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Xml.Linq;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar()
        {

            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                

                datos.setearConsulta("Select Codigo, Nombre, a.Descripcion as DescripcionArticulo, Precio , m.Descripcion as NombreMarca, c.Descripcion as NombreCategoria, i.ImagenUrl as imagen from ARTICULOS as a\r\ninner join MARCAS as m on a.IdMarca = m.Id\r\ninner join CATEGORIAS as c on a.IdCategoria = c.Id\r\ninner join IMAGENES as i on i.IdArticulo = a.Id");
                datos.ejecutarConsulta();


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["DescripcionArticulo"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Marcas = new Marca();
                    aux.Marcas.NombreMarca = (string)datos.Lector["NombreMarca"];
                    aux.Categorias = new Categoria();
                    aux.Categorias.NombreCategoria = (string)datos.Lector["NombreCategoria"];
                    //aux.Imagenes = (List<string>)datos.Lector["imagen"];

                    lista.Add(aux);

                }
                return
                    lista;
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
