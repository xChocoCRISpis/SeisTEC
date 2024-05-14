using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SeisTec.Models
{
    public class MensajesModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("id_telefono")]
        public int IdTelefono { get; set; }

        [BsonElement("mensaje")]
        public List<mensaje> Mensaje { get; set; }
    }

    public class mensaje
    {
        [BsonElement("num_telefono")]
        public string NumTelefono { get; set; }

        [BsonElement("compania")]
        public string Compania { get; set; }
    }
}
