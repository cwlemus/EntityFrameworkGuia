using System;
using System.Collections.Generic;

namespace EntityFrameworkGuia.Server.Models
{
    public partial class DetFactura
    {
        public int IdDetFactura { get; set; }
        public int? IdEncFactura { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public double? Total { get; set; }

        public virtual Producto IdProducto1 { get; set; }
        public virtual EncFactura IdProductoNavigation { get; set; }
    }
}
