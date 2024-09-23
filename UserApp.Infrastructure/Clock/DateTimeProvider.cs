using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.Application.Abstractions.Clock;

namespace UserApp.Infrastructure.Clock
{
    public sealed class DateTimeProvider : IDatetimeProvider
    {
        public DateTime CurrentDate => DateTime.UtcNow;
    }
}
