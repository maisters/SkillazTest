using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Test.Models;

namespace Test.Repositories
{
    public class LinksRepository : MongoRepository<Link>,ILinksRepository
    {
        public async Task<Link> getByShortUrl(string shortUrl)
        {
            var shortUrlFilter = Builders<Link>.Filter.Eq(a => a.ShortUrl, shortUrl);
            return  await _context.GetCollection<Link>().Find(shortUrlFilter).SingleOrDefaultAsync();
        }

        public async Task<Link> getByUrl(string clientId, string url)
        {
            var urlFilter = Builders<Link>.Filter.Eq(a => a.Url, url);
            var clientIdFilter = Builders<Link>.Filter.Eq(a => a.ClientID, clientId);
            var filter = Builders<Link>.Filter.And(new List<FilterDefinition<Link>>{ urlFilter, clientIdFilter });
            
            return  await _context.GetCollection<Link>().Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Link>> GetClientsUrls(string clientId)
        {
            var filter = Builders<Link>.Filter.Eq(m => m.ClientID, clientId);
            return await _context.GetCollection<Link>().Find(filter).ToListAsync();
        }
    }
}