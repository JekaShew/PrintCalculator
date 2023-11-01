using Microsoft.AspNetCore.Mvc;
using PrintCalculator.Abstract.Data.TechProcess;
using PrintCalculator.Abstract.TechProcessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.TechProcessControllers
{

    [Route("/api/sectors")]

    public class SectorController : Controller
    {

        private readonly ISectorServices _sectorServices;

        public SectorController(ISectorServices sectorServices)
        {
            _sectorServices = sectorServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectorById(Guid id)
        {
            var result = await _sectorServices.TakeSectorById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetSectors()
        {
            var result = await _sectorServices.TakeSectors();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSector([FromBody] Guid id)
        {
            await _sectorServices.DeleteSector(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddSector([FromBody] Sector sector)
        {
            await _sectorServices.AddSector(sector);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSector([FromBody] Sector sector)
        {
            await _sectorServices.UpdateSector(sector);
            return Ok();
        }
    }
}
