using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyDiary.Models{
    public class User{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}=string.Empty;
        [BsonElement("name")]
        public string Name { get; set; }=string.Empty;
        [BsonElement("lastname")]
        public string LastName { get; set; }=string.Empty;
        [BsonElement("email")]
        public string Email { get; set; }=string.Empty;
        [BsonElement("username")]
        public string Username { get; set; }=string.Empty;
        [BsonElement("password")]
        public string Password { get; set; }=string.Empty;
        [BsonElement("diary")]
        public string Diary { get; set; }=string.Empty;
        [BsonElement("birthday")]
        public string Birthday { get; set; }=string.Empty;
    }
}