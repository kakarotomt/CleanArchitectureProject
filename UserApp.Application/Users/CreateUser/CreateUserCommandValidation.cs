using FluentValidation;

namespace UserApp.Application.Users.CreateUser
{
    public sealed class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            //RuleFor(c => c.userId).NotEmpty();
            RuleFor(c => c.firstName).NotEmpty();
            RuleFor(c => c.firstLastname).NotEmpty();
            RuleFor(c => c.birthday).NotEmpty();
            RuleFor(c => c.salary).NotEmpty();
            RuleFor(c => c.createDate).NotEmpty();
        }
    }
}
