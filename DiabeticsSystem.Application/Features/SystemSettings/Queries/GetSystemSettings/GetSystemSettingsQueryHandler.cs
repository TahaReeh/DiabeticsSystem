using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.SystemSettings.Queries.GetSystemSettings
{
    public class GetSystemSettingsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetSystemSettingsQuery, SystemSettingsVM>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<SystemSettingsVM> Handle(GetSystemSettingsQuery request, CancellationToken cancellationToken)
        {
            var obj = await _unitOfWork.SystemSetting.GetAsync(x => x.UserId == request.UserId) ??
                throw new Exceptions.NotFoundException(nameof(SystemSetting), request.UserId);

            return _mapper.Map<SystemSettingsVM>(obj);
        }
    }
}
