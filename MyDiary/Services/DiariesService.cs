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
    
        public async Task<Diary?> CreateAsync(Diary dnevnik)
        {
           await _diariesCollection.InsertOneAsync(dnevnik);
            return dnevnik;
        }
        public async Task<Diary?> UpdateAsync(Diary dnevnik)
        {
            var use=await _diariesCollection.Find(x=>x.Id==dnevnik.Id).FirstOrDefaultAsync();
            if(use!=null)
            {
                use=dnevnik;
            }
            if(use!=null)
                await _diariesCollection.ReplaceOneAsync(x=>x.Id==use.Id,dnevnik);
            return use;
        }
        public async Task<Diary?> DeleteAsync(string id)
        {
            var use=await _diariesCollection.Find(x=>x.Id==id).FirstOrDefaultAsync();
            if(use!=null)
            {
                await _diariesCollection.DeleteOneAsync(x=>x.Id==id);
                return null;
            }
            return use;

        }    }
}