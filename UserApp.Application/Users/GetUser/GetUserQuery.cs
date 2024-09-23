using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.Application.Abstractions.Messaging;

namespace UserApp.Application.Users.GetUser
{
    public sealed record GetUserQuery(Guid userId): IQuery<UserResponse>;
}
 