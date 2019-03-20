using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services
{
    public interface ILinksService
    {
        Task<Link> GetUrl(string shortUrl);
        Task<IEnumerable<Link>> GetAll(string id);
        Task<Link> Create(string clientId, string url);
        
    }
}