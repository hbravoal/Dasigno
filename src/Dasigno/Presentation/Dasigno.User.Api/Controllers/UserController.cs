using Dasigno.Application.User.Commands.Create;
using Dasigno.Application.User.Commands.DeleteById;
using Dasigno.Application.User.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Dasigno.User.Api.Controllers;

public class UserController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Post(CreateUserCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
        
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator.Send(new GetUserById()
            { Id = id }));
    }
        
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteUserByIdCommand() { Id = id }));
    }
        
}