using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SeisTec.Models;

namespace SeisTec.Services
{
    public class LlamadasService
    {

        private readonly IMongoCollection<LlamadasModel> Llamadas_col;
        private readonly ILogger<LlamadasService> _logger;

        public LlamadasService(IConfiguration config, ILogger<LlamadasService> logger)
        {
            _logger = logger;

            MongoClient client = new MongoClient(config.GetConnectionString("SeisTel"));
            IMongoDatabase database = client.GetDatabase("SeisTel");
            _logger.LogInformation("Conexión establecida con MongoDB");
            Llamadas_col = database.GetCollection<LlamadasModel>("llamadas"); //Nombre Collection en Mongo

        }

        public List<LlamadasModel> Get()
        {
            return Llamadas_col.Find(llamada => true).ToList();
        }

        public LlamadasModel Get(string id)
        {
            return Llamadas_col.Find(llamada => llamada.Id == id).FirstOrDefault();
        }

        public LlamadasModel Create(LlamadasModel llamada)
        {
            Llamadas_col.InsertOne(llamada);
            return llamada;
        }

        public void Update(string id, LlamadasModel LlamadasIn)
        {
            Llamadas_col.ReplaceOne(llamada => llamada.Id == id, LlamadasIn);
        }

        public void Remove(LlamadasModel LlamadasIn)
        {
            Llamadas_col.DeleteOne(llamada => llamada.Id == LlamadasIn.Id);
        }

        public void Remove(string id)
        {
            Llamadas_col.DeleteOne(llamada => llamada.Id == id);
        }

        public int GetLastTelefonoId()
        {
            var lastTelefono = Llamadas_col.Find(_ => true)
            .SortByDescending(t => t.IdTelefono).FirstOrDefault();
            return lastTelefono != null ? lastTelefono.IdTelefono : 0;
        }

        public void AddNewTelefono()
        {
            int newId = GetLastTelefonoId() + 1;
            LlamadasModel newTelefono = new LlamadasModel
            {
                IdTelefono = newId,
                Llamada = new List<llamada> { }
            };
            Create(newTelefono);
        }

        public void AddLlamada(int idTelefono, llamada nuevaLlamada)
        {
            var filter = Builders<LlamadasModel>.Filter.Eq("IdTelefono", idTelefono);
            var update = Builders<LlamadasModel>.Update.Push("Llamada", nuevaLlamada);
            var result = Llamadas_col.UpdateOne(filter, update);
            _logger.LogInformation("IdTelefono : ", idTelefono);
            _logger.LogInformation("Resultado de la actualización: {MatchedCount}, {ModifiedCount}", result.MatchedCount, result.ModifiedCount);

        }
    }
}
