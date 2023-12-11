using DiabeticsSystem.Domain.Entities;

namespace DiabeticsSystem.Application.Contracts.Persistence
{
    public interface IDoctorRepository : IAsyncRepository<Doctor>
    {
        Task UpdateAsync(Doctor entity, bool Save);
        Task ActivationAsync(Doctor entity);
    }
}
