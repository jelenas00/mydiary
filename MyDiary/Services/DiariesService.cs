using MyDiary.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MyDiary.Services{
    public class DiariesService{
        private readonly IMongoCollection<Diary> _diariesCollection;

        public DiariesService(IOptions<MyDiaryDatabaseSettings> MyDiaryDatabaseSettings) {
            var mongoClient = new MongoClient(MyDiaryDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(MyDiaryDatabaseSettings.Value.DatabaseName);

            _diariesCollection = mongoDatabase.GetCollection<Diary>( MyDiaryDatabaseSettings.Value.DiariesCollectionName);
        }
        public async Task<List<Diary>> GetAsync() => await _diariesCollection.Find(_ => true).ToListAsync();
        public async Task<Diary?> GetAsync(string id) =>await _diariesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}