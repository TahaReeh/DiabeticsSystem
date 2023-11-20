using DiabeticsSystem.Application.Contracts.Persistence;

namespace DiabeticsSystem.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICustomerRepository Customer {  get; private set; }
        public IProductRepository Product { get; private set; }
        public IPatientMovementRepository PatientMovement { get; private set; }

        public ISystemSettingRepository SystemSetting { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Customer = new CustomerRepository(_db);
            Product = new ProductRepository(_db);
            PatientMovement = new PatientMovementRepository(_db);
            SystemSetting = new SystemSettingRepository(_db);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
