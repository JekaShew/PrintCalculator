using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Data.Abstract;
using PrintCalculator.UI.Gen2.Table.Abstract;
using PrintCalculator.UI.Gen2.Table.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Table
{
    /// <summary>
    /// Base controller for <see cref="TableController{TDM, TVM}"/>
    /// </summary>
    /// <typeparam name="TDM">Data model type</typeparam>
    /// <typeparam name="TVM">View model type</typeparam>
    public abstract class TableController<TDM, TVM> : Controller
        where TVM : TableModel<TDM>, new()
        where TDM : Model
    {
        protected TableService<TDM, TVM> service;
        protected readonly TableRoles roles;

        protected TableController(string selectQuery, string defaultOrder, Func<IQueryable<TDM>, IQueryable<TDM>> includes, DbContext appDbContext, StorageService mediaService)
        {
            service = new TableService<TDM, TVM>(appDbContext, selectQuery, defaultOrder, mediaService, includes);
        }

        protected TableController(string selectQuery, string defaultOrder, Func<IQueryable<TDM>, IQueryable<TDM>> includes, DbContext appDbContext, StorageService mediaService, TableRoles roles)
            : this(selectQuery, defaultOrder, includes, appDbContext, mediaService)
        {
            this.roles = roles;
        }

        protected TableController(TableService<TDM, TVM> service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get table items
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] TableContractInput input)
        {
            if (roles != null && roles.Get != null && !CheckAuthorized())
            {
                return StatusCode(401);
            }
            if (roles != null && roles.Get != null && !CheckRole(roles.Get))
            {
                return StatusCode(403);
            }
            var result = await service.Get(input);
            return Ok(result);
        }

        protected virtual bool CheckRole(string role)
        {
            return HttpContext.User.IsInRole(role);
        }

        protected virtual bool CheckAuthorized()
        {
            return HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
