﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentList
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public  string Name { get; set; } = string.Empty;
    }
}
