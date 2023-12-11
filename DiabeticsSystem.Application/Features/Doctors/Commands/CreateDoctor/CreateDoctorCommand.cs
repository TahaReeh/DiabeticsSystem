using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<Guid>
    {
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? SecondPhone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PersonalId { get; set; }
        public DateTime BirthDate { get; set; }
        public int Sex { get; set; }

        public override string ToString()
        {
            return $"Customer Name: {Name}; Number: {Number}; PhoneNumber: {Phone}";
        }
    }
}
