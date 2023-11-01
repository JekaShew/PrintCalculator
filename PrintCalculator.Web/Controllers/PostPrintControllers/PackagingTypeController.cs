using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.PostPrint;
using PrintCalculator.Abstract.PostPrintInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.PostPrintControllers
{

    [Route("/api/packagingtypes")]

    public class PackagingTypeController : Controller
    {

        private readonly IPackagingTypeServices _packagingTypeServices;

        public PackagingTypeController(IPackagingTypeServices packagingTypeServices)
        {
            _packagingTypeServices = packagingTypeServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackagingTypeById(Guid id)
        {
            var result = await _packagingTypeServices.TakePackagingTypeById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPackagingTypes()
        {
            var result = await _packagingTypeServices.TakePackagingTypes();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePackagingType([FromBody] Guid id)
        {
            await _packagingTypeServices.DeletePackagingType(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPackagingType([FromBody] PackagingType packagingType)
        {
            await _packagingTypeServices.AddPackagingType(packagingType);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePackagingType([FromBody] PackagingType packagingType)
        {
            await _packagingTypeServices.UpdatePackagingType(packagingType);
            return Ok();
        }
    }
}
