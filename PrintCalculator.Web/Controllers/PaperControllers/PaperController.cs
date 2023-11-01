using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Paper;
using PrintCalculator.Abstract.PaperInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PaperControllers
{

    [Route("/api/papers")]

    public class PaperController : Controller
    {

        private readonly IPaperServices _paperServices;

        public PaperController(IPaperServices paperServices)
        {
            _paperServices = paperServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaperById(Guid id)
        {
            var result = await _paperServices.TakePaperById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPapers()
        {
            var result = await _paperServices.TakePapers();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaper([FromBody] Guid id)
        {
            await _paperServices.DeletePaper(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPaper([FromBody] Paper paper)
        {
            await _paperServices.AddPaper(paper);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaper([FromBody] Paper paper)
        {
            await _paperServices.UpdatePaper(paper);
            return Ok();
        }
    }
}
