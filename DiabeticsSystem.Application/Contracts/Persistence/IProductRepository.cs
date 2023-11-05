using DiabeticsSystem.Domain.Entities;

namespace DiabeticsSystem.Application.Contracts.Persistence
{
    public interface IProductRepository :IAsyncRepository<Product>
    {
        Task UpdateAsync(Product entity, bool Save);
        Task ActivationAsync(Product entity);
    }
}
