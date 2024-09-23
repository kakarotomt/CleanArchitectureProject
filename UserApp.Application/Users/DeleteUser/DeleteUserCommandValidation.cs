using FluentValidation;

namespace UserApp.Application.Users.EditUser
{
    public sealed class DeleteUserCommandValidation : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidation()
        {
            RuleFor(c => c.id).NotEmpty();
        }
    }
}
