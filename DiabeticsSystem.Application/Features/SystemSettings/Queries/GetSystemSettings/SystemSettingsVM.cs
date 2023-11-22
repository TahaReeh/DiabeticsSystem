using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.SystemSettings.Queries.GetSystemSettings
{
    public class SystemSettingsVM
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int AccentColor { get; set; }
        public bool IsDark { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
