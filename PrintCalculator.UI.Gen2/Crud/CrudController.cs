using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Crud
{
    /// <summary>
    /// Base controller for <see cref="CrudService{TDM, TVM}"/>
    /// </summary>
    /// <typeparam name="TDM">Data model type</typeparam>
    /// <typeparam name="TVM">View model type</typeparam>
    public abstract class CrudController<TDM, TVM> : Controller
        where TDM : Model, new()
        where TVM : IdViewModel<TDM>, new()
    {
        protected CrudService<TDM, TVM> service;

        protected CrudController(DbContext appDbContext, StorageService mediaService, Func<IQueryable<TDM>, IQueryable<TDM>> includes, IMapper autoMapper)
        {
            service = new CrudService<TDM, TVM>(appDbContext, mediaService, includes, autoMapper);
        }

        protected CrudController(CrudService<TDM, TVM> service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get item
        /// </summary>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            var result = await service.Get(id);
            return Ok(result);
        }

        /// <summary>
        /// Add item
        /// </summary>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromForm] TVM vm)
        {
            if (ModelState.IsValid)
            {
                await service.Add(vm);
                return Ok(vm);
            }
            else
            {
                return HandleBadRequest(vm);
            }
        }

        /// <summary>
        /// Update item
        /// </summary>
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromForm] TVM vm)
        {
            if (ModelState.IsValid)
            {
                await service.Update(vm);
                return Ok(vm);
            }
            else
            {
                return HandleBadRequest(vm);
            }
        }

        /// <summary>
        /// Delete item
        /// </summary>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            await service.Delete(id);
            return Ok();
        }

        protected virtual IActionResult HandleBadRequest(TVM vm)
        {
            var errors = new Dictionary<string, string>(ModelState
                .Select(x => new KeyValuePair<string, string>(x.Key, x.Value.Errors.FirstOrDefault()?.ErrorMessage))
                .Where(x => !string.IsNullOrWhiteSpace(x.Value)));

            return BadRequest(new
            {
                Type = "ValidationError",
                Errors = errors,
            });
        }
    }
}
