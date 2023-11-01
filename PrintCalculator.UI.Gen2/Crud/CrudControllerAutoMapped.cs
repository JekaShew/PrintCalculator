using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Crud
{
    public class CrudControllerAutoMapped<TDM, TVM> : CrudController<TDM, TVM>
         where TDM : Model, new()
        where TVM : IdViewModel<TDM>, new()
    {
        public CrudControllerAutoMapped(DbContext appDbContext, StorageService mediaService, Func<IQueryable<TDM>, IQueryable<TDM>> includes, IMapper autoMapper) : base(appDbContext, mediaService, includes, autoMapper)
        {
            service = new CrudServiceAutoMapped<TDM, TVM>(appDbContext, mediaService, includes, autoMapper);
        }
    }
}
