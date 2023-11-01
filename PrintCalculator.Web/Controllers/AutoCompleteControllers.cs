using AutoMapper;
using PrintCalculator.FileStorage;
using PrintCalculator.UI.Gen2.Autocomplete;
using Microsoft.AspNetCore.Mvc;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintCalculator.Web.Controllers
{
    [Route("/api/autocomplete/papersizes")]
    public class PaperSizesAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperSize, PrintCalculator.ViewModels.AutoComplete.PaperSize>
    {
        public PaperSizesAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper) 
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/paperdensities")]
    public class PaperDensitiesAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperDensity, PrintCalculator.ViewModels.AutoComplete.PaperDensity>
    {
        public PaperDensitiesAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Density.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/paperclasses")]
    public class PaperClassesAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperClass, PrintCalculator.ViewModels.AutoComplete.PaperClass>
    {
        public PaperClassesAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/paperformats")]
    public class PaperFormatsAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperFormat, PrintCalculator.ViewModels.AutoComplete.PaperFormat>
    {
        public PaperFormatsAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/paperpricegroups")]
    public class PaperPriceGroupsAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperPriceGroup, PrintCalculator.ViewModels.AutoComplete.PaperPriceGroup>
    {
        public PaperPriceGroupsAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/papertypes")]
    public class PaperTypesAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.Paper.PaperType, PrintCalculator.ViewModels.AutoComplete.PaperType>
    {
        public PaperTypesAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/categories")]
    public class CategoriesAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.Storage.Category, PrintCalculator.ViewModels.AutoComplete.Category>
    {
        public CategoriesAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/subcategories")]
    public class SubCategoriesAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.Storage.SubCategory, PrintCalculator.ViewModels.AutoComplete.SubCategory>
    {
        public SubCategoriesAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/unitmeasures")]
    public class UnitMeasuresAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.Storage.UnitMeasure, PrintCalculator.ViewModels.AutoComplete.UnitMeasure>
    {
        public UnitMeasuresAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/storages")]
    public class StoragesAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.Storage.Storage, PrintCalculator.ViewModels.AutoComplete.Storage>
    {
        public StoragesAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/postprintgroups")]
    public class PostPrintGroupsAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.PostPrint.PostPrintGroup, PrintCalculator.ViewModels.AutoComplete.PostPrintGroup>
    {
        public PostPrintGroupsAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/postprintpricegroups")]
    public class PostPrintPriceGroupsAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.PostPrint.PostPrintPriceGroup, PrintCalculator.ViewModels.AutoComplete.PostPrintPriceGroup>
    {
        public PostPrintPriceGroupsAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/postprinttargets")]
    public class PostPrintTargetAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.PostPrint.PostPrintTarget, PrintCalculator.ViewModels.AutoComplete.PostPrintTarget>
    {
        public PostPrintTargetAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/sectors")]
    public class SectorsAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.TechProcess.Sector, PrintCalculator.ViewModels.AutoComplete.Sector>
    {
        public SectorsAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/techprocesses")]
    public class TechProcessesAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.TechProcess.TechProcess, PrintCalculator.ViewModels.AutoComplete.TechProcess>
    {
        public TechProcessesAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/printtypes")]
    public class PrintTypesAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.TechProcess.PrintType, PrintCalculator.ViewModels.AutoComplete.PrintType>
    {
        public PrintTypesAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

    [Route("/api/autocomplete/options")]
    public class OptionsAutocompleteController : AutoCompleteControllerAutoMapped<PrintCalculator.Data.Models.TechProcess.Option, PrintCalculator.ViewModels.AutoComplete.Option>
    {
        public OptionsAutocompleteController(AppDBContext appDbContext, StorageService storageService, IMapper autoMapper)
            : base
            (
                (result, query) => result.Where(x => x.Title.Contains(query.Trim())),
                query => query,
                autoMapper,
                5,
                appDbContext,
                storageService
            )
        { }
    }

}
