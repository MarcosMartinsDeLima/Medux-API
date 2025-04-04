﻿using MongoDB.Bson.Serialization.Attributes;

namespace Medux.Domain.Models
{
    public class EntidadeBase
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        [BsonElement("dataCriacao")]
        public DateTime DataCriacao { get; set; }
    }
}
