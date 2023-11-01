using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Data.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Crud
{
    /// <summary>
    /// Client-Database crud logic with authorization
    /// </summary>
    /// <typeparam name="TDM"></typeparam>
    /// <typeparam name="TVM"></typeparam>
    public class RoledCrudService<TDM, TVM> : CrudService<TDM, TVM>
        where TDM : RoledModel, new()
        where TVM : RoledViewModel<TDM>, new()
    {
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected readonly string userIdClaimName;

        public RoledCrudService(IHttpContextAccessor httpContextAccessor, DbContext appDbContext, StorageService storageService, Func<IQueryable<TDM>, IQueryable<TDM>> includes, IMapper autoMapper, string userIdClaimName = System.Security.Claims.ClaimTypes.NameIdentifier) 
            : base(appDbContext, storageService, includes, autoMapper)
        {
            
            this.httpContextAccessor = httpContextAccessor;
            this.userIdClaimName = userIdClaimName;
        }

        /// <inheritdoc/>
        public override async Task Add(TVM vm)
        {
            var dm = new TDM();
            vm.ToDataModel(dm, new UtilsServices { AppDbContext = appDbContext, StorageService = mediaService });
            dm.UpdatedOn = DateTime.Now;
            dm.UpdatedBy = GetUserId();
            await appDbContext.Set<TDM>().AddAsync(dm);
            await appDbContext.SaveChangesAsync();

            vm.Id = dm.Id;
            vm.UpdatedBy = dm.UpdatedBy;
            vm.UpdatedOn = dm.UpdatedOn;
        }

        /// <inheritdoc/>
        public override async Task Update(TVM vm)
        {
            var dm = await includes(appDbContext.Set<TDM>()).FirstAsync(x => x.Id == vm.Id.Value);
            vm.ToDataModel(dm, Service);
            await appDbContext.SaveChangesAsync();

            vm.UpdatedBy = dm.UpdatedBy;
            vm.UpdatedOn = dm.UpdatedOn;
        }

        protected Guid GetUserId() 
        {
            return Guid.Parse(httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == userIdClaimName).Value);
        }
    }
}
