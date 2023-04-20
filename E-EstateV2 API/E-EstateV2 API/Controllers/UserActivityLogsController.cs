using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActivityLogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserActivityLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddActivityLog([FromBody] UserActivityLog acyivityLog)
        {
            await _context.userActivityLogs.AddAsync(acyivityLog);
            await _context.SaveChangesAsync();
            return Ok(acyivityLog);
        }
    }
}
