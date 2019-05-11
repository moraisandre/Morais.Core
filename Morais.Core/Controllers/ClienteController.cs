using Morais.Core.Model.Cliente;
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

        private readonly Cliente[] clientes = new Cliente[]
        {
            new Cliente { Documento = "38760036877", Nome = "André Morais", TipoPessoa = TipoPessoa.PF, Endereco = "Rua gilda", Email = "teste@teste.com.br"},
            new Cliente { Documento = "12312312333", Nome = "Bill", TipoPessoa = TipoPessoa.PF, Endereco = "Rua gilda 12", Email = "teste3@teste.com.br"},
            new Cliente { Documento = "32132132133222", Nome = "Jim", TipoPessoa = TipoPessoa.PJ, Endereco = "Rua gilda 321", Email = "teste4@teste.com.br"},
            new Cliente { Documento = "45645645644", Nome = "Test", TipoPessoa = TipoPessoa.PF, Endereco = "Rua gilda 123", Email = "teste5@teste.com.br"},
            new Cliente { Documento = "65464565444333", Nome = "Steve", TipoPessoa = TipoPessoa.PJ, Endereco = "Rua gilda 1111", Email = "teste6@teste.com.br"}
        };

        [HttpGet]
        [Route("clientes/")]
        public IEnumerable<Cliente> Get()
        {
            return clientes;
        }

        [HttpGet]
        [Route("clientes/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("clientes/")]
        public void Post([FromBody]string value)
        {
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
