using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private readonly ApplicationDbContext _context;

        public DamagesController(ApplicationDbContext context)
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
    }
}
