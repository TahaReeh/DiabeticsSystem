using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Doctors.Queries.GetDoctorList
{
    public class DoctorListVM
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
