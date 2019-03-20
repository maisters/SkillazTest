
using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Test.Models;

namespace Test.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T> where T : BaseEntity
    {
        protected MongoDbContext _context;
        
        public MongoRepository()
        {
            _context = MongoDbContext.CreateDbContext();
        }

        public async Task Insert(T item)
        {
            item.Id = ObjectId.GenerateNewId(DateTime.Now).ToString();
            await _context.GetCollection<T>().InsertOneAsync(item);
        }

        public async Task Update(T item)
        {
            var filter = Builders<T>.Filter.Eq(m => m.Id, item.Id);
            var result = await _context.GetCollection<T>().ReplaceOneAsync(filter, item);
        }
    }
}