using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Paper;
using PrintCalculator.Abstract.PaperInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PaperControllers
{

    [Route("/api/papersizes")]

    public class PaperSizeController : Controller
    {
        private readonly IPaperSizeServices _paperSizeServices;

        public PaperSizeController(IPaperSizeServices paperSizeServices)
        {
            _paperSizeServices = paperSizeServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaperSizeById(Guid id)
        {
            var result = await _paperSizeServices.TakePaperSizeById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPaperSizes()
        {
            var result = await _paperSizeServices.TakePaperSizes();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaperSize([FromBody] Guid id)
        {
            await _paperSizeServices.DeletePaperSize(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPaperSize([FromBody] PaperSize paperSize)
        {
            await _paperSizeServices.AddPaperSize(paperSize);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaperSize([FromBody] PaperSize paperSize)
        {
            await _paperSizeServices.UpdatePaperSize(paperSize);
            return Ok();
        }
    }
}
