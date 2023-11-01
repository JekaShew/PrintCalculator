using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Autocomplete.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Autocomplete
{
    /// <summary>
    /// Client-Database autocomplete logic
    /// </summary>
    /// <typeparam name="TDM">Data model type</typeparam>
    /// <typeparam name="TVM">View model type</typeparam>
    public class AutocompleteService<TDM, TVM> 
        where TDM : Model
        where TVM : AutocompleteModel<TDM>, new()
    {
        protected readonly DbContext appDbContext;
        protected readonly IMapper autoMapper;
        protected readonly StorageService mediaService;
        protected readonly Func<IQueryable<TDM>, string, IQueryable<TDM>> search;
        protected readonly Func<IQueryable<TDM>, IQueryable<TDM>> includes;
        protected readonly int maxItems;

        public AutocompleteService(DbContext appDbContext, Func<IQueryable<TDM>, string, IQueryable<TDM>> search, StorageService mediaService, Func<IQueryable<TDM>, IQueryable<TDM>> includes,IMapper autoMapper, int maxItems)
        {
            this.autoMapper = autoMapper;
            this.appDbContext = appDbContext;
            this.search = search;
            this.mediaService = mediaService;
            this.includes = includes;
            this.maxItems = maxItems;
        }

        /// <summary>
        /// Get items by search string
        /// </summary>
        public virtual async Task<List<TVM>> Get(string query)
        {
            var result = await includes(search(appDbContext.Set<TDM>().AsNoTracking(), query)).Take(maxItems).ToListAsync();
            return result.Select(x =>
            {
                var vm = new TVM();
                vm.FromDataModel(x, new UtilsServices { StorageService = mediaService, AppDbContext = appDbContext });
                return vm;
            }).ToList();
        }
    }
}
