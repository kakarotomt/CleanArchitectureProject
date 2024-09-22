using UserApp.Application.Abstractions.Messaging;
using UsersApp.Domain.Users;

namespace UserApp.Application.Users.CreateUser
{
    public record CreateUserCommand(
        Guid usuarioId,
        Name names,
        Lastname lastNames,
        UserData data,
        AuditData auditData,
        DocumentType documentType
        )
        :ICommand<Guid>;
}
