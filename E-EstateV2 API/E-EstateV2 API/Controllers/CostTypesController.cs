using E_EstateV2_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CostTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCostType()
        {
            var type = await _context.costTypes.ToListAsync();
            return Ok(type);
        }

    }
}
