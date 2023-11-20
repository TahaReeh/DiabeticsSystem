using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Persistence.DbInitializers
{
    internal class DbInitializer(ApplicationDbContext db) : IDbInitializer
    {
        private readonly ApplicationDbContext _db = db;

        public async Task InitializeAsync()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    await _db.Database.MigrateAsync();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
