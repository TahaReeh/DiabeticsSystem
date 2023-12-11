using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiabeticsSystem.Persistence.Repositories
{
    public class DoctorRepository : AsyncRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task ActivationAsync(Doctor entity)
        {
            var objFromDb = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.DeactivatedDate = DateTime.Now;
            }
        }

        public async Task UpdateAsync(Doctor entity, bool Save)
        {
            _context.Entry(entity).State = EntityState.Modified;
            if (Save)
                await _context.SaveChangesAsync();
        }
    }
}
