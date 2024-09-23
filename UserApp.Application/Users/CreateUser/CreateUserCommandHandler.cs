using System.Numerics;
using UserApp.Application.Abstractions.Clock;
using UserApp.Application.Abstractions.Messaging;
using UserApp.Application.Exceptions.ConcurrencyException;
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
            try
            {
                var user = User.Create(
                    request.firstName,
                    request.secondName,
                    request.firstLastname,
                    request.secondLastname,
                    request.birthday,
                    request.salary,
                    request.createDate,
                    request.modifiedDate
                    );

                _userRepository.Add(user);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return user.Id;
            }
            catch (ConcurrencyException ex)
            {
                return Result.Failure<Guid>(new Error("creacion usuario", "Error en la creacion de un usuario"));
            }
        }
    }
}
