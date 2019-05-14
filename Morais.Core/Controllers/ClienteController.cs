using Morais.Core.Model.Cliente;
using Morais.Core.Service.Cliente;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Morais.Core.Controllers
{
    /// <summary>
    /// API Responsável pelo CRUD de clientes no sistema
    /// </summary>
    [RoutePrefix("cliente")]
    public class ClienteController : ApiController
    {
        private static readonly Lazy<IClienteService> _service = new Lazy<IClienteService>(() => new ClienteService());

        /// <summary>
        /// Obtém todos os clientes cadastrados na base
        /// </summary>
        /// <returns>Lista com os clientes salvos no banco de dados</returns>
        [HttpGet]
        [Route("clientes/")]
        public IEnumerable<ClienteDTO> Get()
        {
            return _service.Value.ObterTodosClientes();
        }

        /// <summary>
        /// Obtém somente um cliente do banco de dados
        /// </summary>
        /// <param name="id">Id do cliente no mongodb</param>
        /// <returns>Cliente caso haja um como o id passado</returns>
        [HttpGet]
        [Route("clientes/{id}")]
        public ClienteDTO Get(string id)
        {
            return _service.Value.ObterCliente(id);
        }

        /// <summary>
        /// Cria um cliente no banco de dados
        /// </summary>
        /// <param name="cliente">DTO do cliente à ser criado</param>
        /// <returns>Cliente recém criado</returns>
        [HttpPost]
        [Route("clientes/")]
        public ClienteDTO Post([FromBody]ClienteDTO cliente)
        {
            return _service.Value.CriarCliente(cliente);
        }

        /// <summary>
        /// Altera o cliente no banco de dados
        /// </summary>
        /// <param name="id">Id do cliente no mongodb</param>
        /// <param name="cliente">DTO do cliente à ser alterado</param>
        [HttpPut]
        [Route("clientes/{id}")]
        public void Put(string id, [FromBody]ClienteDTO cliente)
        {
            _service.Value.AlterarCliente(id, cliente);
        }

        /// <summary>
        /// Deleta o cliente no banco de dados
        /// </summary>
        /// <param name="id">Id do cliente no mongodb</param>
        [HttpDelete]
        [Route("clientes/{id}")]
        public void Delete(string id)
        {
            _service.Value.DeletarCliente(id);
        }
    }
}
