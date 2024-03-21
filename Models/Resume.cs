using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ApiAngularJose.Models
{
    public class Resume
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id = string.Empty;

        [BsonElement("Experiencia")]
        public string Experiencia { get; set; }

        [BsonElement("Certificados")]
        public string Certificados { get; set; }

        [BsonElement("Skills")]
        public string Skills { get; set; }
    }
}
