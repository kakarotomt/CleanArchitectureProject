using MediatR;
using UserApp.Application.Abstractions.Email;
using UsersApp.Domain.Users;
using UsersApp.Domain.Users.Events;

namespace UserApp.Application.Users.CreateUser
{
    internal sealed class CreateUserDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
    {

        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(notification.userId, cancellationToken);
            
            if (user == null) { return; }

            await _emailService.SendAsync("", "", "");
        }
    }
}
