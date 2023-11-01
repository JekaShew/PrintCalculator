using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Crud
{
    public  class CrudServiceAutoMapped<TDM, TVM> : CrudService<TDM, TVM>
         where TDM : Model, new()
        where TVM : IdViewModel<TDM>, new()
    {
        public CrudServiceAutoMapped(DbContext appDbContext, StorageService mediaService, Func<IQueryable<TDM>, IQueryable<TDM>> includes, IMapper autoMapper) : base(appDbContext, mediaService, includes, autoMapper)
        {
        }

        public override async Task<TVM> Get(Guid id)
        {
            var dm = await includes(appDbContext.Set<TDM>()).FirstOrDefaultAsync(x => x.Id == id);
            var vm = autoMapper.Map<TVM>(dm);
            //dm = await includes(appDbContext.Set<TDM>()).FirstOrDefaultAsync(x => x.Id == id);
            vm.FromDataModel(dm, Service);
            return vm;
        }
        public override async Task Add(TVM vm)
        {
            vm.Id = Guid.Empty;
            var dm = autoMapper.Map<TDM>(vm);
            vm.ToDataModel(dm, new UtilsServices { AppDbContext = appDbContext, StorageService = mediaService });
            await appDbContext.Set<TDM>().AddAsync(dm);
            await appDbContext.SaveChangesAsync();
            
            vm.Id = dm.Id;
        }

        public override async Task Update(TVM vm)
        {
            var dm = new TDM {Id = vm.Id.Value };
            //dm.Id = vm.Id.Value;
            //dm = autoMapper.Map<TDM>(vm);
            //vm.FromDataModel(dm, Service);
            dm = await includes(appDbContext.Set<TDM>()).FirstAsync(x => x.Id == vm.Id.Value);
            vm.ToDataModel(dm, Service);
            appDbContext.Entry(dm).State = EntityState.Modified;        
            await appDbContext.SaveChangesAsync();
        }

        public override async Task Delete(Guid id)
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
