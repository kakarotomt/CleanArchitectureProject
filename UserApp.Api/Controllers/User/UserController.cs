using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApp.Application.Users.CreateUser;
using UserApp.Application.Users.EditUser;
using UserApp.Application.Users.GetUser;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserApp.Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;
        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet(Name = "{firstName}/{firstLastname}/{page}")]
        public async Task<IActionResult> GetUsers(string FirstName, string FirstLastname, int page, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery(FirstName, FirstLastname, page);
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result.Value);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var query = new GetAllUsersQuery();
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(CreateUserRequest createUserRequest, CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(
                createUserRequest.FirstName,
                createUserRequest.SecondName,
                createUserRequest.FirstLastName,
                createUserRequest.SecondLastName,
                createUserRequest.Birthday,
                createUserRequest.Salary,
                createUserRequest.CreateDate,
                createUserRequest.ModifiedDate);

            var res = await _sender.Send(command, cancellationToken);

            if (res.IsFailure)
            {
                return BadRequest(res.Error);
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(Guid idUser,CreateUserRequest createUserRequest, CancellationToken cancellationToken)
        {
            var command = new EditUserCommand(
                idUser,
                createUserRequest.FirstName,
                createUserRequest.SecondName,
                createUserRequest.FirstLastName,
                createUserRequest.SecondLastName,
                createUserRequest.Birthday,
                createUserRequest.Salary,
                createUserRequest.CreateDate,
                createUserRequest.ModifiedDate);

            var res = await _sender.Send(command, cancellationToken);

            if (res.IsFailure)
            {
                return BadRequest(res.Error);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand(
                id);

            var res = await _sender.Send(command, cancellationToken);
            if (res.IsFailure) { 
            return BadRequest(res.Error);
            }

            return Ok();
        }
    }
}
