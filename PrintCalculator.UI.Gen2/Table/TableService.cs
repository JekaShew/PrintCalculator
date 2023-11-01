using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using PrintCalculator.UI.Gen2.Table.Abstract;
using PrintCalculator.UI.Gen2.Data.Abstract;
using PrintCalculator.UI.Gen2.Table.Data;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.FileStorage;

namespace PrintCalculator.UI.Gen2.Table
{
    /// <summary>
    /// Client-Database table logic
    /// </summary>
    /// <typeparam name="TDM">Data model type</typeparam>
    /// <typeparam name="TVM">View model type</typeparam>
    public class TableService<TDM, TVM> 
        where TVM : TableModel<TDM>, new()
        where TDM : Model
    {
        protected readonly DbContext appDbContext;
        protected readonly StorageService mediaService;
        protected readonly string defaultOrder;
        protected readonly string selectQuery;
        protected readonly Func<IQueryable<TDM>, IQueryable<TDM>> includes;

        public TableService(DbContext appDbContext, string selectQuery, string defaultOrder, StorageService mediaService, Func<IQueryable<TDM>, IQueryable<TDM>> includes)
        {
            this.appDbContext = appDbContext;
            this.selectQuery = selectQuery;
            this.defaultOrder = defaultOrder;
            this.mediaService = mediaService;
            this.includes = includes;
        }

        /// <summary>
        /// Get table items
        /// </summary>
        public virtual async Task<TableContractOutput<TVM>> Get(TableContractInput input)
        {
            var sql = $"{BuildSelect()} {BuildWhere(input.Filters)} {BuildOrder(input.Order, input.IsOrderAsc)} {BuildSkipTake(input.Skip, input.Take)}";
            return new TableContractOutput<TVM>
            {
                Data = (await includes(appDbContext
                    .Set<TDM>()
                    .FromSqlRaw(sql)
                    .AsQueryable())
                    .ToListAsync())
                    .Select(x => { var vm = new TVM(); vm.FromDataModel(x, new UtilsServices { AppDbContext = appDbContext, StorageService = mediaService }); return vm; })
                    .ToList()
            };
        }

        protected virtual string BuildSelect()
        {
            return $"{selectQuery} \r\n";
        }

        protected virtual string BuildWhere(List<ColumnFilter> filters)
        {
            var usedFilters = filters.Where(x => x.InUse);
            if (usedFilters.Count() == 0)
                return "";

            return $"WHERE {string.Join(" AND ", filters.Where(x => x.InUse).Select(x => x.BuildQuery()))} \r\n";
        }

        protected virtual string BuildOrder(string order, bool isOrderAsc)
        {
            if (isOrderAsc)
                return $"ORDER BY {(string.IsNullOrWhiteSpace(order) ? defaultOrder : order)} \r\n";
            else
                return $"ORDER BY {(string.IsNullOrWhiteSpace(order) ? defaultOrder : order)} DESC \r\n";
        }

        protected virtual string BuildSkipTake(int skip, int take)
        {
            return $"OFFSET {skip} ROWS \r\nFETCH NEXT {take} ROWS ONLY \r\n";
        }
    }

    /// <summary>
    /// Table service utils
    /// </summary>
    public static class TableService
    {
        /// <summary>
        /// Simple select from table
        /// </summary>
        public static string SelectFromTable(string tableName) => $"SELECT * FROM {tableName}";
    }
}
