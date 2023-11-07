using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using MediatR;

namespace DiabeticsSystem.Application.Features.PatientMovements.Commands.CreatePatientMovement
{
    public class CreatePatientMovementCommandHandler : IRequestHandler<CreatePatientMovementCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePatientMovementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePatientMovementCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePatientMovementCommandValidatoer();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var patientMovenemt =  _mapper.Map<PatientMovement>(request);
             patientMovenemt = await _unitOfWork.PatientMovement.AddAsync(patientMovenemt,Save:true);

            return patientMovenemt.Id;
        }
    }
}
