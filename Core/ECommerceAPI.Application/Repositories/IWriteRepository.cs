using ECommerceAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ECommerceAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> data);
        bool Remove(T model);
        bool RemoveRange(List<T> data);
        Task<bool> Remove(string id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
