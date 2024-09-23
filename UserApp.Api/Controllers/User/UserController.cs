using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApp.Application.Users.CreateUser;
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

        //[HttpGet(Name = "Users")]
        //public Task<IActionResult> GetUser(CancellationToken cancellationToken)
        //{
        //    var query = new GetUserQuery();
        //    var result = await _sender.Send(query, cancellationToken);
        //    return Ok(result.Value);
        //}

        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
