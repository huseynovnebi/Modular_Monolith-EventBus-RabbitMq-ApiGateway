using Microsoft.AspNetCore.Mvc;
using User.Application.Models.DTO;
using User.Application.Services;


namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService Userservice;

        public UserController(IUserService Userservice)
        {
            this.Userservice = Userservice;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Users = await Userservice.GetAll();

            return Ok(Users);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var User = await Userservice.GetByIdStrictAsync(id);

            return Ok(User);
        }

        [HttpPost]
        public async Task Post([FromBody] CreateUserDTO value)
        {
            await Userservice.Add(value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserDTO value)
        {
            Userservice.Update(value);

            return Ok("User Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var User = await Userservice.GetByIdStrictAsync(id);

            Userservice.Remove(User);

            return NoContent();
        }
    }
}
