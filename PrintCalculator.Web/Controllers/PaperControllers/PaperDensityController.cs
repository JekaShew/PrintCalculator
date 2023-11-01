using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Paper;
using PrintCalculator.Abstract.PaperInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PaperControllers
{

    [Route("/api/paperdensities")]

    public class PaperDensityController : Controller
    {
        private readonly IPaperDensityServices _paperDensityServices;

        public PaperDensityController(IPaperDensityServices paperDensityServices)
        {
            _paperDensityServices = paperDensityServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaperDensityById(Guid id)
        {
            var result = await _paperDensityServices.TakePaperDensityById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPaperDensities()
        {
            var result = await _paperDensityServices.TakePaperDensities();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaperDensity([FromBody] Guid id)
        {
            await _paperDensityServices.DeletePaperDensity(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPaperDensity([FromBody] PaperDensity paperDensity)
        {
            await _paperDensityServices.AddPaperDensity(paperDensity);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaperDensity([FromBody] PaperDensity paperDensity)
        {
            await _paperDensityServices.UpdatePaperDensity(paperDensity);
            return Ok();
        }
    }
}
