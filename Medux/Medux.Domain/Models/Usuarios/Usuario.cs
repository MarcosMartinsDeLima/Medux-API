using Medux.Domain.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Medux.Domain.Models.Usuarios
{
    public class Usuario : EntidadeBase
    {
        [BsonElement("nome")]
        public string Nome { get; set; }
        [BsonElement("email")]
        public string Email { get; set; } 
        [BsonElement("senha")]
        public string Senha { get; set; } 
        [BsonElement("imagemPerfil")]
        public byte[] Imagem { get; set; }
    }
}
