using MongoDB.Driver;
using Morais.Core.Model.Cliente;
using Morais.Core.Util.Constantes;
using System.Collections.Generic;

namespace Morais.Core.Service.Cliente
{
    public class ClienteService
    {
        private readonly IMongoCollection<ClienteDTO> _clientes;

        public ClienteService()
        {
            var client = new MongoClient(ConstantesSistema.MONGODBCONEXAO);
            var database = client.GetDatabase(ConstantesSistema.MONGODBDATABASE);

            _clientes = database.GetCollection<ClienteDTO>("clientes");
        }

        public IEnumerable<ClienteDTO> ObterTodosClientes()
        {
            return _clientes.Find(cliente => true).ToList();
        }

        public ClienteDTO ObterCliente(string id)
        {
            return _clientes.Find(cliente => cliente.Id == id).FirstOrDefault();
        }

        public ClienteDTO CriarCliente(ClienteDTO cliente)
        {
            _clientes.InsertOne(cliente);
            return cliente;
        }

        public void AlterarCliente(string id, ClienteDTO cliente)
        {
            _clientes.ReplaceOne(c => c.Id == id, cliente);
        }

        public void DeletarCliente(string id)
        {
            _clientes.DeleteOne(c => c.Id == id);
        }
    }
}