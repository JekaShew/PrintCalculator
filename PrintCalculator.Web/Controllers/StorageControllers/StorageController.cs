using Microsoft.AspNetCore.Mvc;
using PrintCalculator.ViewModels.Data.Storage;
using PrintCalculator.Abstract.StorageInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.StorageControllers
{

    [Route("/api/storages")]

    public class StorageController : Controller
    {

        private readonly IStorageServices _storageServices;

        public StorageController(IStorageServices storageServices)
        {
            _storageServices = storageServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStorageById(Guid id)
        {
            var result = await _storageServices.TakeStorageById(id);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetStorages()
        {
            var result = await _storageServices.TakeStorages();
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStorage([FromBody] Guid id)
        {
            await _storageServices.DeleteStorage(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddStorage([FromBody] Storage storage)
        {
            await _storageServices.AddStorage(storage);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStorage([FromBody] Storage storage)
        {
            await _storageServices.UpdateStorage(storage);
            return Ok();
        }
    }
}
