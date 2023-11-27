using DiabeticsSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Analytics.Home
{
    public class HomeAnalyticsQueryHandler : IRequestHandler<HomeAnalyticsQuery, HomeAnalyticsVM>
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeAnalyticsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<HomeAnalyticsVM> Handle(HomeAnalyticsQuery request, CancellationToken cancellationToken)
        {
            var customerCount = (await _unitOfWork.Customer.GetAllAsync()).Count();
            var productCount = (await _unitOfWork.Product.GetAllAsync()).Count();
            var patientMovesCount = _unitOfWork.PatientMovement.GetAllAsync().GetAwaiter().GetResult().Count();
            HomeAnalyticsVM homeAnalytics = new()
            {
                CustomerCount = customerCount.ToString(),
                ProductCount = productCount.ToString(),
                PatientMovesCount = patientMovesCount.ToString(),
                UsersCount = "1"
            };

            return homeAnalytics;
        }
    }
}
