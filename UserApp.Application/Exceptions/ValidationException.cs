using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Application.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationError> error)
        {
            _errors = error;
        }

        public IEnumerable<ValidationError> _errors { get; }

    }
}
