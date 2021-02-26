using System;
using System.Collections.Generic;

namespace EntityFrameworkGuia.Server.Models
{
    public partial class Menuitem
    {
        public int Id { get; set; }
        public int IdPadre { get; set; }
        public string Nombre { get; set; }
        public string Accion { get; set; }
        public string Controlador { get; set; }
    }
}
