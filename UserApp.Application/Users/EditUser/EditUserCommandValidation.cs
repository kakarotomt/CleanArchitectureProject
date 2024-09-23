using FluentValidation;

namespace UserApp.Application.Users.EditUser
{
    public sealed class EditUserCommandValidation : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidation()
        {
            RuleFor(c => c.firstName).NotEmpty();
            RuleFor(c => c.firstLastname).NotEmpty();
            RuleFor(c => c.birthday).NotEmpty();
            RuleFor(c => c.salary).NotEmpty();
            RuleFor(c => c.createDate).NotEmpty();
        }
    }
}
