using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.PatientMovements.Commands.DeletePatientMovement
{
    public class DeletePatientMovementCommand : IRequest
    {
        public Guid PatientMovementId { get; set; }
    }
}
