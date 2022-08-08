using Letter.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Letter.Services
{
    public class LetterService
    {
        public static string ConnectionName { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionLetter { get; set; }
        public static string JsonFile { get; set; }

        private readonly IMongoCollection<Abstrato> _lettersCollection;

        public LetterService()
        {
            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Abstrato> ConfigurationValue = mongoDatabase.GetCollection<Abstrato>(CollectionLetter);

            _lettersCollection = ConfigurationValue;
        }

        public async Task<List<Abstrato>> GetAsync() =>
            await _lettersCollection.Find(_ => true).ToListAsync();

        public async Task<Abstrato> GetAsync(string id) =>
            await _lettersCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Abstrato> GetSentenceSimpleAsync(string lesson) =>
            await _lettersCollection.Find(index => index.nome == lesson).FirstOrDefaultAsync();

        public async Task CreateAsync(Abstrato abstrato) =>
            await _lettersCollection.InsertOneAsync(abstrato);

        public async Task UpdateAsync(Abstrato abstrato) =>
            await _lettersCollection.ReplaceOneAsync(index => index.Id == abstrato.Id, abstrato);

        public async Task RemoveAsync(string id) =>
            await _lettersCollection.DeleteOneAsync(index => index.Id == id);
    }
}
