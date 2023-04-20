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
    public class EstatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstatesController(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        //Get All
        [HttpGet]
        public async Task<IActionResult> GetAllEstates()
        {
            //var estates = await _context.estates.ToListAsync();
            var estate = await _context.estates.Select(x => new
            {
                id = x.Id,
                estateName = x.estateName,
                address1 = x.address1,
                address2 = x.address2,
                address3 = x.address3,
                postcode = x.postcode,
                licenseNo = x.licenseNo,
                totalArea = x.totalArea,
                email = x.email,
                isActive = x.isActive,
                townId = x.townId,
                town = _context.towns.Where(y => y.Id == x.townId).Select(y => y.town).FirstOrDefault(),
                membership = _context.membershipTypes.Where(y => y.Id == x.membershipTypeId).Select(y => y.membershipType).FirstOrDefault()
            }).ToListAsync();
            return Ok(estate);

        }

        //Get one estate
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetEstate")]
        public async Task<IActionResult> GetEstate([FromRoute] int id)
        {
            var estate = await _context.estates.Where(x => x.Id == id).Select(x => new
            {
                id = x.Id,
                estateName = x.estateName,
                address1 = x.address1,
                address2 = x.address2,
                address3 = x.address3,
                postcode = x.postcode,
                phone = x.phone,
                fax = x.fax,
                licenseNo = x.licenseNo,
                totalArea = x.totalArea,
                email = x.email,
                isActive = x.isActive,
                town = _context.towns.Where(y => y.Id == x.townId).Select(y => y.town).FirstOrDefault(),
                stateId = _context.towns.Where(y => y.Id == x.townId).Select(y => y.stateId).FirstOrDefault(),
                state = _context.states.Where(y=>y.Id == _context.towns.Where(z=>z.Id == x.townId).Select(x=>x.stateId).FirstOrDefault()).Select(y=>y.state).FirstOrDefault(),
                membership = _context.membershipTypes.Where(y => y.Id == x.membershipTypeId).Select(y => y.membershipType).FirstOrDefault(),
                financialYear = _context.financialYears.Where(y => y.Id == x.financialYearId).Select(y => y.financialYear).FirstOrDefault(),
                establishment = _context.establishments.Where(y => y.Id == x.establishmentId).Select(y => y.establishment).FirstOrDefault(),
                fields = _context.fields.Where(y => y.estateId == id).ToList(),
                cropCategory = _context.cropCategories.Where(y => y.Id == _context.fields.Where(x => x.estateId == id).Select(x => x.cropCategoryId).FirstOrDefault()).Select(y => y.cropCategory).FirstOrDefault(),
            }).FirstOrDefaultAsync();
            return Ok(estate);
        }

        [HttpPost]
        public async Task<IActionResult> AddEstate([FromBody] Estate estate)
        {

            await _context.estates.AddAsync(estate);
            await _context.SaveChangesAsync();

            return Ok(estate);
        }

        //status in estate table
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.estates.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
