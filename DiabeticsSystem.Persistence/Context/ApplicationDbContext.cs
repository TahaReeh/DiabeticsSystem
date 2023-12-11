using DiabeticsSystem.Domain.Common;
using DiabeticsSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiabeticsSystem.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PatientMovement> PatientMovements { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "userId";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "userId";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SystemSetting>().HasData(
                new SystemSetting
                {
                    Id = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                    UserId = "UserId",
                    AccentColor = 16,
                    IsDark = false,
                    Notes = ""
                });

            modelBuilder.Entity<Customer>().HasData(
               new Customer
               {
                   Id = Guid.Parse("{B0555D2F-5003-53C1-53A4-EDC53A5C5DD5}"),
                   Number = "1",
                   Name = "First Customer",
                   Phone = "0910000000",
                   SecondPhone = "0920000000",
                   Email = "email@evotech.com",
                   Address = "Address",
                   PersonalId = "123ABC321",
                   BirthDate = DateTime.Now.Date,
                   Sex = 0
               });

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = Guid.Parse("{B0446D2F-4006-46C1-46A4-EDC46A4C6DD4}"),
                   Number = "1",
                   Name = "First Product",
                   Details = "First product details....",
                   Code = "123ABC321",
                   Company = "Company Name"
               });

            modelBuilder.Entity<Doctor>().HasData(
               new Doctor
               {
                   Id = Guid.Parse("{B0777D2F-7001-71C1-71A7-EDC71A1C7DD1}"),
                   Number = "1",
                   Name = "First Doctor",
                   Phone = "0910000000",
                   SecondPhone = "0920000000",
                   Email = "email@evotech.com",
                   Address = "Address",
                   PersonalId = "123ABC321",
                   BirthDate = DateTime.Now.Date,
                   Sex = 0
               });
        }
    }
}
