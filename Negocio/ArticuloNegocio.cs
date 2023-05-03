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
                datos.setearConsulta("SELECT a.Id, Codigo, Nombre, a.Descripcion as DescripcionArticulo, Precio, m.Descripcion as NombreMarca, c.Descripcion as NombreCategoria, i.ImagenUrl as imagen from ARTICULOS a \r\ninner join MARCAS m on a.IdMarca=m.Id\r\nleft join CATEGORIAS c on a.IdCategoria=c.Id\r\nleft join IMAGENES i on a.Id=i.IdArticulo ");
                datos.ejecutarConsulta();
                List<Articulo> lista = new List<Articulo>();
                

                while (datos.Lector.Read())
                {
                    //Validaciones BD
                    int id = (int)datos.Lector["Id"]; 
                    string codigoArt = datos.Lector["Codigo"]==DBNull.Value?"Sin codigo": (string)datos.Lector["Codigo"];
                    string descripcion = datos.Lector["DescripcionArticulo"]==DBNull.Value?"Sin descripcion": (string)datos.Lector["DescripcionArticulo"];
                    decimal precio = datos.Lector["Precio"]==DBNull.Value? 0:(decimal)datos.Lector["Precio"];
                    string nombre = datos.Lector["Nombre"]==DBNull.Value?"Sin nombre": (string)datos.Lector["Nombre"];
                    string urlImagen = datos.Lector["imagen"] == DBNull.Value ? "https://t3.ftcdn.net/jpg/02/48/42/64/240_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg" : (string)datos.Lector["imagen"];
                    string categorias = datos.Lector["NombreCategoria"]==DBNull.Value? "Sin categoria": (string)datos.Lector["NombreCategoria"];
                    string marcas= datos.Lector["NombreMarca"]==DBNull.Value? "Sin marca": (string)datos.Lector["NombreMarca"];
                    

                    //Verificamos si el articulo existe
                    Articulo articulo = lista.FirstOrDefault(a => a.Id == id);
                    if (articulo == null)
                    {
                        // Si no existe, creamos un nuevo artículo y lo agregamos a la lista
                        
                        articulo = new Articulo

                        {
                            Id = id,
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
                //datos.cerrarConexion();
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

        public void Agregar(Articulo articulo) { 
        
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("INSERT into Articulos(Codigo, Nombre, Descripcion, IdMarca, IdCategoria,Precio) values(@Codigo, @Nombre, @Descripcion,@IdMarca,@IdCategoria,@Precio)");

                datos.setearParametros("@Codigo", articulo.CodigoArticulo);
                datos.setearParametros("@Nombre", articulo.Nombre);
                datos.setearParametros("@Descripcion", articulo.Descripcion);
                datos.setearParametros("@IdMarca", articulo.Marcas.Id);
                datos.setearParametros("@IdCategoria", articulo.Categorias.Id);
                datos.setearParametros("@Precio", articulo.Precio);

                datos.ejecutarAccion();


               




            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                datos.cerrarConexion();
                

            }

           
        
        }

        public int BuscarUltimoId() {

            AccesoDatos datos = new AccesoDatos();
             

          try
            {
                List<Articulo> lista2 = new List<Articulo>();

                lista2 = this.listar();

                int ultimoId = 0;
                
                foreach (var item in lista2)
                {
                    ultimoId = item.Id;
                }
                
                


                return ultimoId;
                

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
        
        
        public void AgregarImagenes(Articulo articulo) { 
        
           int idArticulo = BuscarUltimoId();

            AccesoDatos datos   =  new AccesoDatos();

            try
            { 
                
                foreach (var item in articulo.imagenes)
                {
                    datos.setearConsulta("insert into imagenes(idArticulo, ImagenUrl) values ("+ idArticulo +", '" + articulo.imagenes  + "' )");
                   
                    datos.ejecutarAccion();
                }

               
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
