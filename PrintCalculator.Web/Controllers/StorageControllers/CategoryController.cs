using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Storage;
using PrintCalculator.Abstract.StorageInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.StorageControllers
{
    [Route("/api/categories")]
    public class CategoryController : Controller
    {
          
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var result = await _categoryServices.TakeCategoryById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryServices.TakeCategories();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] Guid id)
        {
            await _categoryServices.DeleteCategory(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            await _categoryServices.AddCategory(category);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            await _categoryServices.UpdateCategory(category);
            return Ok();
        }
    }
}
