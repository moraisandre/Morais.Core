using Morais.Core.Util.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Morais.Core.Model.Cliente
{
    public class ClienteDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("documento")]
        public string Documento;

        [BsonElement("TipoPessoa")]
        public TipoPessoa TipoPessoa;

        [BsonElement("Nome")]
        public string Nome;

        [BsonElement("Endereco")]
        public string Endereco;

        [BsonElement("Email")]
        public string Email;
    }
}