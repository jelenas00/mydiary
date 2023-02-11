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
        public async Task<User?> CreateAsync(User korisnik)
        {
            await _usersCollection.InsertOneAsync(korisnik);
            return korisnik;
        }
        public async Task<User?> UpdateAsync(User korisnik)
        {
            var use=await _usersCollection.Find(x=>x.Id==korisnik.Id).FirstOrDefaultAsync();
            if(use!=null)
            {
                use=korisnik;
            }
            if(use!=null)
                await _usersCollection.ReplaceOneAsync(x=>x.Id==use.Id,korisnik);
            return use;
        }

        public async Task<User?> UpdateEmailAsync(User korisnik)
        {
            var use=await _usersCollection.Find(x=>x.Email==korisnik.Email).FirstOrDefaultAsync();
            if(use!=null)
            {
                return null;
            }
            if(use==null)
                await _usersCollection.ReplaceOneAsync(x=>x.Id==korisnik.Id,korisnik);
            return korisnik;
        }

        public async Task<User?> UpdateUsernameAsync(User korisnik)
        {
            var use=await _usersCollection.Find(x=>x.Username==korisnik.Username).FirstOrDefaultAsync();
            if(use!=null)
            {
                return null;
            }
            if(use==null)
                await _usersCollection.ReplaceOneAsync(x=>x.Id==korisnik.Id,korisnik);
            return korisnik;
        }
        public async Task<User?> DeleteAsync(string id)
        {
            var use=await _usersCollection.Find(x=>x.Id==id).FirstOrDefaultAsync();
            if(use!=null)
            {
                await _usersCollection.DeleteOneAsync(x=>x.Id==id);
                return null;
            }
            return use;

        }
    
    }
}