using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int CodigoArticulo  { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public float Precio { get; set; }
        public Marca Marcas { get; set; }

        public Categoria Categorias { get; set; }

        public List<Imagen> Imagenes { get; set;}

    }
}
