using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Domain.Entities
{
    public class SystemSetting
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int AccentColor {  get; set; }
        public bool IsDark { get; set; }
    }
}
