using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.SystemSettings.Commands
{
    public class UpdateSystemSettingsCommand : IRequest
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int AccentColor { get; set; }
        public bool IsDark { get; set; }
    }
}
