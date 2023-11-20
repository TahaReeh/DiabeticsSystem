using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.SystemSettings.Queries.GetSystemSettings
{
    public class GetSystemSettingsQuery : IRequest<SystemSettingsVM>
    {
        public string UserId { get; set; } = string.Empty;

    }

}
