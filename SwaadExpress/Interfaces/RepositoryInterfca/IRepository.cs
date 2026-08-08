using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwaadExpress.Interfaces.RepositoryInterfca
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id);
    }
}
