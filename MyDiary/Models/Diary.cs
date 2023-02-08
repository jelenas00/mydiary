using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyDiary.Models{
    public class Diary{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}=string.Empty;
        [BsonElement("name")]
        public string Name { get; set; }=string.Empty;
        [BsonElement("user")]
        public string User { get; set; }=string.Empty;
        [BsonElement("password")]
        public string Password { get; set; }=string.Empty;
        [BsonElement("pages")]
        public List<string> Pages { get; set; }=null!;
    }
}