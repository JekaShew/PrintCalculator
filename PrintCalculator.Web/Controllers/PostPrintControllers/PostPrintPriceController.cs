using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.PostPrint;
using PrintCalculator.Abstract.PostPrintInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PostPrintControllers
{

    [Route("/api/postprintprices")]

    public class PostPrintPriceController : Controller
    {

        private readonly IPostPrintPriceServices _postPrintPriceServices;

        public PostPrintPriceController(IPostPrintPriceServices postPrintPriceServices)
        {
        _postPrintPriceServices = postPrintPriceServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostPrintPriceById(Guid id)
        {
            var result = await _postPrintPriceServices.TakePostPrintPriceById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPostPrintPrices()
        {
            var result = await _postPrintPriceServices.TakePostPrintPrices();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePostPrintPrice([FromBody] Guid id)
        {
            await _postPrintPriceServices.DeletePostPrintPrice(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPostPrintPrice([FromBody] PostPrintPrice postPrintPrice)
        {
            await _postPrintPriceServices.AddPostPrintPrice(postPrintPrice);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostPrintPrice([FromBody] PostPrintPrice postPrintPrice)
        {
            await _postPrintPriceServices.UpdatePostPrintPrice(postPrintPrice);
            return Ok();
        }
    }
}
