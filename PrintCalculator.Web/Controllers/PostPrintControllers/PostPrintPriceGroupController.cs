using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.PostPrint;
using PrintCalculator.Abstract.PostPrintInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PostPrintControllers
{

    [Route("/api/postprintpricegroups")]

    public class PostPrintPriceGroupController : Controller
    {

        private readonly IPostPrintPriceGroupServices _postPrintPriceGroupServices;

        public PostPrintPriceGroupController(IPostPrintPriceGroupServices postPrintPriceGroupServices)
        {
            _postPrintPriceGroupServices = postPrintPriceGroupServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostPrintPriceGroupById(Guid id)
        {
            var result = await _postPrintPriceGroupServices.TakePostPrintPriceGroupById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPostPrintPriceGroups()
        {
            var result = await _postPrintPriceGroupServices.TakePostPrintPriceGroups();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePostPrintPriceGroup([FromBody] Guid id)
        {
            await _postPrintPriceGroupServices.DeletePostPrintPriceGroup(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPostPrintPriceGroup([FromBody] PostPrintPriceGroup postPrintPriceGroup)
        {
            await _postPrintPriceGroupServices.AddPostPrintPriceGroup(postPrintPriceGroup);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostPrintPriceGroup([FromBody] PostPrintPriceGroup postPrintPriceGroup)
        {
            await _postPrintPriceGroupServices.UpdatePostPrintPriceGroup(postPrintPriceGroup);
            return Ok();
        }
    }
}
