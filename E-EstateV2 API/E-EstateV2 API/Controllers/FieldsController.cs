using E_EstateV2_API.Data;
using E_EstateV2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FieldsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddField([FromBody] Field field)
        {
            await _context.fields.AddAsync(field);
            await _context.SaveChangesAsync();
            return Ok(field);
        }

        [HttpGet]
        public async Task<IActionResult> GetField()
        {
            var field = await _context.fields.Select(x => new
            {
                id = x.Id,
                fieldName = x.fieldName,
                area = x.area,
                isMature = x.isMature,
                isActive = x.isActive,
                dateOpenTapping = x.dateOpenTapping,
                yearPlanted = x.yearPlanted,
                otherCrop = x.otherCrop,
                cropCategory = _context.cropCategories.Where(y => y.Id == x.cropCategoryId).Select(y => y.cropCategory).FirstOrDefault()
            }).ToListAsync();
            return Ok(field);
        }

        //single data
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOneField([FromRoute] int id)
        {
            var cloneIds = _context.fieldClones.Where(y => y.fieldId == id).Select(y => y.cloneId).ToList();
            var field = await _context.fields.Where(x=>x.Id == id).Select(x => new
            {
                id = x.Id,
                fieldName = x.fieldName,
                area = x.area,
                isMature = x.isMature,
                isActive = x.isActive,
                dateOpenTapping = x.dateOpenTapping,
                yearPlanted = x.yearPlanted,
                otherCrop = x.otherCrop,
                cropCategoryId = _context.cropCategories.Where(y => y.Id == x.cropCategoryId).Select(y => y.Id).FirstOrDefault(),
                //clones = _context.clones.Where(y=>y.Id == _context.fieldClones.Where(y => y.fieldId == id).Select(y => y.cloneId).FirstOrDefault()).ToList()
                clones = _context.clones.Where(y => cloneIds.Contains(y.Id)).ToList()
        }).FirstOrDefaultAsync();
            return Ok(field);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateField([FromRoute] int id, [FromBody] Field field)
        {
            var existingField = await _context.fields.FirstOrDefaultAsync(x => x.Id == id);
            if(existingField != null)
            {
                existingField.fieldName= field.fieldName;
                existingField.area= field.area;
                existingField.isMature= field.isMature;
                existingField.cropCategoryId=field.cropCategoryId;
                existingField.otherCrop= field.otherCrop;
                existingField.yearPlanted= field.yearPlanted;
                existingField.dateOpenTapping= field.dateOpenTapping;
                await _context.SaveChangesAsync();
                return Ok(existingField);
            }
            return NotFound("Field Not Found");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddClone([FromBody] FieldClone clone)
        {
            await _context.fieldClones.AddAsync(clone);
            await _context.SaveChangesAsync();
            return Ok(clone);
        }

        [HttpDelete]
        [Route("[action]/{cloneId:int}/{fieldId:int}")]
        public async Task<IActionResult> DeleteClone([FromRoute]int cloneId , int fieldId)
        {
            var existingClone = await _context.fieldClones.FirstOrDefaultAsync(x => x.cloneId == cloneId && x.fieldId == fieldId);
            if (existingClone != null)
            {
                _context.Remove(existingClone);
                await _context.SaveChangesAsync();
                return Ok(existingClone);
            }
            return NotFound(); 
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.fields.Where(x=>x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
