using System.Numerics;
using UserApp.Application.Abstractions.Clock;
using UserApp.Application.Abstractions.Messaging;
using UsersApp.Domain.Abstractions;
using UsersApp.Domain.Users;

namespace UserApp.Application.Users.CreateUser
{
    internal sealed class CreateUserCommandHandler
    : ICommandHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatetimeProvider _datetimeProvider;

        public CreateUserCommandHandler(IUserRepository userRepository
            , IUnitOfWork unitOfWork
            , IDatetimeProvider datetimeProvider)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _datetimeProvider = datetimeProvider;
        }

        public async Task<Result<Guid>> Handle(CreateUserCommand request
            , CancellationToken cancellationToken)
        {
            var user = User.Create(
                request.names, 
                request.lastNames, 
                request.data, 
                request.auditData, 
                request.documentType
                );

            _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
