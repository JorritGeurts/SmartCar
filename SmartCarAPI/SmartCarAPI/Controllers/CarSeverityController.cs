using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCarAPI.Data;
using SmartCarAPI.Models;

namespace SmartCarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarSeverityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarSeverityController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarServerity()
        {
            var carServ = await _context.CarSeverity.ToListAsync();

            if (carServ == null || !carServ.Any())
            {
                return NotFound("No damages found.");
            }

            return Ok(carServ);
        }

        [HttpPost]
        public async Task<IActionResult> PostCarSeverity(CarSeverity carserv)
        {
            if (carserv == null)
            {
                return BadRequest("Damage data is required.");
            }

            // Create a new Damage entity
            var vehicle = new CarSeverity
            {
                CarId = 1,
                SeverityId = 1,
                DamageId = 1
            };

            // Add to the context and save changes
            _context.CarSeverity.Add(vehicle);
            await _context.SaveChangesAsync();

            // Return the created damage record with a 201 status code
            return await GetCarServerity();
        }

    }
}
