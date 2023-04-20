using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClonesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClonesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetClone()
        {
            var clone = await _context.clones.ToListAsync();
            return Ok(clone);
        }

        [HttpPost]
        public async Task<IActionResult> AddClone([FromBody] Clone clone)
        {
            await _context.clones.AddAsync(clone);
            await _context.SaveChangesAsync();
            return Ok(clone);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.clones.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
