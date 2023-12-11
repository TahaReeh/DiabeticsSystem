using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
