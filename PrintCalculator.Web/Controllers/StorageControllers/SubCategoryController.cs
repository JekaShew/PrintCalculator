using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Storage;
using PrintCalculator.Abstract.StorageInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.StorageControllers
{

    [Route("/api/subcategories")]

    public class SubCategoryController : Controller
    {

        private readonly ISubCategoryServices _subCategoryServices;

        public SubCategoryController(ISubCategoryServices subCategoryServices)
        {
            _subCategoryServices = subCategoryServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategoryById(Guid id)
        {
            var result = await _subCategoryServices.TakeSubCategoryById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetSubCategories()
        {
            var result = await _subCategoryServices.TakeSubCategories();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSubCategory([FromBody] Guid id)
        {
            await _subCategoryServices.DeleteSubCategory(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubCategory([FromBody] SubCategory subCategory)
        {
            await _subCategoryServices.AddSubCategory(subCategory);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubCategory([FromBody] SubCategory subCategory)
        {
            await _subCategoryServices.UpdateSubCategory(subCategory);
            return Ok();
        }
    }
}
