using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Application.Features.Customers.Commands.UpdateCustomer;
using DiabeticsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDoctorCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var objToUpdate = await _unitOfWork.Doctor.GetAsync(x => x.Id == request.Id)
                ?? throw new Exceptions.NotFoundException(nameof(Doctor), request.Id);

            var validator = new UpdateDoctorCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            _mapper.Map(request, objToUpdate, typeof(UpdateDoctorCommand), typeof(Doctor));

            await _unitOfWork.Doctor.UpdateAsync(objToUpdate, Save: true);
        }
    }
}
