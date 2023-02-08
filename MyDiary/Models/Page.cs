using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyDiary.Models{
    public class Page{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}=string.Empty;
        [BsonElement("diary")]
        public string Diary { get; set; }=string.Empty;
        [BsonElement("feeling")]
        public string Feeling { get; set; }=string.Empty;
        [BsonElement("weather")]
        public string Weather { get; set; }=string.Empty;
        [BsonElement("pagecontent")]
        public string PageContent { get; set; }=string.Empty;
        [BsonElement("datetime")]
        public string Datetime { get; set; }=string.Empty;
    }
}