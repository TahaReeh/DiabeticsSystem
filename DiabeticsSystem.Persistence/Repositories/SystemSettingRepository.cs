using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;

namespace DiabeticsSystem.Persistence.Repositories
{
    public class SystemSettingRepository(ApplicationDbContext context) : AsyncRepository<SystemSetting>(context), ISystemSettingRepository
    {
        public async Task UpdateAsync(SystemSetting entity, bool Save)
        {
            _context.SystemSettings.Update(entity);
            if (Save)
                await _context.SaveChangesAsync();
        }
    }
}
