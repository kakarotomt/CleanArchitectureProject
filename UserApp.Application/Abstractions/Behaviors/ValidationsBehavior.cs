using FluentValidation;
using MediatR;
using UserApp.Application.Abstractions.Messaging;
using UserApp.Application.Exceptions;

namespace UserApp.Application.Abstractions.Behaviors
{
    public class ValidationsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {

        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public ValidationsBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);
            var validations = _validator.Select(m => m.Validate(context))
                .Where(M => M.Errors.Any())
                .SelectMany(M => M.Errors)
                .Select(m => new ValidationError(
                    m.PropertyName,m.ErrorMessage
                    )).ToList();
            
            
            if (validations.Any())
            {
                throw new Exceptions.ValidationException(validations);
            }

            return await next();


        }
    }
}
