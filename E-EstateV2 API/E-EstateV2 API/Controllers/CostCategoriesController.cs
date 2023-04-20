using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CostCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddCostCategory([FromBody] CostCategory costCategory)
        {
            await _context.costCategories.AddAsync(costCategory); ;
            await _context.SaveChangesAsync();
            return Ok(costCategory);
        }

        [HttpGet]
        public async Task<IActionResult> GetCostCategory()
        {
            var cost = await _context.costCategories.ToListAsync();
            return Ok(cost);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.costCategories.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
