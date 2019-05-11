using MongoDB.Driver;
using Morais.Core.Model.Cliente;
using System.Collections.Generic;

namespace Morais.Core.Service.Cliente
{
    public class ClienteService
    {
        private readonly IMongoCollection<ClienteDTO> _clientes;

        public ClienteService()
        {
            var client = new MongoClient("mongodb+srv://admin:admin@moraiscluster-xdmnl.mongodb.net/moraisdb?connect=replicaSet");
            var database = client.GetDatabase("moraisdb");

            _clientes = database.GetCollection<ClienteDTO>("clientes");
        }

        public IEnumerable<ClienteDTO> ObterTodosClientes()
        {
            return _clientes.Find(cliente => true).ToList();
        }
    }
}