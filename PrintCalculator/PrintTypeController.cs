using Microsoft.AspNetCore.Mvc;
using PrintCalculator.Abstract.Data.TechProcess;
using PrintCalculator.Abstract.TechProcessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.TechProcessControllers
{

    [Route("/api/printtypes")]

    public class PrintTypeController : Controller
    {

        private readonly IPrintTypeServices _printTypeServices;

        public PrintTypeController(IPrintTypeServices printTypeServices)
        {
            _printTypeServices = printTypeServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrintTypeById(Guid id)
        {
            var result = await _printTypeServices.TakePrintTypeById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPrintTypes()
        {
            var result = await _printTypeServices.TakePrintTypes();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePrintType([FromBody] Guid id)
        {
            await _printTypeServices.DeletePrintType(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPrintType([FromBody] PrintType printType)
        {
            await _printTypeServices.AddPrintType(printType);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePrintType([FromBody] PrintType printType)
        {
            await _printTypeServices.UpdatePrintType(printType);
            return Ok();
        }
    }
}
