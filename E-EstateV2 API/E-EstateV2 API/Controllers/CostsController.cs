using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCostItem()
        {
            var cost = await _context.costs.Select(x => new
            {
                id = x.Id,
                isMature = x.isMature,
                isActive = x.isActive,
                costType = _context.costTypes.Where(y => y.Id == x.costTypeId).Select(y => y.costType).FirstOrDefault(),
                costCategory = _context.costCategories.Where(y => y.Id == x.costCategoryId).Select(y => y.costCategory).FirstOrDefault(),
                costSubcategory1 = _context.costSubcategories1.Where(y => y.Id == x.costSubcategory1Id).Select(y => y.costSubcategory1).FirstOrDefault(),
                costSubcategory2 = _context.costSubcategories2.Where(y=>y.Id == x.costSubcategory2Id).Select(y=>y.costSubcategory2).FirstOrDefault()
            }).ToListAsync();
            return Ok(cost);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCostIndirect()
        {
            var cost = await _context.costs.Where(x => x.isActive == true && x.costTypeId == 2).Select(x => new
            {
                id=x.Id,
                costSubcategory2Id = _context.costSubcategories2.Where(y => y.Id == x.costSubcategory2Id).Select(y => y.Id).FirstOrDefault(),
                costSubcategory2 = _context.costSubcategories2.Where(y => y.Id == x.costSubcategory2Id).Select(y => y.costSubcategory2).FirstOrDefault(),
            }).Distinct().ToListAsync();
            return Ok(cost);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCostCategoryM()
        {
            var costCat = await _context.costs.Where(x => x.isActive == true && x.isMature == true && x.costCategoryId != 4).Select(x => new
            {
                costCategoryId = _context.costCategories.Where(y => y.Id == x.costCategoryId).Select(y => y.Id).FirstOrDefault(),
                costCategory = _context.costCategories.Where(y => y.Id == x.costCategoryId).Select(y => y.costCategory).FirstOrDefault(),
            }).Distinct().ToListAsync();
            return Ok(costCat);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCostSubCategory1M()
        {
            var costSub = await _context.costs.Where(x => x.isActive == true && x.isMature == true && x.costSubcategory1Id != 2).Select(x=> new
            {
                id=x.Id,
                costSubcategory1Id = _context.costSubcategories1.Where(y => y.Id == x.costSubcategory1Id).Select(y=>y.Id).FirstOrDefault(),
                costSubcategory1 = _context.costSubcategories1.Where(y => y.Id == x.costSubcategory1Id).Select(y => y.costSubcategory1).FirstOrDefault(),
                costCategoryId = _context.costCategories.Where(y => y.Id == x.costCategoryId).Select(y => y.Id).FirstOrDefault(),
                costSubcategory2 = _context.costSubcategories2.Where(y => y.Id == x.costSubcategory2Id).Select(y => y.costSubcategory2).FirstOrDefault(),

            }).OrderBy(x=>x.costSubcategory1Id).ToListAsync();
            return Ok(costSub);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCostSubCategory2M()
        {
            var costSub = await _context.costs.Where(x => x.isActive == true && x.isMature == true && x.costTypeId == 1).Select(x => new
            {
                costSubcategory2Id = _context.costSubcategories2.Where(y => y.Id == x.costSubcategory2Id).Select(y => y.Id).FirstOrDefault(),
                costSubcategory2 = _context.costSubcategories2.Where(y => y.Id == x.costSubcategory2Id).Select(y => y.costSubcategory2).FirstOrDefault(),
            }).Distinct().ToListAsync();
            return Ok(costSub);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCostSubCategory2IM()
        {
            var costSub = await _context.costs.Where(x => x.isActive == true && x.isMature == false && x.costTypeId == 1).Select(x => new
            {
                id = x.Id,
                costSubcategory2Id = _context.costSubcategories2.Where(y => y.Id == x.costSubcategory2Id).Select(y => y.Id).FirstOrDefault(),
                costSubcategory2 = _context.costSubcategories2.Where(y => y.Id == x.costSubcategory2Id).Select(y => y.costSubcategory2).FirstOrDefault(),
            }).Distinct().ToListAsync();
            return Ok(costSub);
        }


        [HttpPost]
        public async Task<IActionResult> AddCostItem([FromBody] Cost cost)
        {
            await _context.costs.AddAsync(cost);
            await _context.SaveChangesAsync();
            return Ok(cost);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.costs.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
