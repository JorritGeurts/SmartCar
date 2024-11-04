using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCarAPI.Data;
using SmartCarAPI.Models;

namespace SmartCarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _context.Car.ToListAsync();

            if (cars == null || !cars.Any())
            {
                return NotFound("No damages found.");
            }

            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> PostCar(Car car)
        {
            if (car == null)
            {
                return BadRequest("Damage data is required.");
            }

            // Create a new Damage entity
            try
            {
                // Add the new car to the context
                _context.Car.Add(car); // Make sure you're adding the car passed in the request
                await _context.SaveChangesAsync(); // Save changes to the database

                // Return the created car with a 201 status code
                return CreatedAtAction(nameof(GetCars), new { id = car.Id }, car);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine($"An error occurred while saving the car: {ex.Message}");
                return StatusCode(500, "Internal server error"); // Return a 500 error on failure
            }

        }

    }
}
