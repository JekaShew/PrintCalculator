using Microsoft.AspNetCore.Mvc;
using PrintCalculator.Abstract.Data.TechProcess;
using PrintCalculator.Abstract.TechProcessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.TechProcessControllers
{

    [Route("/api/techprocesses")]

    public class TechProcessController : Controller
    {

        private readonly ITechProcessServices _techProcessServices;

        public TechProcessController(ITechProcessServices techProcessServices)
        {
            _techProcessServices = techProcessServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechProcessById(Guid id)
        {
            var result = await _techProcessServices.TakeTechProcessById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetTechProcesses()
        {
            var result = await _techProcessServices.TakeTechProcesses();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTechProcess([FromBody] Guid id)
        {
            await _techProcessServices.DeleteTechProcess(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddTechProcess([FromBody] TechProcess techProcess)
        {
            await _techProcessServices.AddTechProcess(techProcess);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTechProcess([FromBody] TechProcess techProcess)
        {
            await _techProcessServices.UpdateTechProcess(techProcess);
            return Ok();
        }
    }
}
