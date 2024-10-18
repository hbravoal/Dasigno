using Dasigno.Application.User.Queries.GetById;
using Microsoft.AspNetCore.Mvc;



namespace Dasigno.User.Api.Controllers
{

    public class UserController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetUserById()
                { Id = id }));
        }
    }
}
