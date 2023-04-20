using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaborsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LaborsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddLabor([FromBody] Labor labor)
        {
            await _context.labors.AddAsync(labor);
            await _context.SaveChangesAsync();
            return Ok(labor);
        }

        [HttpGet]
        public async Task<IActionResult> GetLabor()
        {
            var labor = await _context.labors.Select(x => new
            {
                id = x.Id,
                monthYear = x.monthYear,
                tapperCheckrole = x.tapperCheckrole,
                tapperContractor = x.tapperContractor,
                fieldCheckrole = x.fieldCheckrole,
                fieldContractor = x.fieldContractor,
                workerNeeded = x.workerNeeded,
                country = _context.countries.Where(y => y.Id == x.countryId).ToList()
            }).ToListAsync();
            return Ok(labor);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteLabor([FromRoute] int id)
        {
            var existingLabor = await _context.labors.FirstOrDefaultAsync(x => x.Id == id);
            if(existingLabor != null)
            {
                _context.labors.Remove(existingLabor);
                await _context.SaveChangesAsync();
                return Ok(existingLabor);
            }
            return NotFound("Labor Not Found");
        }
    }
}
