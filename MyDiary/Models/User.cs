using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyDiary.Models{
    public class User{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}=null!;
        [BsonElement("name")]
        public string Name { get; set; }=null!;
        [BsonElement("lastname")]
        public string LastName { get; set; }=null!;
        [BsonElement("email")]
        public string Email { get; set; }=null!;
        [BsonElement("username")]
        public string Username { get; set; }=null!;
        [BsonElement("password")]
        public string Password { get; set; }=null!;
        [BsonElement("diary")]
        public string Diary { get; set; }=null!;
        [BsonElement("birthday")]
        public string Birthday { get; set; }=null!;
    }
}