using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Autocomplete.Abstract;
using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Autocomplete
{
    public class AutoCompleteServiceAutoMapped<TDM, TVM> : AutocompleteService<TDM, TVM>
        where TDM : Model
        where TVM : AutocompleteModel<TDM>, new()
    {
        public AutoCompleteServiceAutoMapped(DbContext appDbContext, Func<IQueryable<TDM>, string, IQueryable<TDM>> search, StorageService mediaService, Func<IQueryable<TDM>, IQueryable<TDM>> includes, IMapper autoMapper, int maxItems) 
            : base(appDbContext, search, mediaService, includes, autoMapper, maxItems)
        {
        }
        public override async Task<List<TVM>> Get(string query)
        {
            var result = await includes(search(appDbContext.Set<TDM>().AsNoTracking(), query)).Take(maxItems).ToListAsync();
            return result.Select(x =>
            {
                var vm = autoMapper.Map<TVM>(x);
                vm.FromDataModel(x, new UtilsServices { StorageService = mediaService, AppDbContext = appDbContext });
                return vm;
            }).ToList();
        }
    }
}
