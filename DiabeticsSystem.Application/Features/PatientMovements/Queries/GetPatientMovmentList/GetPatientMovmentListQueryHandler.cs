using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentList
{
    public class GetPatientMovmentListQueryHandler : IRequestHandler<GetPatientMovmentListQuery, List<PatientMovmentListVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPatientMovmentListQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PatientMovmentListVM>> Handle(GetPatientMovmentListQuery request, CancellationToken cancellationToken)
        {
            var PMovment = await _unitOfWork.PatientMovement.GetAllAsync(includeProperties: "Customer,Product");
            var dtos = _mapper.Map<List<PatientMovmentListVM>>(PMovment);

            return dtos;
        }
    }
}
