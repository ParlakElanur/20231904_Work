using Microsoft.AspNetCore.Mvc;
using Web_API.Models;
using Web_API.ViewModels;

namespace Web_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private static readonly string[] Colors = new string[] { "red", "blue", "black", "white" };
        private static readonly string[] Lights = new string[] { "turnOn", "turnOff" };
        Vehicle vehicles;
        public VehicleController()
        {
            vehicles = new Vehicle();
            vehicles.Cars.Add(new Car() { CarID = 1, Wheels = "w1", Headlights = Lights[0], Color = Colors[0] });
            vehicles.Cars.Add(new Car() { CarID = 2, Wheels = "w2", Headlights = Lights[1], Color = Colors[1] });
            vehicles.Buses.Add(new Bus() { Color = Colors[2] });
            vehicles.Boats.Add(new Boat() { Color = Colors[3] });
        }
        [HttpGet]
        [Route("{color}")]
        public IActionResult GetCars(string color)
        {
            List<CarViewModel> cars = vehicles.Cars.Where(c => c.Color == color).Select(c => new CarViewModel()
            {
                Wheels = c.Wheels,
                Headlights = c.Headlights,
                Color = c.Color,
            }).ToList();

            if (cars == null)
                return NotFound();

            return Ok(cars);
        }
        [HttpGet]
        [Route("{color}")]
        public IActionResult GetBuses(string color)
        {
            List<BusViewModel> buses = vehicles.Buses.Where(b => b.Color == color)
                .Select(b => new BusViewModel()
                {
                    Color = b.Color
                }).ToList();

            if (buses == null)
                return NotFound();

            return Ok(buses);
        }
        [HttpGet]
        [Route("{color}")]
        public IActionResult GetBoats(string color)
        {
            List<BoatViewModel> boats = vehicles.Boats.Where(b => b.Color == color)
                .Select(b => new BoatViewModel()
                {
                    Color = b.Color
                }).ToList();

            if (boats == null)
                return NotFound();

            return Ok(boats);
        }
        [HttpPost]
        [Route("{carID}")]
        public IActionResult UpdateCarHeadlights(int carID)
        {
            Car? car = vehicles.Cars.Where(c => c.CarID == carID).SingleOrDefault();
            if (car == null)
                return NotFound();
            if (car.Headlights == "turnOn")
            {
                car.Headlights = "turnOff";
            }
            else
            {
                car.Headlights = "turnOn";
            }
            return Ok(car);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            Car? car = vehicles.Cars.Where(c => c.CarID == id).SingleOrDefault();
            if (car == null)
                return NotFound();

            vehicles.Cars.Remove(car);
            return NoContent();
        }

    }
}
