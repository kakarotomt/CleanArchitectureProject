using MediatR;
using UserApp.Application.Abstractions.Email;
using UsersApp.Domain.Users;
using UsersApp.Domain.Users.Events;

namespace UserApp.Application.Users.EditUser
{
    internal sealed class DeleteUserDomainEventHandler : INotificationHandler<UserDeletedDomainEvent>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserDomainEventHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UserDeletedDomainEvent notification, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(notification.userId, cancellationToken);
            if (user == null) { return; }
        }
    }
}
