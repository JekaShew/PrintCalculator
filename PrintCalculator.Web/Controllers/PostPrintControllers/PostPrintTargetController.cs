using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.PostPrint;
using PrintCalculator.Abstract.PostPrintInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PostPrintControllers
{

    [Route("/api/postprinttargets")]

    public class PostPrintTargetController : Controller
    {

        private readonly IPostPrintTargetServices _postPrintTargetServices;

        public PostPrintTargetController(IPostPrintTargetServices postPrintTargetServices)
        {
            _postPrintTargetServices = postPrintTargetServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostPrintTargetById(Guid id)
        {
            var result = await _postPrintTargetServices.TakePostPrintTargetById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPostPrintTargets()
        {
            var result = await _postPrintTargetServices.TakePostPrintTargets();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePostPrintTarget([FromBody] Guid id)
        {
            await _postPrintTargetServices.DeletePostPrintTarget(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPostPrintTarget([FromBody] PostPrintTarget postPrintTarget)
        {
            await _postPrintTargetServices.AddPostPrintTarget(postPrintTarget);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostPrintTarget([FromBody] PostPrintTarget postPrintTarget)
        {
            await _postPrintTargetServices.UpdatePostPrintTarget(postPrintTarget);
            return Ok();
        }
    }
}
