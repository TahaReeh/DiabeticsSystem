using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDoctorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDoctorCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
                throw new Exceptions.ValidationException(validationResult);

            var @doctor = _mapper.Map<Doctor>(request);
            @doctor = await _unitOfWork.Doctor.AddAsync(@doctor, Save: true);

            return @doctor.Id;
        }
    }
}
