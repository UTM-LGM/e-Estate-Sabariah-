using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldProductionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FieldProductionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduction()
        {
            var production = await _context.fieldProductions.Select(x => new
            {
                id = x.Id,
                monthYear = x.monthYear,
                cuplump = x.cuplump,
                cuplumpDRC = x.cuplumpDRC,
                latex = x.latex,
                latexDRC = x.latexDRC,
                noTaskTap = x.noTaskTap,
                noTaskUntap = x.noTaskUntap,
                fieldId = x.fieldId,
                fieldName = _context.fields.Where(y => y.Id == x.fieldId).Select(y => y.fieldName).FirstOrDefault()
            }).ToListAsync();
            return Ok(production);
        }

        [HttpPost]
        public async Task<IActionResult> AddFieldProduction([FromBody] FieldProduction[] productions)
        {
            foreach(var item in productions)
            {
                await _context.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduction([FromBody] FieldProduction production)
        {
            var existingProduction = await _context.fieldProductions.FirstOrDefaultAsync(x => x.Id == production.Id);
            if(existingProduction != null)
            {
                existingProduction.cuplump = production.cuplump;
                existingProduction.cuplumpDRC= production.cuplumpDRC;
                existingProduction.latex = production.latex;
                existingProduction.latexDRC = production.latexDRC;
                existingProduction.noTaskTap= production.noTaskTap;
                existingProduction.noTaskUntap= production.noTaskUntap;
                await _context.SaveChangesAsync();
                return Ok(existingProduction);
            }
            return NotFound();
        }
    }
}
