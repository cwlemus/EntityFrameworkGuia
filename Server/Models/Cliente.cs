using System;
using System.Collections.Generic;

namespace EntityFrameworkGuia.Server.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            EncFactura = new HashSet<EncFactura>();
        }

        public Cliente(int idCliente, string nombre, string apellido, string telefono)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<EncFactura> EncFactura { get; set; }
    }
}
