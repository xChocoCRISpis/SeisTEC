using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
//using System.ComponentModel.DataAnnotations;
//using SeisTec.CustomAttributes;



namespace SeisTec.Models
{
    public class LlamadasModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("id_telefono")]
        public int IdTelefono { get; set; }

        [BsonElement("llamada")]
        public List<llamada> Llamada { get; set; }

    }

    public class llamada
    {
        [BsonElement("fecha")]
        public DateTime Fecha { get; set; }

        [BsonElement("inicio")]
        public DateTime Inicio { get; set; }

        [BsonElement("fin")]
        public DateTime Fin { get; set; }

        [BsonElement("duracion")]
        public int Duracion { get; set; }

        [BsonElement("compania")]
        public string Compania { get; set; }

        [BsonElement("telefono_id")]
        public int TelefonoId { get; set; }
    }
}
