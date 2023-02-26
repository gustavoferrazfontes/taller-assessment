using Microsoft.AspNetCore.Mvc;
using WebApp.Domain;
using WebApp.Model;

namespace WebApp.Controllers
{
    [Route("api/v1/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrUpdateCarRequest request)
        {
            try
            {

                var car = Car.Create(request.Make,
                                     request.Model,
                                     request.Year,
                                     request.Doors,
                                     request.Color,
                                     request.Price,
                                     _carRepository.GenerateId());

                _carRepository.Save(car);

                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] CreateOrUpdateCarRequest request, [FromRoute] int id)
        {
            try
            {
                var car = _carRepository.Get(id);

                car.Update(request.Make, request.Model, request.Year, request.Doors, request.Color, request.Price);

                _carRepository.Update(car);

                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _carRepository.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var cars = _carRepository.GetAll();
                return Ok(cars);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                return Ok(_carRepository.Get(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
