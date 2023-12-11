using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using MediatR;

namespace DiabeticsSystem.Application.Features.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var objToDelete = await _unitOfWork.Doctor.GetAsync(d => d.Id == request.Id)
                  ?? throw new Exceptions.NotFoundException(nameof(Doctor), request.Id);

            await _unitOfWork.Doctor.RemoveAsync(objToDelete, Save: true);
        }
    }
}

