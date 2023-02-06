using MyDiary.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MyDiary.Services{
    public class PagesService{
        private readonly IMongoCollection<Page> _pagesCollection;

        public PagesService(IOptions<MyDiaryDatabaseSettings> MyDiaryDatabaseSettings) {
            var mongoClient = new MongoClient(MyDiaryDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(MyDiaryDatabaseSettings.Value.DatabaseName);

            _pagesCollection = mongoDatabase.GetCollection<Page>( MyDiaryDatabaseSettings.Value.PagesCollectionName);
        }
        public async Task<List<Page>> GetAsync() => await _pagesCollection.Find(_ => true).ToListAsync();
        public async Task<Page?> GetAsync(string id) =>await _pagesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}