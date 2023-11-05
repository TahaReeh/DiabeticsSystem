using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Persistence.Repositories
{
    public class PatientMovementRepository : AsyncRepository<PatientMovement>, IPatientMovementRepository
    {
        public PatientMovementRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task ActivationAsync(PatientMovement entity)
        {
            var objFromDb = await _context.PatientMovements.FirstOrDefaultAsync(u => u.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.DeactivatedDate = DateTime.Now;
            }
        }

        public async Task UpdateAsync(PatientMovement entity, bool Save)
        {
            _context.PatientMovements.Update(entity);
            if (Save)
                await _context.SaveChangesAsync();
        }
    }
}
