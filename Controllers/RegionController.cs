using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICodeDemo.Data;
using WebAPICodeDemo.Models.Domain;
using WebAPICodeDemo.Models.DTO;
using WebAPICodeDemo.Repositries;

namespace WebAPICodeDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegionController : ControllerBase
    {
        private NzwalksDBContext _DBContext { get; set; }
        public IRegionRepo RegionRepo { get; }

 

        public RegionController(NzwalksDBContext dBContext, IRegionRepo regionRepo)
        {
            this._DBContext = dBContext;
            this.RegionRepo = regionRepo;
        }
        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            //domain data
            var regions = await RegionRepo.GetAllAsync();

            //Dto 
            var Regiondtos = new List<RegionDto>();
            foreach (var region in  regions)
            {
                Regiondtos.Add(new RegionDto
                {
                    ID = region.ID,
                    Code = region.Code,
                  Name=region.Name,
                }
                    );
            }
            return Ok(Regiondtos);
        }
        [HttpGet]
        [Route("{Code}")]
        public async Task< IActionResult> GetById([FromRoute] string Code)
        {
            var region =await _DBContext.Regions.FirstOrDefaultAsync(x=>x.Code == Code);
            if(region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionDto addRegionDto)
        {
            //covert domain to dto
            var regdominmodel = new Regions
            {

                Code = addRegionDto.Code,
                Name = addRegionDto.Name

            };

            await  _DBContext.Regions.AddAsync(regdominmodel);
            await _DBContext.SaveChangesAsync();

            //var regiondto = new RegionDto
            //{
            //    Code = regdominmodel.Code,
            //    Name = regdominmodel.Name

            //};
            return CreatedAtAction(nameof(GetById),new { Code= regdominmodel.Code }, addRegionDto);
        }


        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateData([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            var findata = await _DBContext.Regions.FirstOrDefaultAsync(x => x.ID == id);
            if (findata ==null)
            {
                return NotFound();
            }

            findata.Code = updateRegionDto.Code;
                findata.Name = updateRegionDto.Name;
           await _DBContext.SaveChangesAsync();

            var regiodatamode = new Regions
            {
                ID = id,
                Code = updateRegionDto.Code,
                Name = updateRegionDto.Name,
                RegionImgURL = updateRegionDto.RegionImgURL,
            };


          //  _DBContext.Regions.Add(regiodatamode);
          
            return Ok(updateRegionDto);

        }
    }
}
