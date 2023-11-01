using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Crud
{
    /// <summary>
    /// Client-Database crud logic
    /// </summary>
    /// <typeparam name="TDM">Data model type</typeparam>
    /// <typeparam name="TVM">View model type</typeparam>
    public class CrudService<TDM, TVM>
        where TDM : Model, new()
        where TVM : IdViewModel<TDM>, new()
    {
        protected readonly DbContext appDbContext;
        protected readonly StorageService mediaService;
        protected readonly Func<IQueryable<TDM>, IQueryable<TDM>> includes;
        protected readonly IMapper autoMapper;
        protected UtilsServices Service => new UtilsServices { AppDbContext = appDbContext, StorageService = mediaService, AutoMapper = autoMapper };

        public CrudService(DbContext appDbContext, StorageService mediaService, Func<IQueryable<TDM>, IQueryable<TDM>> includes, IMapper autoMapper)
        {
            this.autoMapper = autoMapper;
            this.appDbContext = appDbContext;
            this.mediaService = mediaService;
            this.includes = includes;
        }

        /// <summary>
        /// Get item
        /// </summary>
        public virtual async Task<TVM> Get(Guid id)
        {
            var dm = await includes(appDbContext.Set<TDM>()).FirstOrDefaultAsync(x => x.Id == id);
            var vm = new TVM();
            vm.Id = dm.Id;
            vm.FromDataModel(dm, Service);
            return vm;
        }

        /// <summary>
        /// Add or update item
        /// </summary>
        public virtual Task Commit(TVM vm)
        {
            if (vm.Id.HasValue)
                return Update(vm);
            else
                return Add(vm);
        }

        /// <summary>
        /// Add item
        /// </summary>
        public virtual async Task Add(TVM vm)
        {
            var dm = new TDM();
            vm.ToDataModel(dm, new UtilsServices { AppDbContext = appDbContext, StorageService = mediaService });
            await appDbContext.Set<TDM>().AddAsync(dm);
            await appDbContext.SaveChangesAsync();

            vm.Id = dm.Id;
        }

        /// <summary>
        /// Update item
        /// </summary>
        public virtual async Task Update(TVM vm)
        {
            var dm = await includes(appDbContext.Set<TDM>()).FirstAsync(x => x.Id == vm.Id.Value);
            vm.ToDataModel(dm, Service);
            await appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete item
        /// </summary>
        public virtual async Task Delete(Guid id)
        {
            var dm = await includes(appDbContext.Set<TDM>()).FirstAsync(x => x.Id == id);
            var vm = new TVM();
            vm.Id = dm.Id;
            vm.OnDelete(dm, Service);
            appDbContext.Set<TDM>().Remove(dm);
            await appDbContext.SaveChangesAsync();
        }
    }
}
