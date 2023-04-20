using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldClonesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FieldClonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddClone([FromBody] FieldClone[] fieldClone)
        {
            foreach(var item in fieldClone)
            {
                await _context.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
