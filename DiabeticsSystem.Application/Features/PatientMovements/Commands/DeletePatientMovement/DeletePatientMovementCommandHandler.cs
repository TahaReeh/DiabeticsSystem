using DiabeticsSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.PatientMovements.Commands.DeletePatientMovement
{
    public class DeletePatientMovementCommandHandler : IRequestHandler<DeletePatientMovementCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePatientMovementCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePatientMovementCommand request, CancellationToken cancellationToken)
        {
            var objToDelete = await _unitOfWork.PatientMovement.GetAsync(u => u.Id == request.PatientMovementId)
                ?? throw new Exceptions.NotFoundException(nameof(PatientMovements), request.PatientMovementId);

            await _unitOfWork.PatientMovement.RemoveAsync(objToDelete, Save: true);
        }
    }
}
