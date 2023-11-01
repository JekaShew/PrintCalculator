using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Data.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Crud
{
    /// <summary>
    /// Base controller for <see cref="RoledCrudService{TDM, TVM}"/>
    /// </summary>
    /// <typeparam name="TDM">Data model type</typeparam>
    /// <typeparam name="TVM">View model type</typeparam>
    public abstract class RoledCrudController<TDM, TVM> : CrudController<TDM, TVM>
        where TDM : RoledModel, new()
        where TVM : RoledViewModel<TDM>, new()
    {
        protected readonly CrudRoles roles;
        protected readonly DbContext appDbContext;

        protected RoledCrudController(IHttpContextAccessor httpContextAccessor, DbContext appDbContext, StorageService storageService, Func<IQueryable<TDM>, IQueryable<TDM>> includes, IMapper autoMapper, CrudRoles roles)
            : base(new RoledCrudService<TDM, TVM>(httpContextAccessor, appDbContext, storageService, includes,autoMapper))
        {
            this.appDbContext = appDbContext;
            this.roles = roles;
        }

        /// <inheritdoc/>
        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(Guid id)
        {
            if (roles != null && roles.Get != null && !CheckAuthorized())
            {
                return StatusCode(401);
            }
            if (roles != null && roles.Get != null && !CheckRole(roles.Get))
            {
                return StatusCode(403);
            }
            return await base.Get(id);
        }

        /// <inheritdoc/>
        [HttpPost]
        public override async Task<IActionResult> Post([FromForm] TVM vm)
        {
            if (roles != null && roles.Add != null && !CheckAuthorized())
            {
                return StatusCode(401);
            }
            if (roles != null && roles.Add != null && !CheckRole(roles.Add))
            {
                return StatusCode(403);
            }
            return await base.Post(vm);
        }

        /// <inheritdoc/>
        [HttpPut]
        public override async Task<IActionResult> Put([FromForm] TVM vm)
        {
            if (roles != null && roles.Update != null && !CheckAuthorized())
            {
                return StatusCode(401);
            }
            if (roles != null && roles.Update != null && !CheckRole(roles.Update) && !CheckOwn(vm.Id.Value))
            {
                return StatusCode(403);
            }
            return await base.Put(vm);
        }

        /// <inheritdoc/>
        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(Guid id)
        {
            if (roles != null && roles.Delete != null && !CheckAuthorized())
            {
                return StatusCode(401);
            }
            if (roles != null && roles.Delete != null && !CheckRole(roles.Delete) && !CheckOwn(id))
            {
                return StatusCode(403);
            }
            return await base.Delete(id);
        }

        protected virtual bool CheckRole(string role)
        {
            return HttpContext.User.IsInRole(role);
        }

        protected virtual bool CheckAuthorized()
        {
            return HttpContext.User.Identity.IsAuthenticated;
        }

        protected virtual bool CheckOwn(Guid id)
        {
            var userId = Guid.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var maxDate = DateTime.Now - roles.OwnExceed;
            var data = appDbContext.Set<TDM>().AsNoTracking().First(x => x.Id == id);
            return data.UpdatedBy == userId && data.UpdatedOn > maxDate;
        }
    }
}
