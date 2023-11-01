using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Paper;
using PrintCalculator.Abstract.PaperInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PaperControllers
{

    [Route("/api/paperformats")]

    public class PaperFormatController : Controller
    {
        private readonly IPaperFormatServices _paperFormatServices;

        public PaperFormatController(IPaperFormatServices paperFormatServices)
        {
            _paperFormatServices = paperFormatServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaperFormatById(Guid id)
        {
            var result = await _paperFormatServices.TakePaperFormatById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPaperFormats()
        {
            var result = await _paperFormatServices.TakePaperFormats();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaperFormat([FromBody] Guid id)
        {
            await _paperFormatServices.DeletePaperFormat(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPaperFormat([FromBody] PaperFormat paperFormat)
        {
            await _paperFormatServices.AddPaperFormat(paperFormat);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaperFormat([FromBody] PaperFormat paperFormat)
        {
            await _paperFormatServices.UpdatePaperFormat(paperFormat);
            return Ok();
        }
    }
}
