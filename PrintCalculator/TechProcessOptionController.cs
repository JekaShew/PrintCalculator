using Microsoft.AspNetCore.Mvc;
using PrintCalculator.Abstract.Data.TechProcess;
using PrintCalculator.Abstract.TechProcessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.TechProcessControllers
{

    [Route("/api/techprocessoptions")]

    public class TechProcessOptionController : Controller
    {

        private readonly ITechProcessOptionServices _techProcessOptionServices;

        public TechProcessOptionController(ITechProcessOptionServices techProcessOptionServices)
        {
            _techProcessOptionServices = techProcessOptionServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechProcessOptionById(Guid id)
        {
            var result = await _techProcessOptionServices.TakeTechProcessOptionById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetTechProcessOptions()
        {
            var result = await _techProcessOptionServices.TakeTechProcessOptions();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTechProcessOption([FromBody] Guid id)
        {
            await _techProcessOptionServices.DeleteTechProcessOption(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddTechProcessOption([FromBody] TechProcessOption techProcessOption)
        {
            await _techProcessOptionServices.AddTechProcessOption(techProcessOption);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTechProcessOption([FromBody] TechProcessOption techProcessOption)
        {
            await _techProcessOptionServices.UpdateTechProcessOption(techProcessOption);
            return Ok();
        }
    }
}
