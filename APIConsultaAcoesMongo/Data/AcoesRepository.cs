using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using APIConsultaAcoesMongo.Documents;

namespace APIConsultaAcoesMongo.Data
{
    public class AcoesRepository
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<AcaoDocument> _collection;

        public AcoesRepository(IConfiguration configuration)
        {
            _client = new MongoClient(
                configuration["MongoDB:Connection"]);
            _db = _client.GetDatabase(
                configuration["MongoDB:Database"]);
            _collection = _db.GetCollection<AcaoDocument>(
                configuration["MongoDB:Collection"]);
        }

        public List<AcaoDocument> ListAll()
        {
            return _collection.Find(all => true).ToEnumerable()
                .OrderByDescending(d => d.Data).ToList();
        }
    }
}