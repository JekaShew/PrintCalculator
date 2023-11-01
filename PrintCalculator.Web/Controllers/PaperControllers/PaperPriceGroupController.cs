using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Paper;
using PrintCalculator.Abstract.PaperInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PaperControllers
{

    [Route("/api/paperpricegroups")]

    public class PaperPriceGroupController : Controller
    {

        private readonly IPaperPriceGroupServices _paperPriceGroupServices;

        public PaperPriceGroupController(IPaperPriceGroupServices paperPriceGroupServices)
        {
            _paperPriceGroupServices = paperPriceGroupServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaperPriceGroupById(Guid id)
        {
            var result = await _paperPriceGroupServices.TakePaperPriceGroupById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPaperPriceGroups()
        {
            var result = await _paperPriceGroupServices.TakePaperPriceGroups();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePaperPriceGroup([FromBody] Guid id)
        {
            await _paperPriceGroupServices.DeletePaperPriceGroup(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPaperPriceGroup([FromBody] PaperPriceGroup paperPriceGroup)
        {
            await _paperPriceGroupServices.AddPaperPriceGroup(paperPriceGroup);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaperPriceGroup([FromBody] PaperPriceGroup paperPriceGroup)
        {
            await _paperPriceGroupServices.UpdatePaperPriceGroup(paperPriceGroup);
            return Ok();
        }
    }
}
