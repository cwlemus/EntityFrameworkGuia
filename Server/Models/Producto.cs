using System;
using System.Collections.Generic;

namespace EntityFrameworkGuia.Server.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetFactura = new HashSet<DetFactura>();
        }

        public int IdProducto { get; set; }
        public string Producto1 { get; set; }
        public double? Precio { get; set; }

        public virtual ICollection<DetFactura> DetFactura { get; set; }
    }
}
