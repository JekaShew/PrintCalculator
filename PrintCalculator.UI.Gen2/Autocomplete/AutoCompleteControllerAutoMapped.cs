using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Autocomplete.Abstract;
using PrintCalculator.UI.Gen2.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Autocomplete
{
    public class AutoCompleteControllerAutoMapped<TDM, TVM> : AutocompleteController<TDM, TVM>
        where TDM : Model
        where TVM : AutocompleteModel<TDM>, new()
    {
        public AutoCompleteControllerAutoMapped(Func<IQueryable<TDM>, string, IQueryable<TDM>> search, Func<IQueryable<TDM>, IQueryable<TDM>> includes, IMapper autoMapper, int maxItems, DbContext appDbContext, StorageService mediaService)
            : base(search, includes, autoMapper, maxItems, appDbContext, mediaService)
        {
            service = new AutoCompleteServiceAutoMapped<TDM, TVM>(appDbContext, search, mediaService, includes, autoMapper, maxItems);
        }

       
    }
}
