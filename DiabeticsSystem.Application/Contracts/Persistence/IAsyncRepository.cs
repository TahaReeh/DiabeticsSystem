using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        Task<T> AddAsync(T entity,bool Save);
        Task RemoveAsync(T entity, bool Save);
        Task RemoveRangeAsync(IEnumerable<T> entities, bool Save);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}
