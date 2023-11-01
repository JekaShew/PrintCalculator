using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Table;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.Data;
using PrintCalculator.ViewModels.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers
{
    //-------------------------------------  PAPER  -----------------------------//
    [Route("/api/table/papersizes")]
    public class PaperSizeController : TableControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperSize, ViewModels.Table.Paper.PaperSize>
    {
        public PaperSizeController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM PaperSizes ",
            "Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/paperdensities")]
    public class PaperDensityController : TableControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperDensity, ViewModels.Table.Paper.PaperDensity>
    {
        public PaperDensityController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM PaperDensities ",
            "Density",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/papers")]
    public class PaperController : TableControllerAutoMapped<PrintCalculator.Data.Models.Paper.Paper, ViewModels.Table.Paper.Paper>
    {
        public PaperController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT Papers.* FROM Papers " +
            "LEFT JOIN PaperTypes ON PaperTypes.Id = Papers.PaperTypeId " +
             "LEFT JOIN PaperPriceGroups ON PaperPriceGroups.Id = Papers.PaperPriceGroupId " +
             "LEFT JOIN PaperDensities ON PaperDensities.Id = Papers.PaperDensityId " +
             "LEFT JOIN PaperSizes ON PaperSizes.Id = Papers.PaperSizeId ",
            "Papers.Title",
            query => query
                .Include(pt => pt.PaperType)
                .Include(ppg => ppg.PaperPriceGroup)
                .Include(pd => pd.PaperDensity)
                .Include(ps => ps.PaperSize),
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/paperformats")]
    public class PaperFormatController : TableControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperFormat, ViewModels.Table.Paper.PaperFormat>
    {
        public PaperFormatController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT PaperFormats.* FROM PaperFormats "+
            "LEFT JOIN PaperSizes ON PaperSizes.Id = PaperFormats.PaperSizeId ",
            "PaperFormats.Title",
            query => query
                .Include(ps => ps.PaperSize),
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/paperpricegroups")]
    public class PaperPriceGroupController : TableControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperPriceGroup, ViewModels.Table.Paper.PaperPriceGroup>
    {
        public PaperPriceGroupController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT PaperPriceGroups.* FROM PaperPriceGroups " +
            "LEFT JOIN PaperClasses ON PaperClasses.Id = PaperPriceGroups.PaperClassId ",
            "PaperPriceGroups.Title",
            query => query
                .Include(pc => pc.PaperClass),
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    //[Route("/api/tables/paperclasses")]
    //public class PaperClassesTableController
    //    : TableController<Data.Models.Paper.PaperClass, ViewModels.Table.Paper.PaperClass>
    //{
    //    public PaperClassesTableController(AppDBContext appDbContext, StorageService mediaService) : base(
    //        TableService.SelectFromTable("PaperClasses"),
    //        "Title",
    //        query => query,
    //        appDbContext,
    //        mediaService
    //        //new UI.Gen2.Table.Data.TableRoles
    //        //{
    //        //    Get = Constants.Roles.References.REFERENCES_GET,
    //        //}
    //    )
    //    { }
    //}

    [Route("/api/table/paperclasses")]
    public class PaperClassController : TableControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperClass, ViewModels.Table.Paper.PaperClass>
    {
        public PaperClassController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT PaperClasses.* FROM PaperClasses ",
            "PaperClasses.Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/papertypes")]
    public class PaperTypeController : TableControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperType, ViewModels.Table.Paper.PaperType>
    {
        public PaperTypeController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT PaperTypes.* FROM PaperTypes " +
            "LEFT JOIN PaperDensities ON PaperDensities.Id = PaperTypes.PaperDensityId " +
            "LEFT JOIN PaperClasses ON PaperClasses.Id = PaperTypes.PaperClassId " +
            "LEFT JOIN PaperPriceGroups ON PaperPriceGroups.Id = PaperTypes.PaperPriceGroupId ",
            "PaperTypes.Title",
            query => query
                .Include(pd => pd.PaperDensity)
                .Include(pc => pc.PaperClass)
                .Include(ppg => ppg.PaperPriceGroup),
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/papercoefficients")]
    public class PaperCoefficientController : TableControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperCoefficient, ViewModels.Table.Paper.PaperCoefficient>
    {
        public PaperCoefficientController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT PaperCoefficients.* FROM PaperCoefficients " +
            "LEFT JOIN PaperDensities ON PaperDensities.Id = PaperCoefficients.PaperDensityId " +
            "LEFT JOIN TechProcesses ON TechProcesses.Id = PaperCoefficients.TechProcessId ",
            "PaperCoefficients.Title",
            query => query
                .Include(pd => pd.PaperDensity)
                .Include(tp => tp.TechProcess),
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    //-------------------------------------  STORAGE  -----------------------------//

    [Route("/api/table/storages")]
    public class StorageController : TableControllerAutoMapped<PrintCalculator.Data.Models.Storage.Storage, ViewModels.Table.Storage.Storage>
    {
        public StorageController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM Storages ",
            "Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/categories")]
    public class CategoryController : TableControllerAutoMapped<PrintCalculator.Data.Models.Storage.Category, ViewModels.Table.Storage.Category>
    {
        public CategoryController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM Categories " ,
            "Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/subcategories")]
    public class SubCategoryController : TableControllerAutoMapped<PrintCalculator.Data.Models.Storage.SubCategory, ViewModels.Table.Storage.SubCategory>
    {
        public SubCategoryController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT SubCategories.* FROM SubCategories " +
            "LEFT JOIN Categories ON Categories.Id = SubCategories.CategoryId ",
            "SubCategories.Title",
            query => query
                .Include(c => c.Category),
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/unitmeasures")]
    public class UnitMeasureController : TableControllerAutoMapped<PrintCalculator.Data.Models.Storage.UnitMeasure, ViewModels.Table.Storage.UnitMeasure>
    {
        public UnitMeasureController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM UnitMeasures " ,
            "Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/storageproducts")]
    public class StorageProductController : TableControllerAutoMapped<PrintCalculator.Data.Models.Storage.StorageProduct, ViewModels.Table.Storage.StorageProduct>
    {
        public StorageProductController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT StorageProducts.* FROM StorageProducts " +
            "LEFT JOIN UnitMeasures ON UnitMeasures.Id = StorageProducts.UnitMeasureId " +
            "LEFT JOIN SubCategories ON SubCategories.Id = StorageProducts.SubCategoryId " +
            "LEFT JOIN Storages ON Storages.Id = StorageProducts.StorageId ",
            "StorageProducts.Title",
            query => query
                .Include(um => um.UnitMeasure)
                .Include(sc => sc.SubCategory)
                .Include(s => s.Storage),
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    //-------------------------------------  PostPrint  ---------------------------//

    [Route("/api/table/packagingtypes")]
    public class PackagingTypeController : TableControllerAutoMapped<PrintCalculator.Data.Models.PostPrint.PackagingType, ViewModels.Table.PostPrint.PackagingType>
    {
        public PackagingTypeController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM PackagingTypes " ,
            "Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/postprintgroups")]
    public class PostPrintGroupController : TableControllerAutoMapped<PrintCalculator.Data.Models.PostPrint.PostPrintGroup, ViewModels.Table.PostPrint.PostPrintGroup>
    {
        public PostPrintGroupController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM PostPrintGroups " ,
            "Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/postprintoperations")]
    public class PostPrintOperationController : TableControllerAutoMapped<PrintCalculator.Data.Models.PostPrint.PostPrintOperation, ViewModels.Table.PostPrint.PostPrintOperation>
    {
        public PostPrintOperationController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT PostPrintOperations.* FROM PostPrintOperations " +
            "LEFT JOIN PostPrintGroups ON PostPrintGroups.Id = PostPrintOperations.PostPrintGroupId " +
            "LEFT JOIN PostPrintTargets ON PostPrintTargets.Id = PostPrintOperations.PostPrintTargetId " +
            "LEFT JOIN Sectors ON Sectors.Id = PostPrintOperations.SectorId ",
            "PostPrintOperations.Title",
            query => query
                .Include(ppg => ppg.PostPrintGroup)
                .Include(ppt => ppt.PostPrintTarget)
                .Include(s => s.Sector),
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/postprintprices")]
    public class PostPrintPriceController : TableControllerAutoMapped<PrintCalculator.Data.Models.PostPrint.PostPrintPrice, ViewModels.Table.PostPrint.PostPrintPrice>
    {
        public PostPrintPriceController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT PostPrintPrices.* FROM PostPrintPrices " +
            "LEFT JOIN PostPrintPriceGroups ON PostPrintPriceGroups.Id = PostPrintPrices.PostPrintPriceGroupId " +
            "LEFT JOIN PostPrintTargets ppt1 ON ppt1.Id = PostPrintPrices.MainPostPrintTargetId " +
            "LEFT JOIN PostPrintTargets ppt2 ON ppt2.Id = PostPrintPrices.AdditionalPostPrintTargetId " +
            "LEFT JOIN PaperFormats ON PaperFormats.Id = PostPrintPrices.PaperFormatId ",
            "PostPrintPrices.Title",
            query => query
                .Include(pppg => pppg.PostPrintPriceGroup)
                .Include(ppt => ppt.MainPostPrintTarget)
                .Include(ppt => ppt.AdditionalPostPrintTarget)
                .Include(pf => pf.PaperFormat),
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/postprintpricegroups")]
    public class PostPrintPriceGroupController : TableControllerAutoMapped<PrintCalculator.Data.Models.PostPrint.PostPrintPriceGroup, ViewModels.Table.PostPrint.PostPrintPriceGroup>
    {
        public PostPrintPriceGroupController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM PostPrintPriceGroups " ,
            "Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/postprinttargets")]
    public class PostPrintTargetController : TableControllerAutoMapped<PrintCalculator.Data.Models.PostPrint.PostPrintTarget, ViewModels.Table.PostPrint.PostPrintTarget>
    {
        public PostPrintTargetController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM PostPrintTargets ",
            "Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    //-------------------------------------  TechProcess  -------------------------//

    [Route("/api/table/options")]
    public class OptionController : TableControllerAutoMapped<PrintCalculator.Data.Models.TechProcess.Option, ViewModels.Table.TechProcess.Option>
    {
        public OptionController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM Options ",
            "Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/printtypes")]
    public class PrintTypeController : TableControllerAutoMapped<PrintCalculator.Data.Models.TechProcess.PrintType, ViewModels.Table.TechProcess.PrintType>
    {
        public PrintTypeController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM PrintTypes ",
            "Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/sectors")]
    public class SectorController : TableControllerAutoMapped<PrintCalculator.Data.Models.TechProcess.Sector, ViewModels.Table.TechProcess.Sector>
    {
        public SectorController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT * FROM Sectors ",
            "Title",
            query => query,
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/techprocessoptions")]
    public class TechProcessOptionController : TableControllerAutoMapped<PrintCalculator.Data.Models.TechProcess.TechProcessOption, ViewModels.Table.TechProcess.TechProcessOption>
    {
        public TechProcessOptionController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT TechProcessOptions.* FROM TechProcessOptions " +
            "LEFT JOIN TechProcesses ON TechProcesses.Id = TechProcessOptions.TechProcessId " +
            "LEFT JOIN Options ON Options.Id = TechProcessOptions.OptionId ",
            "TechProcessOptions.Title",
            query => query
                .Include(tp => tp.TechProcess)
                .Include(o => o.Option),
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }

    [Route("/api/table/techprocesses")]
    public class TechProcessController : TableControllerAutoMapped<PrintCalculator.Data.Models.TechProcess.TechProcess, ViewModels.Table.TechProcess.TechProcess>
    {
        public TechProcessController(AppDBContext appDbContext, StorageService mediaService, IMapper autoMapper) : base(
            "SELECT TechProcesses.* FROM TechProcesses " +
            "LEFT JOIN PrintTypes ON PrintTypes.Id = TechProcesses.PrintTypeId " +
            "LEFT JOIN Sectors ON Sectors.Id = TechProcesses.SectorId " +
            "LEFT JOIN Storages ON Storages.Id = TechProcesses.StorageId " +
            "LEFT JOIN PaperFormats ON PaperFormats.Id = TechProcesses.PaperFormatId " +
            "LEFT JOIN PaperSizes ON PaperSizes.Id = TechProcesses.PaperSizeId " +
            "LEFT JOIN TechProcessOptions ON TechProcessOptions.TechProcessId = TechProcesses.Id " +
            "LEFT JOIN Options ON Options.Id = TechProcessOptions.OptionId ",
            "TechProcesses.Title",
            query => query
            .Include(pt => pt.PrintType)
                .Include(sec => sec.Sector)
                .Include(sto => sto.Storage)
                .Include(pf => pf.PaperFormat)
                .Include(ps => ps.PaperSize)
                .Include(tpo => tpo.TechProcessOptions).ThenInclude(o => o.Option),
            appDbContext,
            mediaService,
            autoMapper
        )
        { }
    }
}
