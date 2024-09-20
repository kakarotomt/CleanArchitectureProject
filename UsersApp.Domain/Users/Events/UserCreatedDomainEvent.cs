using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Abstractions;

namespace UsersApp.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(Guid userId) : IDomainEvent;
}
