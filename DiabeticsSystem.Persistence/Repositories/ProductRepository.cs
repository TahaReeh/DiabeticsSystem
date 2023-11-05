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
    public class ProductRepository : AsyncRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task ActivationAsync(Product entity)
        {
            var objFromDb = await _context.Products.FirstOrDefaultAsync(u=>u.Id == entity.Id);
            if (objFromDb != null)
            {
               objFromDb.DeactivatedDate = DateTime.Now;    
            }

        }

        public async Task UpdateAsync(Product entity, bool Save)
        {
            _context.Entry(entity).State = EntityState.Modified;
            if (Save)
                await _context.SaveChangesAsync();
        }
    }
}
