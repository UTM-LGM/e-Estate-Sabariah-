using E_EstateV2_API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompaniesController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        //Get All Company
        [HttpGet]
        public async Task<IActionResult> GetCompany()
        {
            var company = await _context.companies.ToListAsync();
            return Ok(company);
        }

        //Get One Company
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetOneCompany([FromRoute] int id)
        {
            var company = await _context.companies.Where(x => x.Id == id).Select(x => new
            {
                id = x.Id,
                companyName = x.companyName,
                address1 = x.address1,
                address2 = x.address2,
                address3 = x.address3,
                postcode = x.postcode,
                town = x.town,
                phone = x.phone,
                email = x.email,
                fax = x.fax,
                contactNo = x.contactNo,
                managerName = x.managerName,
                isActive = x.isActive,
                estates = _context.estates.Where(y => y.companyId == id).Select(e=> new
                {
                    id=e.Id,
                    estateName=e.estateName,
                    email = e.email,
                    licenseNo = e.licenseNo,
                    totalArea = e.totalArea,
                    isActive = e.isActive,
                    town = _context.towns.Where(y => y.Id == e.townId).Select(y => y.town).FirstOrDefault(),
                    membership = _context.membershipTypes.Where(y => y.Id == e.membershipTypeId).Select(y => y.membershipType).FirstOrDefault(),
                    fields = _context.fields.Where(y => y.estateId == e.Id).Select(f=> new
                    {
                        id = f.Id,
                        fieldName = f.fieldName,
                        area = f.area,
                        isMature = f.isMature,
                        isActive = f.isActive,
                        dateOpenTapping = f.dateOpenTapping,
                        yearPlanted = f.yearPlanted,
                        otherCrop = f.otherCrop,
                        cropCategory = _context.cropCategories.Where(y => y.Id == f.cropCategoryId).Select(y => y.cropCategory).FirstOrDefault()
                    }).ToList()
                }).ToList(),
            }).FirstOrDefaultAsync();
            return Ok(company);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateStatus([FromBody] int id)
        {
            var existingStatus = await _context.companies.Where(x => x.Id == id).FirstOrDefaultAsync();
            existingStatus.isActive = !existingStatus.isActive;
            await _context.SaveChangesAsync();
            return Ok(existingStatus);
        }
    }
}
