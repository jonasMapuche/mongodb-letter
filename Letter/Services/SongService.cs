using Letter.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Letter.Services
{
    public class SongService
    {
        public static string ConnectionName { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionSong { get; set; }
        public static string JsonFile { get; set; }

        private readonly IMongoCollection<Musica> _songsCollection;

        public SongService()
        {
            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Musica> ConfigurationValue = mongoDatabase.GetCollection<Musica>(CollectionSong);

            _songsCollection = ConfigurationValue;
        }

        public async Task<List<Musica>> GetAsync() =>
            await _songsCollection.Find(_ => true).ToListAsync();

        public async Task<Musica> GetAsync(string id) =>
            await _songsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Musica musica) =>
            await _songsCollection.InsertOneAsync(musica);

        public async Task UpdateAsync(Musica musica) =>
            await _songsCollection.ReplaceOneAsync(index => index.Id == musica.Id, musica);

        public async Task RemoveAsync(string id) =>
            await _songsCollection.DeleteOneAsync(index => index.Id == id);

    }
}
