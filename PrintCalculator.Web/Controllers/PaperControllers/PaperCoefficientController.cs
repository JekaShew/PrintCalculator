using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Paper;
using PrintCalculator.Abstract.PaperInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PaperControllers
{

    [Route("/api/papercoefficients")]

    public class PaperCoefficientController : Controller
    {
        private readonly IPaperCoefficientServices _paperCoefficientServices;

        public PaperCoefficientController(IPaperCoefficientServices paperCoefficientServices)
        {
            _paperCoefficientServices = paperCoefficientServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaperCoefficientById(Guid id)
        {
            var result = await _paperCoefficientServices.TakePaperCoefficientById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPaperCoefficients()
        {
            var result = await _paperCoefficientServices.TakePaperCoefficients();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaperCoefficient([FromBody] Guid id)
        {
            await _paperCoefficientServices.DeletePaperCoefficient(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPaperCoefficient([FromBody] PaperCoefficient paperCoefficient)
        {
            await _paperCoefficientServices.AddPaperCoefficient(paperCoefficient);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaperCoefficient([FromBody] PaperCoefficient paperCoefficient)
        {
            await _paperCoefficientServices.UpdatePaperCoefficient(paperCoefficient);
            return Ok();
        }
    }
}
