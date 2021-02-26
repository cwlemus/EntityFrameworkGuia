using System;
using System.Collections.Generic;

namespace EntityFrameworkGuia.Server.Models
{
    public partial class EncFactura
    {
        public EncFactura()
        {
            DetFactura = new HashSet<DetFactura>();
        }

        public int IdFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public string FormaPago { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<DetFactura> DetFactura { get; set; }
    }
}
