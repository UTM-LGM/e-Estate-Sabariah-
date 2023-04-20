using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostSubcategories2Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CostSubcategories2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddSubCat([FromBody] CostSubcategory2 costSubcategory2)
        {
            await _context.costSubcategories2.AddAsync(costSubcategory2);
            await _context.SaveChangesAsync();
            return Ok(costSubcategory2);
        }

        [HttpGet]
        public async Task<IActionResult> GetSub()
        {
            var sub = await _context.costSubcategories2.ToListAsync();
            return Ok(sub);

        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.costSubcategories2.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
