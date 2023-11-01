using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Data.Abstract;
using PrintCalculator.UI.Gen2.Table.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Table
{
    public abstract class TableControllerAutoMapped<TDM, TVM> : TableController<TDM, TVM>
        where TVM : TableModelAutoMapped<TDM>, new()
        where TDM : Model
    {

        protected TableControllerAutoMapped(string selectQuery, string defaultOrder, Func<IQueryable<TDM>, IQueryable<TDM>> includes, DbContext appDbContext, StorageService mediaService, IMapper autoMapper) 
            : base(selectQuery, defaultOrder, includes, appDbContext, mediaService)
        {
            service = new TableServiceAutoMapped<TDM, TVM>(appDbContext, selectQuery, defaultOrder, mediaService, includes, autoMapper);
        }
    }
}
