using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentByCustomer
{
    public class GetPatientMovmentByCustomerQueryHandler : IRequestHandler<GetPatientMovmentByCustomerQuery, List<PatientMovmentByCustomerVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPatientMovmentByCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PatientMovmentByCustomerVM>> Handle(GetPatientMovmentByCustomerQuery request, CancellationToken cancellationToken)
        {
            var listByCustomer = await _unitOfWork.PatientMovement.GetAllAsync(
                u => u.CustomerId == request.CustomerId,includeProperties:"Customer")
                ?? throw new Exceptions.NotFoundException(nameof(Customer), request.CustomerId);

            var dtos = _mapper.Map<List<PatientMovmentByCustomerVM>>(listByCustomer);
            return dtos;
        }
    }
}
