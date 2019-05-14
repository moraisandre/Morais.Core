using Morais.Core.Model.Cliente;
using Morais.Core.Service.Cliente;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Morais.Core.Controllers
{
    [RoutePrefix("cliente")]
    public class ClienteController : ApiController
    {
        private static readonly Lazy<IClienteService> _service = new Lazy<IClienteService>(() => new ClienteService());

        [HttpGet]
        [Route("clientes/")]
        public IEnumerable<ClienteDTO> Get()
        {
            return _service.Value.ObterTodosClientes();
        }

        [HttpGet]
        [Route("clientes/{id}")]
        public ClienteDTO Get(string id)
        {
            return _service.Value.ObterCliente(id);
        }

        [HttpPost]
        [Route("clientes/")]
        public ClienteDTO Post([FromBody]ClienteDTO cliente)
        {
            return _service.Value.CriarCliente(cliente);
        }

        [HttpPut]
        [Route("clientes/{id}")]
        public void Put(string id, [FromBody]ClienteDTO cliente)
        {
            _service.Value.AlterarCliente(id, cliente);
        }

        [HttpDelete]
        [Route("clientes/{id}")]
        public void Delete(string id)
        {
            _service.Value.DeletarCliente(id);
        }
    }
}
