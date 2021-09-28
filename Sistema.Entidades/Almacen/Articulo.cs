using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Entidades.Almacen
{
    class Articulo
    {
       public int Codigo { get; set; }

       public string Nombre { get; set; }

        public int Precio_venta { get; set; }

        public int Stock { get; set; }

        public string Descripcion { get; set; }

        public bool condicion { get; set; }
    }
}
