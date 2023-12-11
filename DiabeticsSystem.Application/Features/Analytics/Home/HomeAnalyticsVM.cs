using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Analytics.Home
{
    public class HomeAnalyticsVM
    {
        public string CustomerCount { get; set; } = string.Empty;
        public string ProductCount { get; set; } = string.Empty;
        public string PatientMovesCount { get; set; } = string.Empty;
        public string UsersCount { get; set; } = string.Empty;
        public string DoctorsCount { get; set; } = string.Empty;
    }
}
