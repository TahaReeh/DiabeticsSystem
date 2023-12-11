using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Doctors.Queries.GetDoctorDetails
{
    public class GetDoctorDetailQuery : IRequest<DoctorDetailsVM>
    {
        public Guid Id { get; set; }
    }
}
