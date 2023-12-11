using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using MediatR;

namespace DiabeticsSystem.Application.Features.Doctors.Queries.GetDoctorDetails
{
    public class GetDoctorDetailQueryHandler : IRequestHandler<GetDoctorDetailQuery, DoctorDetailsVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDoctorDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DoctorDetailsVM> Handle(GetDoctorDetailQuery request, CancellationToken cancellationToken)
        {
            var @doctor = await _unitOfWork.Doctor.GetAsync(d => d.Id == request.Id);
            return _mapper.Map<DoctorDetailsVM>(@doctor);
        }
    }
}
