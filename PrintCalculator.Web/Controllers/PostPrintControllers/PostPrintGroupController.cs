using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.PostPrint;
using PrintCalculator.Abstract.PostPrintInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PostPrintControllers
{

    [Route("/api/postprintgroups")]

    public class PostPrintGroupController : Controller
    {

        private readonly IPostPrintGroupServices _postPrintGroupServices;

        public PostPrintGroupController(IPostPrintGroupServices postPrintGroupServices)
        {
            _postPrintGroupServices = postPrintGroupServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostPrintGroupById(Guid id)
        {
            var result = await _postPrintGroupServices.TakePostPrintGroupById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPostPrintGroups()
        {
            var result = await _postPrintGroupServices.TakePostPrintGroups();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePostPrintGroup([FromBody] Guid id)
        {
            await _postPrintGroupServices.DeletePostPrintGroup(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPostPrintGroup([FromBody] PostPrintGroup postPrintGroup)
        {
            await _postPrintGroupServices.AddPostPrintGroup(postPrintGroup);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostPrintGroup([FromBody] PostPrintGroup postPrintGroup)
        {
            await _postPrintGroupServices.UpdatePostPrintGroup(postPrintGroup);
            return Ok();
        }
    }
}
