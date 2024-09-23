using System.Numerics;
using UserApp.Application.Abstractions.Clock;
using UserApp.Application.Abstractions.Messaging;
using UserApp.Application.Exceptions.ConcurrencyException;
using UsersApp.Domain.Abstractions;
using UsersApp.Domain.Users;

namespace UserApp.Application.Users.EditUser
{
    internal sealed class DeleteUserCommandHandler
    : ICommandHandler<DeleteUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatetimeProvider _datetimeProvider;

        public DeleteUserCommandHandler(IUserRepository userRepository
            , IUnitOfWork unitOfWork
            , IDatetimeProvider datetimeProvider)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _datetimeProvider = datetimeProvider;
        }

        public async Task<Result<Guid>> Handle(DeleteUserCommand request
            , CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.id, cancellationToken);

                _userRepository.Delete(request.id);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return request.id;
            }
            catch (ConcurrencyException ex)
            {
                return Result.Failure<Guid>(new Error("eliminacion usuario", "Error en la eliminacion de un usuario"));
            }
        }
    }
}
