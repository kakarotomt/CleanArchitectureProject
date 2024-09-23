using UserApp.Application.Abstractions.Messaging;
using UsersApp.Domain.Users;

namespace UserApp.Application.Users.EditUser
{
    public record DeleteUserCommand(
        Guid id
        )
        : ICommand<Guid>;
}
