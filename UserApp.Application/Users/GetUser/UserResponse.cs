using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Application.Users.GetUser
{
    public sealed class UserResponse
    {
        public int Id { get; init; }
        public Guid UserId { get; init; }
        public string FirstName { get; init; }
        public string SecondName { get; init; }
        public string SecondLastName { get; init; }
        public string FirstLastName { get; init; }
        public DateOnly Birthday { get; init; }
        public decimal Salary { get; init; }
        public DateTime CreateDate { get; init; }
        public DateTime ModifiedDate { get; init; }
    } 
}
