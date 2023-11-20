using DiabeticsSystem.Domain.Entities;

namespace DiabeticsSystem.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task UpdateAsync(Customer entity, bool Save);
        Task ActivationAsync(Customer entity);
    }
}
