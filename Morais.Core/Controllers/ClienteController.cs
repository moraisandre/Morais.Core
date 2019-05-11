using MongoDB.Bson;
using MongoDB.Driver;
using Morais.Core.Model.Cliente;
using Morais.Core.Service.Cliente;
using Morais.Core.Util.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Morais.Core.Controllers
{
    [RoutePrefix("cliente")]
    public class ClienteController : ApiController
    {
        private readonly ClienteService _service = new ClienteService();

        [HttpGet]
        [Route("clientes/")]
        public IEnumerable<ClienteDTO> Get()
        {
            return _service.ObterTodosClientes();
        }

        [HttpGet]
        [Route("clientes/{id}")]
        public ClienteDTO Get(string id)
        {
            return _service.ObterCliente(id);
        }

        [HttpPost]
        [Route("clientes/")]
        public ClienteDTO Post([FromBody]ClienteDTO cliente)
        {
            return _service.CriarCliente(cliente);
        }

        [HttpPut]
        [Route("clientes/{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        [Route("clientes/{id}")]
        public void Delete(int id)
        {
        }
    }
}
