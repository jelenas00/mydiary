using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyDiary.Models{
    public class Diary{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}=null!;
        [BsonElement("name")]
        public string Name { get; set; }=null!;
        [BsonElement("user")]
        public string User { get; set; }=null!;
        [BsonElement("password")]
        public string Password { get; set; }=null!;
        [BsonElement("pages")]
        public List<string> Pages { get; set; }=null!;
    }
}