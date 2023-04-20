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
    public class CropCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CropCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //get
        [HttpGet]
        public async Task<IActionResult> GetCropCategory()
        {
            var category = await _context.cropCategories.ToListAsync();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCrop([FromBody] CropCategory crop)
        {
            await _context.cropCategories.AddAsync(crop);
            await _context.SaveChangesAsync();
            return Ok(crop);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.cropCategories.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
