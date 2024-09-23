using UserApp.Application.Abstractions.Messaging;
using UsersApp.Domain.Users;

namespace UserApp.Application.Users.CreateUser
{
    public record CreateUserCommand(
        //Guid userId,
        //string firstName,
        //    string secondName,
        //    string firstLastname,
        //    string secondLastname,
        //    DateOnly birthday,
        //    decimal salary,
        //    DateTime createDate,
        //    DateTime modifiedDate
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
