using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwaadExpress.Interfaces.serviceInterface
{
    public interface IService<T> where T : class
    {
        Task<T?> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id);
    }
}
