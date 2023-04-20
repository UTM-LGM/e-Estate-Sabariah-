using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostAmountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CostAmountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddCostAmount([FromBody] CostAmount[] amount)
        {
            foreach(var item in amount)
            {
                await _context.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCostAmount()
        {
            var amount = await _context.costAmounts.Select(x => new
            {
                id = x.Id,
                amount = x.amount,
                year = x.year,
                estates = _context.estates.Where(y => y.Id == x.estateId).ToList(),
                costs = _context.costs.Where(y => y.Id == x.costId).Select(e => new
                {
                    id = e.Id,
                    isMature = e.isMature,
                    isActive = e.isActive,
                    costType = _context.costTypes.Where(y => y.Id == e.costTypeId).Select(y => y.costType).FirstOrDefault(),
                    costCategory = _context.costCategories.Where(y => y.Id == e.costCategoryId).Select(y => y.costCategory).FirstOrDefault(),
                    costSubcategory1 = _context.costSubcategories1.Where(y => y.Id == e.costSubcategory1Id).Select(y => y.costSubcategory1).FirstOrDefault(),
                    costSubcategory2 = _context.costSubcategories2.Where(y => y.Id == e.costSubcategory2Id).Select(y => y.costSubcategory2).FirstOrDefault()
                }).ToList(),
            }).ToListAsync();
            return Ok(amount);
        }
    }
}
