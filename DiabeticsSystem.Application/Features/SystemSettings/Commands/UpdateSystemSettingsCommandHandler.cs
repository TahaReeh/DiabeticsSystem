using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using MediatR;

namespace DiabeticsSystem.Application.Features.SystemSettings.Commands
{
    public class UpdateSystemSettingsCommandHandler : IRequestHandler<UpdateSystemSettingsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSystemSettingsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSystemSettingsCommand request, CancellationToken cancellationToken)
        {
            var objToUpdate = await _unitOfWork.SystemSetting.GetAsync(x => x.Id == request.Id)
                 ?? throw new Exceptions.NotFoundException(nameof(SystemSetting), request.Id);

            var settings = _mapper.Map<SystemSetting>(request);

            await _unitOfWork.SystemSetting.UpdateAsync(settings, Save: true);
        }
    }
}
