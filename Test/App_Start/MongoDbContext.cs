using System.Configuration;
using MongoDB.Driver;

namespace Test
{
    public class MongoDbContext
    {
        private IMongoDatabase database;
        private IMongoClient client;
        private static MongoDbContext context;
        public static MongoDbContext CreateDbContext()
        {
            if(context == null)
            {
                var connectionString = ConfigurationManager.AppSettings["MongoDb"];
                
                context = new MongoDbContext();
                var url = MongoUrl.Create(connectionString);
                context.client = new MongoClient(url);
                context.database = context.client.GetDatabase(url.DatabaseName);
            }
            return context;
        }
        
        public IMongoCollection<T> GetCollection<T>()
        {
            return context.database.GetCollection<T>(typeof(T).Name);
        }
    }
}