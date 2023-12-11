using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Doctors.Queries.GetDoctorList
{
    public class GetDoctorListQueryHandler : IRequestHandler<GetDoctorListQuery, List<DoctorListVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDoctorListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<DoctorListVM>> Handle(GetDoctorListQuery request, CancellationToken cancellationToken)
        {
            var doctors = (await _unitOfWork.Doctor.GetAllAsync()).OrderBy(x => x.Number);
            return _mapper.Map<List<DoctorListVM>>(doctors);
        }
    }
}
