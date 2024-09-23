using UserApp.Application.Abstractions.Messaging;
using UsersApp.Domain.Users;

namespace UserApp.Application.Users.CreateUser
{
    public record CreateUserCommand(
        FirstName firstName,
        SecondName secondName,
        FirstLastname firstLastname,
        SecondLastname secondLastname,
        Birthday birthday,
        Salary salary,
        CreateDate createDate,
        ModifiedDate modifiedDate
        )
        : ICommand<Guid>;
}
