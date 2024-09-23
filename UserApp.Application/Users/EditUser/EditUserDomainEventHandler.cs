using MediatR;
using UserApp.Application.Abstractions.Email;
using UsersApp.Domain.Users;
using UsersApp.Domain.Users.Events;

namespace UserApp.Application.Users.EditUser
{
    internal sealed class EditUserDomainEventHandler : INotificationHandler<UserEditedDomainEvent>
    {
        private readonly IUserRepository _userRepository;

        public EditUserDomainEventHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UserEditedDomainEvent notification, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(notification.userId, cancellationToken);
            if (user == null) { return; }
        }
    }
}
