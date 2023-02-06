using MyDiary.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MyDiary.Services{
    public class UsersService{
        private readonly IMongoCollection<User> _usersCollection;

        public UsersService(IOptions<MyDiaryDatabaseSettings> MyDiaryDatabaseSettings) {
            var mongoClient = new MongoClient(MyDiaryDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(MyDiaryDatabaseSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<User>( MyDiaryDatabaseSettings.Value.UsersCollectionName);
        }
        public async Task<List<User>> GetAsync() => await _usersCollection.Find(_ => true).ToListAsync();
        public async Task<User?> GetAsync(string id) =>await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}