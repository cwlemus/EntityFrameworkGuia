using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkGuia.Server.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
    }
}
