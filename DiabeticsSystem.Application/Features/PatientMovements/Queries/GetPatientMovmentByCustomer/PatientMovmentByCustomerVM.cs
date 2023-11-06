using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentByCustomer
{
    public class PatientMovmentByCustomerVM
    {
        public Guid Id { get; set; }
        public string? Barcode { get; set; }
        public DateTime CreatedDate { get; set; }
        public CustomerDTO Customer { get; set; } = default!;
    }
}
