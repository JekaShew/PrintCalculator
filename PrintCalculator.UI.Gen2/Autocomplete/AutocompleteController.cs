using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Autocomplete.Abstract;
using PrintCalculator.UI.Gen2.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Autocomplete
{
    /// <summary>
    /// Base controller for <see cref="AutocompleteService{TDM, TVM}"/>
    /// </summary>
    /// <typeparam name="TDM">Data model type</typeparam>
    /// <typeparam name="TVM">View model type</typeparam>
    public abstract class AutocompleteController<TDM, TVM> : Controller
        where TDM : Model
        where TVM : AutocompleteModel<TDM>, new()
    {
        protected AutocompleteService<TDM, TVM> service;

        protected AutocompleteController(Func<IQueryable<TDM>, string, IQueryable<TDM>> search, Func<IQueryable<TDM>, IQueryable<TDM>> includes,IMapper autoMapper, int maxItems, DbContext appDbContext, StorageService mediaService)
        {
            service = new AutocompleteService<TDM, TVM>(appDbContext, search, mediaService, includes,autoMapper, maxItems);
        }

        protected AutocompleteController(AutocompleteService<TDM, TVM> service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get items by search string
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string query)
        {
            if (query == null)
                query = "";
            var result = await service.Get(query);
            return Ok(result);
        }
    }
}
