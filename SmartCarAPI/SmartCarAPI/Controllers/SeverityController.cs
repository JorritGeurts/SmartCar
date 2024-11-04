using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCarAPI.Data;

namespace SmartCarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeverityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SeverityController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeverities()
        {
            var severity = await _context.Severity.ToListAsync();

            if (severity == null || !severity.Any())
            {
                return NotFound("No damages found.");
            }

            return Ok(severity);
        }
    }
}
