using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Storage;
using PrintCalculator.Abstract.StorageInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.StorageControllers
{
    [Route("/api/unitmeasures")]
   
    public class UnitMeasureController : Controller
    {

        private readonly IUnitMeasureServices _unitMeasureServices;

        public UnitMeasureController(IUnitMeasureServices unitMeasureServices)
        {
            _unitMeasureServices = unitMeasureServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnitMeasureById(Guid id)
        {
            var result = await _unitMeasureServices.TakeUnitMeasureById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetUnitMeasures()
        {
            var result = await _unitMeasureServices.TakeUnitMeasures();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUnitMeasure([FromBody] Guid id)
        {
            await _unitMeasureServices.DeleteUnitMeasure(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddUnitMeasure([FromBody] UnitMeasure unitMeasure)
        {
            await _unitMeasureServices.AddUnitMeasure(unitMeasure);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUnitMeasure([FromBody] UnitMeasure unitMeasure)
        {
            await _unitMeasureServices.UpdateUnitMeasure(unitMeasure);
            return Ok();
        }
    }
}
