using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Application.Abstractions.Clock
{
    public interface IDatetimeProvider
    {
        public DateTime CurrentDate { get; } 
    }
}
