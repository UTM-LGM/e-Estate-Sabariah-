using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TownsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get all town
        [HttpGet]
        public async Task<IActionResult> GetTown()
        {
            var town = await _context.towns.Select(x => new
            {
                id = x.Id,
                town = x.town,
                stateId = x.stateId,
                isActive = x.isActive,
                state = _context.states.Where(y => y.Id == x.stateId).Select(y => y.state).FirstOrDefault()
            }).ToListAsync();
            return Ok(town);
            //var town = await _context.towns.ToListAsync();
            //return Ok(town);
        }

        [HttpPost]
        public async Task<IActionResult> AddTown([FromBody] Town town)
        {
            await _context.towns.AddAsync(town);
            await _context.SaveChangesAsync();

            return Ok(town);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.towns.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
