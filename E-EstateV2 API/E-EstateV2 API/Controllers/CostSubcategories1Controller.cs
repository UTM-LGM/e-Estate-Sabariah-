using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostSubcategories1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CostSubcategories1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddSubCat([FromBody] CostSubcategory1 costSubcategory1)
        {
            await _context.costSubcategories1.AddAsync(costSubcategory1);
            await _context.SaveChangesAsync();
            return Ok(costSubcategory1);
        }

        [HttpGet]
        public async Task<IActionResult> GetSub()
        {
            var sub = await _context.costSubcategories1.ToListAsync();
            return Ok(sub);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.costSubcategories1.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
