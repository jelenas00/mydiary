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
        public async Task<List<Page>> GetAsyncDate(string date) =>await _pagesCollection.Find(x => x.Datetime == date).ToListAsync();
         public async Task<Page?> CreateAsync(Page stranice)
        {
            await _pagesCollection.InsertOneAsync(stranice);
            return stranice;
        }
        public async Task<Page?> UpdateAsync(Page stranice)
        {
            var use=await _pagesCollection.Find(x=>x.Id==stranice.Id).FirstOrDefaultAsync();
            if(use!=null)
            {
                use=stranice;
            }
            if(use!=null)
                await _pagesCollection.ReplaceOneAsync(x=>x.Id==use.Id,stranice);
            return use;
        }
        public async Task<Page?> DeleteAsync(string id)
        {
            var use=await _pagesCollection.Find(x=>x.Id==id).FirstOrDefaultAsync();
            if(use!=null)
            {
                await _pagesCollection.DeleteOneAsync(x=>x.Id==id);
                return null;
            }
            return use;

        }
    }
}