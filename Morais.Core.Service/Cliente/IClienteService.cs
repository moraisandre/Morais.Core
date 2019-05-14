using MongoDB.Driver;
using Morais.Core.Model.Cliente;
using Morais.Core.Util.Constantes;
using System.Collections.Generic;

namespace Morais.Core.Service.Cliente
{
    public interface IClienteService
    {
        IEnumerable<ClienteDTO> ObterTodosClientes();
        ClienteDTO ObterCliente(string id);
        ClienteDTO CriarCliente(ClienteDTO cliente);
        void AlterarCliente(string id, ClienteDTO cliente);
        void DeletarCliente(string id);
        bool Funciona(string palavra);
    }
}