using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Xml.Linq;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace Negocio
{
    public class ArticuloNegocio
    {
        //LISTAR ARTICULOS
        public List<Articulo> listar()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT a.Id, Codigo, Nombre, a.Descripcion as DescripcionArticulo, Precio, m.Descripcion as NombreMarca, c.Descripcion as NombreCategoria, i.ImagenUrl as imagen from ARTICULOS a \r\ninner join MARCAS m on a.IdMarca=m.Id\r\nleft join CATEGORIAS c on a.IdCategoria=c.Id\r\ninner join IMAGENES i on a.Id=i.IdArticulo ");
                datos.ejecutarConsulta();
                List<Articulo> lista = new List<Articulo>();
                

                while (datos.Lector.Read())
                {
                    //Validaciones BD
                    string codigoArt = datos.Lector["Codigo"]==DBNull.Value?"Sin codigo": (string)datos.Lector["Codigo"];
                    string descripcion = datos.Lector["DescripcionArticulo"]==DBNull.Value?"Sin descripcion": (string)datos.Lector["DescripcionArticulo"];
                    decimal precio = datos.Lector["Precio"]==DBNull.Value? 0:(decimal)datos.Lector["Precio"];
                    string nombre = datos.Lector["Nombre"]==DBNull.Value?"Sin nombre": (string)datos.Lector["Nombre"];
                    string urlImagen = datos.Lector["imagen"] == DBNull.Value ? "https://t3.ftcdn.net/jpg/02/48/42/64/240_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg" : (string)datos.Lector["imagen"];
                    string categorias = datos.Lector["NombreCategoria"]==DBNull.Value? "Sin categoria": (string)datos.Lector["NombreCategoria"];
                    string marcas= datos.Lector["NombreMarca"]==DBNull.Value? "Sin marca": (string)datos.Lector["NombreMarca"];
                    

                    //Verificamos si el articulo existe
                    Articulo articulo = lista.FirstOrDefault(a => a.CodigoArticulo == codigoArt);
                    if (articulo == null)
                    {
                        // Si no existe, creamos un nuevo artículo y lo agregamos a la lista
                        
                        articulo = new Articulo

                        {
                            CodigoArticulo = codigoArt,
                            Nombre = nombre,
                            Descripcion = descripcion,
                            Precio = precio,
                            Categorias = new Categoria { NombreCategoria = categorias },
                            Marcas = new Marca { NombreMarca = marcas },
                            imagenes = new List<string>() // Inicializamos la lista de imagenes del artículo
                        };
                        lista.Add(articulo);
                    }
                    //Si existe, agregamos la URL de la imagen a la lista de imagenes del artículo
                    articulo.imagenes.Add(urlImagen);


                }
                //cerramos conexion
                datos.cerrarConexion();
                //retornamos lista
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
