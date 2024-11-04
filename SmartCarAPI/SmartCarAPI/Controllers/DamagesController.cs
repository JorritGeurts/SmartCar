using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCarAPI.Data;
using SmartCarAPI.Models;

namespace SmartCarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamagesController : ControllerBase
    {
        private readonly SmartCarContext _context;

        public DamagesController(SmartCarContext context)
        {
            _context = context;
 
        }

        [HttpGet]
        public async Task<IActionResult> GetDamages()
        {
            var damages = await _context.Damage.ToListAsync();

            if (damages == null || !damages.Any())
            {
                return NotFound("No damages found.");
            }

            return Ok(damages);
        }

        //[HttpPost]
        //public async Task<IActionResult> PostDamage(Damage damageDto)
        //{
        //    if (damageDto == null)
        //    {
        //        return BadRequest("Damage data is required.");
        //    }

        //    // Create a new Damage entity
        //    var damage = new Damage
        //    {
        //        damageType = "damageDto.DamageType",
        //        severity = 1
        //    };

        //    // Add to the context and save changes
        //    _context.Damage.Add(damage);
        //    await _context.SaveChangesAsync();

        //    // Return the created damage record with a 201 status code
        //    return await GetDamages();
        //}

    }
}
