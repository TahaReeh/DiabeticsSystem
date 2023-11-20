using DiabeticsSystem.Domain.Entities;

namespace DiabeticsSystem.Application.Contracts.Persistence
{
    public interface ISystemSettingRepository : IAsyncRepository<SystemSetting>
    {
        Task UpdateAsync(SystemSetting entity, bool Save);
    }
}
