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
    public class StatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //get
        [HttpGet]
        public async Task<IActionResult> GetState()
        {
            var state = await _context.states.ToListAsync();
            return Ok(state);
        }

        [HttpPost]
        public async Task<IActionResult> AddState([FromBody] State state)
        {
            await _context.states.AddAsync(state);
            await _context.SaveChangesAsync();

            return Ok(state);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.states.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }


    }
}
