using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Repositories
{
    public interface ILinksRepository : IMongoRepository<Link>
    {
        Task<Link> getByShortUrl(string shortUrl);
        Task<Link> getByUrl(string clientId, string url);
        Task<IEnumerable<Link>> GetClientsUrls(string id);
    }
}