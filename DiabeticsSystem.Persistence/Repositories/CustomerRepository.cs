using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiabeticsSystem.Persistence.Repositories
{
    public class CustomerRepository : AsyncRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task ActivationAsync(Customer entity)
        {
            var objFromDb = await _context.Customers.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.DeactivatedDate = DateTime.Now;
            }
        }

        public async Task UpdateAsync(Customer entity, bool Save)
        {
            _context.Entry(entity).State = EntityState.Modified;
            if (Save)
                await _context.SaveChangesAsync();
        }
    }
}
