using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Paper;
using PrintCalculator.Abstract.PaperInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PaperControllers
{

    [Route("/api/papertypes")]

    public class PaperTypeController : Controller
    {

        private readonly IPaperTypeServices _paperTypeServices;

        public PaperTypeController(IPaperTypeServices paperTypeServices)
        {
            _paperTypeServices = paperTypeServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaperTypeById(Guid id)
        {
            var result = await _paperTypeServices.TakePaperTypeById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPaperTypes()
        {
            var result = await _paperTypeServices.TakePaperTypes();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaperType([FromBody] Guid id)
        {
            await _paperTypeServices.DeletePaperType(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPaperType([FromBody] PaperType paperType)
        {
            await _paperTypeServices.AddPaperType(paperType);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaperType([FromBody] PaperType paperType)
        {
            await _paperTypeServices.UpdatePaperType(paperType);
            return Ok();
        }
    }
}
