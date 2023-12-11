using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Doctors.Queries.GetDoctorList
{
    public class GetDoctorListQuery : IRequest<List<DoctorListVM>>
    {

    }
}
