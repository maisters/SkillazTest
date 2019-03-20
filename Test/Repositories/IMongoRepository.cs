using System.Threading.Tasks;
using Test.Models;

namespace Test.Repositories
{
    public interface IMongoRepository<T> where T : BaseEntity
    {
        Task Insert(T item);
        Task Update(T item);
    }
}