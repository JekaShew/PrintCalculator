using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.TechProcess;
using PrintCalculator.Abstract.TechProcessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.TechProcessControllers
{

    [Route("/api/options")]

    public class OptionController : Controller
    {

        private readonly IOptionServices _optionServices;

        public OptionController(IOptionServices optionServices)
        {
            _optionServices = optionServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionById(Guid id)
        {
            var result = await _optionServices.TakeOptionById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetOptions()
        {
            var result = await _optionServices.TakeOptions();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOption([FromBody] Guid id)
        {
            await _optionServices.DeleteOption(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddOption([FromBody] Option option)
        {
            await _optionServices.AddOption(option);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOption([FromBody] Option option)
        {
            await _optionServices.UpdateOption(option);
            return Ok();
        }
    }
}
