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
    public class FinancialYearsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FinancialYearsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFinancialYear()
        {
            var financialYear = await _context.financialYears.ToListAsync();
            return Ok(financialYear);
        }

        [HttpPost]
        public async Task<IActionResult> AddFinancialYear([FromBody] FinancialYear financialYear)
        {
            await _context.financialYears.AddAsync(financialYear);
            await _context.SaveChangesAsync();

            return Ok(financialYear);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.financialYears.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
