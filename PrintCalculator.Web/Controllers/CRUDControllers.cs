using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Crud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.Data.Models.Paper;
using PrintCalculator.Data.Models.PostPrint;
using PrintCalculator.Data.Models.Storage;
using PrintCalculator.Data.Models.TechProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers.CRUDControllers
{
    //---------------------------------------  PAPER  -----------------------------------//
    [Route("/api/crud/papersizes")]
    public class PaperSizeController : CrudControllerAutoMapped<PaperSize, ViewModels.Data.Paper.PaperSize>
    {
        public PaperSizeController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper) 
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/paperdensities")]
    public class PaperDensityController : CrudControllerAutoMapped<PaperDensity, ViewModels.Data.Paper.PaperDensity>
    {
        public PaperDensityController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/paperformats")]
    public class PaperFormatController : CrudControllerAutoMapped<PaperFormat, ViewModels.Data.Paper.PaperFormat>
    {
        public PaperFormatController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => 
                x.Include(ps=> ps.PaperSize), autoMapper)
        {
        }
    }

    [Route("/api/crud/paperpricegroups")]
    public class PaperPriceGroupController : CrudControllerAutoMapped<PaperPriceGroup, ViewModels.Data.Paper.PaperPriceGroup>
    {
        public PaperPriceGroupController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => 
                x.Include(pc=> pc.PaperClass), autoMapper)
        {
        }
    }

    [Route("/api/crud/papertypes")]
    public class PaperTypeController : CrudControllerAutoMapped<PaperType, ViewModels.Data.Paper.PaperType>
    {
        public PaperTypeController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => 
                x.Include(pd=> pd.PaperDensity)
                .Include(pc=> pc.PaperClass)
                .Include(ppg=> ppg.PaperPriceGroup), autoMapper)
        {
        }
    }

    [Route("/api/crud/paperclasses")]
    public class PaperClassController : CrudControllerAutoMapped<PaperClass, ViewModels.Data.Paper.PaperClass>
    {
        public PaperClassController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/papercoefficients")]
    public class PaperCoefficientController : CrudControllerAutoMapped<PaperCoefficient, ViewModels.Data.Paper.PaperCoefficient>
    {
        public PaperCoefficientController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => 
                x.Include(pd=> pd.PaperDensity)
                .Include(tp=> tp.TechProcess), autoMapper)
        {
        }
    }

    [Route("/api/crud/papers")]
    public class PaperController : CrudControllerAutoMapped<Paper, ViewModels.Data.Paper.Paper>
    {
        public PaperController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => 
                x.Include(pt=> pt.PaperType)
                .Include(ppg=> ppg.PaperPriceGroup)
                .Include(pd=> pd.PaperDensity)
                .Include(ps=> ps.PaperSize), autoMapper)
        {
        }
    }

    //---------------------------------------  STORAGE  ---------------------------------//
    [Route("/api/crud/storages")]
    public class StorageController : CrudControllerAutoMapped<Storage, ViewModels.Data.Storage.Storage>
    {
        public StorageController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/categories")]
    public class CategoryController : CrudControllerAutoMapped<Category, ViewModels.Data.Storage.Category>
    {
        public CategoryController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/subcategories")]
    public class SubCategoryController : CrudControllerAutoMapped<SubCategory, ViewModels.Data.Storage.SubCategory>
    {
        public SubCategoryController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => 
                x.Include(c=> c.Category), autoMapper)
        {
        }
    }

    [Route("/api/crud/unitmeasures")]
    public class UnitMeasureController : CrudControllerAutoMapped<UnitMeasure, ViewModels.Data.Storage.UnitMeasure>
    {
        public UnitMeasureController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/storageproducts")]
    public class StorageProductController : CrudControllerAutoMapped<StorageProduct, ViewModels.Data.Storage.StorageProduct>
    {
        public StorageProductController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => 
                x.Include(um=> um.UnitMeasure)
                .Include(sc=> sc.SubCategory)
                .Include(s=> s.Storage), autoMapper)
        {
        }
    }

    //---------------------------------------  PostPrint  ---------------------------------//

    [Route("/api/crud/packagingtypes")]
    public class PackagingTypeController : CrudControllerAutoMapped<PackagingType, ViewModels.Data.PostPrint.PackagingType>
    {
        public PackagingTypeController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/postprintgroups")]
    public class PostPrintGroupController : CrudControllerAutoMapped<PostPrintGroup, ViewModels.Data.PostPrint.PostPrintGroup>
    {
        public PostPrintGroupController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/postprintoperations")]
    public class PostPrintOperationController : CrudControllerAutoMapped<PostPrintOperation, ViewModels.Data.PostPrint.PostPrintOperation>
    {
        public PostPrintOperationController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => 
                x.Include(ppg=> ppg.PostPrintGroup)
                .Include(ppt=> ppt.PostPrintTarget)
                .Include(s=> s.Sector), autoMapper)
        {
        }
    }

    [Route("/api/crud/postprintprices")]
    public class PostPrintPriceController : CrudControllerAutoMapped<PostPrintPrice, ViewModels.Data.PostPrint.PostPrintPrice>
    {
        public PostPrintPriceController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => 
                x.Include(pppg=> pppg.PostPrintPriceGroup)
                .Include(mppt=> mppt.MainPostPrintTarget)
                .Include(mppt => mppt.AdditionalPostPrintTarget)
                .Include(pf=> pf.PaperFormat), autoMapper)
        {
        }
    }

    [Route("/api/crud/postprintpricegroups")]
    public class PostPrintPriceGroupController : CrudControllerAutoMapped<PostPrintPriceGroup, ViewModels.Data.PostPrint.PostPrintPriceGroup>
    {
        public PostPrintPriceGroupController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/postprinttargets")]
    public class PostPrintTargetController : CrudControllerAutoMapped<PostPrintTarget, ViewModels.Data.PostPrint.PostPrintTarget>
    {
        public PostPrintTargetController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    //---------------------------------------  TechProcess  -------------------------------//

    [Route("/api/crud/options")]
    public class OptionController : CrudControllerAutoMapped<Option, ViewModels.Data.TechProcess.Option>
    {
        public OptionController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/printtypes")]
    public class PrintTypeController : CrudControllerAutoMapped<PrintType, ViewModels.Data.TechProcess.PrintType>
    {
        public PrintTypeController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/sectors")]
    public class SectorController : CrudControllerAutoMapped<Sector, ViewModels.Data.TechProcess.Sector>
    {
        public SectorController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => x, autoMapper)
        {
        }
    }

    [Route("/api/crud/techprocesses")]
    public class TechProcessController : CrudControllerAutoMapped<TechProcess, ViewModels.Data.TechProcess.TechProcess>
    {
        public TechProcessController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => 
                x.Include(pt=> pt.PrintType)
                .Include(sec=> sec.Sector)
                .Include(sto=> sto.Storage)
                .Include(pf=> pf.PaperFormat)
                .Include(ps=> ps.PaperSize)
                .Include(tpo=> tpo.TechProcessOptions).ThenInclude(o=> o.Option), autoMapper)
        {
        }
    }

    [Route("/api/crud/techprocessoptions")]
    public class TechProcessOptionController : CrudControllerAutoMapped<TechProcessOption, ViewModels.Data.TechProcess.TechProcessOption>
    {
        public TechProcessOptionController(DbContext appDbContext, StorageService mediaService, IMapper autoMapper)
            : base(appDbContext, mediaService, x => 
                x.Include(tp=> tp.TechProcess)
                .Include(o=> o.Option), autoMapper)
        {
        }
    }
}
