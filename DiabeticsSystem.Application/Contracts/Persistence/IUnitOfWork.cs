using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IProductRepository Product { get; }
        IPatientMovementRepository PatientMovement { get; }

        Task SaveAsync();
    }
}
