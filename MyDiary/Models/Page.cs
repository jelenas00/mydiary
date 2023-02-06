using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyDiary.Models{
    public class Page{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}=null!;
        [BsonElement("diary")]
        public string Diary { get; set; }=null!;
        [BsonElement("feeling")]
        public string Feeling { get; set; }=null!;
        [BsonElement("weather")]
        public string Weather { get; set; }=null!;
        [BsonElement("pagecontent")]
        public string PageContent { get; set; }=null!;
        [BsonElement("datetime")]
        public string Datetime { get; set; }=null!;
    }
}