using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.Application.Abstractions.Messaging;

namespace UserApp.Application.Users.GetUser
{
    public sealed record GetUsersQuery(string firstName, string firstLastname, int page) : IQuery<IReadOnlyList<UserResponse>>;
}
