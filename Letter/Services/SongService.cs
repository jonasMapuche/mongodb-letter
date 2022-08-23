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

        private readonly IMongoCollection<Registro> _songsCollection;

        public SongService()
        {
            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Registro> ConfigurationValue = mongoDatabase.GetCollection<Registro>(CollectionSong);

            _songsCollection = ConfigurationValue;
        }

        public async Task<List<Registro>> GetAsync() =>
            await _songsCollection.Find(_ => true).ToListAsync();

        public async Task<Registro> GetAsync(string id) =>
            await _songsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Registro> GetSongAsync(string nota) =>
            await _songsCollection.Find(index => index.nota.letra.Find(index2 => index2.nome == nota && index2.acidente == "").nome != "").FirstOrDefaultAsync();

        public async Task<List<Registro>> GetSongNextAsync(float frequencia, int ordem) =>
            await _songsCollection.Find(index => index.nota.frequencia > frequencia).Limit(ordem).ToListAsync();

        public async Task CreateAsync(Registro registro) =>
            await _songsCollection.InsertOneAsync(registro);

        public async Task UpdateAsync(Registro registro) =>
            await _songsCollection.ReplaceOneAsync(index => index.Id == registro.Id, registro);

        public async Task RemoveAsync(string id) =>
            await _songsCollection.DeleteOneAsync(index => index.Id == id);

    }
}
