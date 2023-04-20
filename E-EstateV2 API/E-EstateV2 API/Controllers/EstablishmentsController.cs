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
    public class EstablishmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstablishmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEstablishment()
        {
            var establishment = await _context.establishments.ToListAsync();
            return Ok(establishment);
        }

        [HttpPost]
        public async Task<IActionResult> AddEstablishment([FromBody] Establishment establishment)
        {
            await _context.establishments.AddAsync(establishment);
            await _context.SaveChangesAsync();

            return Ok(establishment);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.establishments.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
