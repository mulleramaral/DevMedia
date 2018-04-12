using ServicoWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServicoWebApi.Controllers
{
    public class ClienteController : ApiController
    {
        Cliente[] clientes = new Cliente[]
        {
            new Cliente { Id = 1, Nome = "Guinter", Email = "guinter@gmail.com"},
            new Cliente { Id = 2, Nome = "Miiller", Email = "miilleramaral@gmail.com"}
        };

        public IEnumerable<Cliente> getClientes()
        {
            return clientes;
        }

        public IHttpActionResult getCliente(int id)
        {
            var cli =  clientes.FirstOrDefault(c => c.Id == id);
            return Ok(cli);
        }

    }
}
