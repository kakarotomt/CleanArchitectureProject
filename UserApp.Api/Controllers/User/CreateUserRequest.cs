using UsersApp.Domain.Users;

namespace UserApp.Api.Controllers.User
{
    public sealed record CreateUserRequest(
        FirstName FirstName ,
        SecondName SecondName,
        SecondLastname SecondLastName ,
        FirstLastname FirstLastName ,
        Birthday Birthday ,
        Salary Salary ,
        CreateDate CreateDate ,
        ModifiedDate ModifiedDate );

}
