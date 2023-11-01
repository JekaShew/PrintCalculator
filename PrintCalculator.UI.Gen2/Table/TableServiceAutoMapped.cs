using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Data.Abstract;
using PrintCalculator.UI.Gen2.Table.Abstract;
using PrintCalculator.UI.Gen2.Table.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Table
{
    public class TableServiceAutoMapped<TDM, TVM> : TableService<TDM, TVM>
         where TVM : TableModelAutoMapped<TDM>, new()
         where TDM : Model
    {
        protected readonly IMapper autoMapper;
        public TableServiceAutoMapped(DbContext appDbContext, string selectQuery, string defaultOrder, StorageService mediaService,
            Func<IQueryable<TDM>, IQueryable<TDM>> includes, IMapper autoMapper) 
            : base(appDbContext, selectQuery, defaultOrder, mediaService, includes)
        {
            this.autoMapper = autoMapper;
        }

        public override async Task<TableContractOutput<TVM>> Get(TableContractInput input)
        {
            var sql = $"{BuildSelect()} {BuildWhere(input.Filters)} {BuildOrder(input.Order, input.IsOrderAsc)} {BuildSkipTake(input.Skip, input.Take)}";
            return new TableContractOutput<TVM>
            {
                Data = (await includes(appDbContext
                    .Set<TDM>()
                    .FromSqlRaw(sql)
                    .AsQueryable())
                    .ToListAsync())
                    .Select(x =>
                    {
                        var vm = new TVM();
                        vm = autoMapper.Map<TVM>(x);
                        vm.FromDataModel(x, new UtilsServices { AppDbContext = appDbContext, StorageService = mediaService });
                        return vm;
                    })
                    
                    .ToList()
            };
        }
    }


}
