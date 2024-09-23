using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Application.Users.GetUser
{
    public sealed class UserResponse
    {
        public Guid Id { get; init; }
        public string FirstNames { get; init; }
        public string SecondNames { get; init; }
        public string SecondLastNames { get; init; }
        public string FirstLastNames { get; init; }
        public DateTime Birthdays { get; init; }
        public decimal Salarys { get; init; }
        public DateTime CreateDates { get; init; }
        public DateTime ModifiedDates { get; init; }
    } 
}
