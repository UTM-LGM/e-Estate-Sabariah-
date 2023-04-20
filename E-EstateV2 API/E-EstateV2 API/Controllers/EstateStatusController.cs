using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstateStatusController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddStatusHistory([FromBody] EstateStatus status)
        {
            await _context.estateStatusLog.AddAsync(status);
            await _context.SaveChangesAsync();
            return Ok(status);
        }
    }
}
