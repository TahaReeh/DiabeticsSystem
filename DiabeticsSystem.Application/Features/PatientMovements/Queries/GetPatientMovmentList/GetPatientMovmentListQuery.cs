using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentList
{
    public class GetPatientMovmentListQuery : IRequest<List<PatientMovmentListVM>>
    {
        
    }
}
