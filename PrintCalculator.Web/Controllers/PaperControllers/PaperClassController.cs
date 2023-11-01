using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Paper;
using PrintCalculator.Abstract.PaperInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PaperControllers
{

    [Route("/api/paperclasses")]

    public class PaperClassController : Controller
    {

        private readonly IPaperClassServices _paperClassServices;

        public PaperClassController(IPaperClassServices paperClassServices)
        {
            _paperClassServices = paperClassServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaperClassById(Guid id)
        {
            var result = await _paperClassServices.TakePaperClassById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet("TakeAll")]
        public async Task<IActionResult> GetPaperClasses()
        {
            var result = await _paperClassServices.TakePaperClasses();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePaperClass([FromBody] Guid id)
        {
            await _paperClassServices.DeletePaperClass(id);
            return Ok();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddPaperClass([FromBody] PaperClass paperClass)
        {
            await _paperClassServices.AddPaperClass(paperClass);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdatePaperClass([FromBody] PaperClass paperClass)
        {
            await _paperClassServices.UpdatePaperClass(paperClass);
            return Ok();
        }
    }
}
