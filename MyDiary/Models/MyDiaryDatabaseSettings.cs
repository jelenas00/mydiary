namespace MyDiary.Models{
    public class MyDiaryDatabaseSettings{
        public string ConnectionString { get; set;}=null!;
        public string DatabaseName { get; set;}=null!;
        public string UsersCollectionName { get; set;}=null!;
        public string DiariesCollectionName { get; set;}=null!;
        public string PagesCollectionName { get; set;}=null!;
    }
}