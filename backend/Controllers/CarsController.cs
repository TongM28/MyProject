using BackendProject.Data;
using BackendProject.DTOs;
using BackendProject.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BackendProject.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly MongoDbContext _context;

        public CarsController(MongoDbContext context)
        {
            _context = context;
        }

        // GET: api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCars()
        {
            var cars = await _context.Cars.Find(car => true).ToListAsync();
            return cars.Select(car => new CarDTO
            {
                Id = car.Id,
                Name = car.Name,
                Brand = car.Brand,
                Year = car.Year,
                Price = car.Price,
                ImageUrl = car.ImageUrl,
                Description = car.Description
            }).ToList();
        }

        // GET: api/cars/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCarById(string id)
        {
            var car = await _context.Cars.Find<Car>(c => c.Id == id).FirstOrDefaultAsync();
            if (car == null)
            {
                return NotFound();
            }
            return new CarDTO
            {
                Id = car.Id,
                Name = car.Name,
                Brand = car.Brand,
                Year = car.Year,
                Price = car.Price,
                ImageUrl = car.ImageUrl,
                Description = car.Description
            };
        }
    }
}
