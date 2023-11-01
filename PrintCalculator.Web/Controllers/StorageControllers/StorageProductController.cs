using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Storage;
using PrintCalculator.Abstract.StorageInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.StorageControllers
{
    [Route("/api/storageproducts")]

    public class StorageProductController : Controller
    {

        private readonly IStorageProductServices _storageProductServices;

        public StorageProductController(IStorageProductServices storageProductServices)
        {
            _storageProductServices = storageProductServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStorageProductById(Guid id)
        {
            var result = await _storageProductServices.TakeStorageProductById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetStorageProducts()
        {
            var result = await _storageProductServices.TakeStorageProducts();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStorageProduct([FromBody] Guid id)
        {
            await _storageProductServices.DeleteStorageProduct(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddStorageProduct([FromBody] StorageProduct storageProduct)
        {
            await _storageProductServices.AddStorageProduct(storageProduct);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStorageProduct([FromBody] StorageProduct storageProduct)
        {
            await _storageProductServices.UpdateStorageProduct(storageProduct);
            return Ok();
        }
    }
}
