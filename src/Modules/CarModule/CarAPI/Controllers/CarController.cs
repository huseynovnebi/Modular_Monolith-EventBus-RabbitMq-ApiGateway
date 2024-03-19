using Car.Application.Models.DTO;
using Car.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService carservice;

        public CarController(ICarService carservice)
        {
            this.carservice = carservice;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await carservice.GetAll();   

            return Ok(cars);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var car = await carservice.GetByIdStrictAsync(id);

            return Ok(car);
        }

        [HttpPost]
        public async Task Post([FromBody] CreateCarDTO value)
        {
            await carservice.Add(value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCarDTO value)
        {
             carservice.Update(value);

             return Ok("User Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await carservice.GetByIdStrictAsync(id);

            carservice.Remove(car);

            return NoContent();
        }
    }
}
