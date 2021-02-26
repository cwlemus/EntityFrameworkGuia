using EntityFrameworkGuia.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkGuia.Server.Controllers
{
    [ApiController]
    public class ClienteController : Controller
    {
        [HttpGet]
        [Route("api/Clientes/Get")]
        public List<Cliente> Get()
        {
            List<Cliente> lista = new List<Cliente>();
            using (Facturacion_DBContext db = new Facturacion_DBContext())
            {
                lista = (from clte in db.Cliente                         
                         select new Cliente
                         {
                             IdCliente=clte.IdCliente,
                             Nombre=clte.Nombre,
                             Apellido=clte.Apellido,
                             Telefono=clte.Telefono
                         }).ToList();
            }
            return lista;

        }

        [HttpPost]
        [Route("api/AddCliente")]
        public String AddCliente()
        {
            string retorno = "";
            using (var context = new Facturacion_DBContext())
            {
                var clte = new Cliente()
                {
                    Nombre = "Jose",
                    Apellido = "Rugamas",
                    Telefono = "333"
                };
                context.Cliente.Add(clte);
                context.SaveChanges();
                retorno = "Cliente agrego con exito....";
            }
            return retorno;
        }


        [HttpGet]
        [Route("api/MayorEdadLamda")]
        public String MayorEdadLamda()
        {

            /* Func<int, string> MayoriaEdad = delegate (int edad)
                {
                    return edad >= 18 ? "Mayor Edad" : "Menor Edad";
                };*/
                Func<int, string> MayoriaEdad = edad => edad >= 18 ? "Mayor Edad" : "Menor Edad";

            int[] numeros = { 1, 2, 3, 4 };
            var numerosCuadrado =String.Join(" ",numeros.Select(x => x * x));
            List<Cliente> cltes = new List<Cliente>()
            {
                new Cliente()
                {
                    IdCliente=1,
                    Nombre="Carlos",
                    Apellido="Lemus",
                    Telefono="23444477"
                },
                new Cliente()
                {
                    IdCliente=2,
                    Nombre="Jose",
                    Apellido="Lemus",
                    Telefono="77334488"
                }
            };
            Cliente clte=new Cliente();
            clte = cltes.Where(c => c.IdCliente == 1).First();
            String datos = String.Format("Nombre: {0}\n Apellido: {1}\n Telefono:{2}\n", clte.Nombre, clte.Apellido, clte.Telefono);
            //return MayoriaEdad(18) ;
            //return numerosCuadrado;
            return datos;
            
        }

        [HttpGet]
        [Route("api/MayorEdad")]
        public string MayorEdad()
        {
            string salida = "";

            Func<int, string> MayoriaEdad = VerificaEdad;

            salida = VerificaEdad(18);

            return salida;
        } 

        private string VerificaEdad(int numero)
        {
            if (numero >= 18)
            {
                return "Mayor de edad";
            }
            else
            {
                return "Menor de Edad";
            }
        }

        [HttpGet]
        [Route("api/Cliente/Filtrar/{data?}")]
        public List<Cliente> Filtrar(string data)
        {
            List<Cliente> lista = new List<Cliente>();
            using (Facturacion_DBContext db = new Facturacion_DBContext())
            {
                if (data == null)
                {
                    lista = (from clte in db.Cliente
                             select new Cliente
                             {
                                 IdCliente = clte.IdCliente,
                                 Nombre = clte.Nombre,
                                 Apellido = clte.Apellido,
                                 Telefono = clte.Telefono
                             }).ToList();
                }

                else
                {
                    lista = (from clte in db.Cliente
                             where clte.IdCliente.ToString().Contains(data) || clte.Nombre.Contains(data) || 
                                   clte.Apellido.Contains(data) || clte.Telefono.Contains(data)
                             select new Cliente
                             {
                                 IdCliente = clte.IdCliente,
                                 Nombre = clte.Nombre,
                                 Apellido = clte.Apellido,
                                 Telefono = clte.Telefono
                             }).ToList();

                }
            }
            return lista;

        }



    }
}
