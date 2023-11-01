using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.PostPrint;
using PrintCalculator.Abstract.PostPrintInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PostPrintControllers
{

    [Route("/api/postprintoperations")]

    public class PostPrintOperationController : Controller
    {

        private readonly IPostPrintOperationServices _postPrintOperationServices;

        public PostPrintOperationController(IPostPrintOperationServices postPrintOperationServices)
        {
            _postPrintOperationServices = postPrintOperationServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostPrintOperationById(Guid id)
        {
            var result = await _postPrintOperationServices.TakePostPrintOperationById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPostPrintOperations()
        {
            var result = await _postPrintOperationServices.TakePostPrintOperations();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePostPrintOperation([FromBody] Guid id)
        {
            await _postPrintOperationServices.DeletePostPrintOperation(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPostPrintOperation([FromBody] PostPrintOperation postPrintOperation)
        {
            await _postPrintOperationServices.AddPostPrintOperation(postPrintOperation);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePostPrintOperation([FromBody] PostPrintOperation postPrintOperation)
        {
            await _postPrintOperationServices.UpdatePostPrintOperation(postPrintOperation);
            return Ok();
        }
    }
}
