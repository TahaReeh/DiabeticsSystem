using DiabeticsSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Contracts.Persistence
{
    public interface IPatientMovementRepository : IAsyncRepository<PatientMovement>
    {
        Task UpdateAsync(PatientMovement entity, bool Save);
        Task ActivationAsync(PatientMovement entity);
    }
}
