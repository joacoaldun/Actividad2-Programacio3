﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {

            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select id, descripcion from CATEGORIAS");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Categoria aux = new Categoria();

                    aux.Id = (int)datos.Lector["id"];
                    aux.NombreCategoria = (string)datos.Lector["descripcion"];

                    lista.Add(aux);

                }




                return lista;
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                datos.cerrarConexion();
            }



        }


        public void agregar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("Insert into Categorias(Descripcion) values (@Descripcion)");
                datos.setearParametros("@Descripcion", categoria.NombreCategoria);

                datos.ejecutarAccion();


            }
            catch (Exception)
            {


                throw;
            }
            finally
            {

                datos.cerrarConexion();
            }






        }

    }
}
