using Microsoft.EntityFrameworkCore;
using PrintCalculator.Abstract.Data;
using PrintCalculator.Data.Models.Paper;
using PrintCalculator.Data.Models.PostPrint;
using PrintCalculator.Data.Models.Storage;
using PrintCalculator.Data.Models.TechProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data
{

    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Storage> Storages { get; set; }
        public DbSet<StorageProduct> StorageProducts { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<SubCategory> SubCategories{ get; set; }
        public DbSet<UnitMeasure> UnitMeasures{ get; set; }
        public DbSet<TechProcess> TechProcesses{ get; set; }
        public DbSet<TechProcessOption> TechProcessOptions{ get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Sector> Sectors{ get; set; }
        public DbSet<PrintType> PrintTypes { get; set; }
        public DbSet<PostPrintOperation> PostPrintOperations{ get; set; }
        public DbSet<PostPrintGroup> PostPrintGroups{ get; set; }
        public DbSet<PackagingType> PackagingTypes{ get; set; }
        public DbSet<PostPrintPrice> PostPrintPrices { get; set; }
        public DbSet<PostPrintPriceGroup> PostPrintPriceGroups { get; set; }
        public DbSet<PostPrintTarget> PostPrintTargets{ get; set; }
        public DbSet<Paper> Papers{ get; set; }
        public DbSet<PaperClass> PaperClasses { get; set; }
        public DbSet<PaperCoefficient> PaperCoefficients { get; set; }
        public DbSet<PaperDensity> PaperDensities { get; set; }
        public DbSet<PaperFormat> PaperFormats { get; set; }
        public DbSet<PaperPriceGroup> PaperPriceGroups { get; set; }
        public DbSet<PaperSize> PaperSizes { get; set; }
        public DbSet<PaperType> PaperTypes { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public void Seed()
        {
            var storages = new[]
            {
                new Storage
                {
                    Id = Guid.NewGuid(),
                    Title = "TestStorage1",
                    Description = "qwerty"
                },

                new Storage
                {
                    Id = Guid.NewGuid(),
                    Title = "TestStorage2",
                    Description = "qwerty"
                },

                new Storage
                {
                    Id = Guid.NewGuid(),
                    Title = "TestStorage3",
                    Description = "qwerty"
                },

                new Storage
                {
                    Id = Guid.NewGuid(),
                    Title = "TestStorage4",
                    Description = "qwerty"
                },

                new Storage
                {
                    Id = Guid.NewGuid(),
                    Title = "TestStorage5",
                    Description = "qwerty"
                },
            };

            var unitMeasures = new[]
          {
                new UnitMeasure
                {
                    Id = Guid.NewGuid(),
                    Title = "Measure1",
                },

                new UnitMeasure
                {
                    Id = Guid.NewGuid(),
                    Title = "Measure2",
                },

                new UnitMeasure
                {
                    Id = Guid.NewGuid(),
                    Title = "Measure3",
                },
            };

            var categories = new[]
          {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Title = "Category1",
                },

                new Category
                {
                Id = Guid.NewGuid(),
                Title = "Category2",
                },

                new Category
                {
                Id = Guid.NewGuid(),
                Title = "Category1",
                },

                new Category
                {
                Id = Guid.NewGuid(),
                Title = "Category3",
                },

                new Category
                {
                Id = Guid.NewGuid(),
                Title = "Category4",
                },
            };

            var subCategories = new[]
           {
                new SubCategory
                {
                    Id = Guid.NewGuid(),
                    Title = "SubCategory1",
                    CategoryId = categories[0].Id,
                },

                new SubCategory
                {
                    Id = Guid.NewGuid(),
                    Title = "SubCategory2",
                    CategoryId = categories[1].Id,
                },

                new SubCategory
                {
                    Id = Guid.NewGuid(),
                    Title = "SubCategory3",
                    CategoryId = categories[2].Id,
                },

                new SubCategory
                {
                    Id = Guid.NewGuid(),
                    Title = "SubCategory4",
                    CategoryId = categories[3].Id,
                },

                new SubCategory
                {
                    Id = Guid.NewGuid(),
                    Title = "SubCategory2",
                    CategoryId = categories[3].Id,
                },

                new SubCategory
                {
                    Id = Guid.NewGuid(),
                    Title = "SubCategory3",
                    CategoryId = categories[1].Id,
                },

                new SubCategory
                {
                    Id = Guid.NewGuid(),
                    Title = "SubCategory2",
                    CategoryId = categories[0].Id,
                },

                new SubCategory
                {
                    Id = Guid.NewGuid(),
                    Title = "SubCategory4",
                    CategoryId = categories[2].Id,
                },
            };

            var storageProducts = new[]
            {
                new StorageProduct
                {
                    Id = Guid.NewGuid(),
                    Title = "StorageProductPaper1",
                    AmountPackages = 3,
                    Amount = 30,
                    UnitMeasureId = unitMeasures[0].Id,
                    SubCategoryId = subCategories[0].Id,
                    StorageId = storages[0].Id,
                },

                new StorageProduct
                {
                    Id = Guid.NewGuid(),
                    Title = "StorageProductPaper2",
                    AmountPackages = 3,
                    Amount = 30,
                    UnitMeasureId = unitMeasures[0].Id,
                    SubCategoryId = subCategories[1].Id,
                    StorageId = storages[0].Id,
                },

                new StorageProduct
                {
                    Id = Guid.NewGuid(),
                    Title = "StorageProductPaper3",
                    AmountPackages = 3,
                    Amount = 30,
                    UnitMeasureId = unitMeasures[1].Id,
                    SubCategoryId = subCategories[2].Id,
                    StorageId = storages[0].Id,
                },

                new StorageProduct
                {
                    Id = Guid.NewGuid(),
                    Title = "StorageProductPaper4",
                    AmountPackages = 3,
                    Amount = 30,
                    UnitMeasureId = unitMeasures[1].Id,
                    SubCategoryId = subCategories[1].Id,
                    StorageId = storages[0].Id,
                },

                new StorageProduct
                {
                    Id = Guid.NewGuid(),
                    Title = "StorageProductPaper5",
                    AmountPackages = 3,
                    Amount = 30,
                    UnitMeasureId = unitMeasures[2].Id,
                    SubCategoryId = subCategories[1].Id,
                    StorageId = storages[1].Id,
                },

                new StorageProduct
                {
                    Id = Guid.NewGuid(),
                    Title = "StorageProductPaper6",
                    AmountPackages = 3,
                    Amount = 30,
                    UnitMeasureId = unitMeasures[2].Id,
                    SubCategoryId = subCategories[3].Id,
                    StorageId = storages[2].Id,
                },

                new StorageProduct
                {
                    Id = Guid.NewGuid(),
                    Title = "StorageProductPaper7",
                    AmountPackages = 3,
                    Amount = 30,
                    UnitMeasureId = unitMeasures[2].Id,
                    SubCategoryId = subCategories[3].Id,
                    StorageId = storages[2].Id,
                },

                new StorageProduct
                {
                    Id = Guid.NewGuid(),
                    Title = "StorageProductPaper8",
                    AmountPackages = 3,
                    Amount = 30,
                    UnitMeasureId = unitMeasures[3].Id,
                    SubCategoryId = subCategories[1].Id,
                    StorageId = storages[3].Id,
                },

                new StorageProduct
                {
                    Id = Guid.NewGuid(),
                    Title = "StorageProductPaper1",
                    AmountPackages = 3,
                    Amount = 30,
                    UnitMeasureId = unitMeasures[3].Id,
                    SubCategoryId = subCategories[0].Id,
                    StorageId = storages[4].Id,
                },
            };


            var paperClasses = new[]
              {
                new PaperClass
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperClass1"
                },

                new PaperClass
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperClass2"
                },

                new PaperClass
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperClass3"
                },
            };

            

            var paperDensities = new[]
           {
                new PaperDensity
                {
                    Id = Guid.NewGuid(),
                    Density = "Density1"
                },

                new PaperDensity
                {
                    Id = Guid.NewGuid(),
                    Density = "Density2"
                },

                new PaperDensity
                {
                    Id = Guid.NewGuid(),
                    Density = "Density3"
                },
            };

            var paperSizes = new[]
             {
                new PaperSize
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperSize1",
                    Width = 100,
                    Height = 100
                },

                new PaperSize
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperSize2",
                    Width = 150,
                    Height = 150
                },

                new PaperSize
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperSize3",
                    Width = 250,
                    Height = 250
                },

                new PaperSize
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperSize4",
                    Width = 100,
                    Height = 200
                },

                 new PaperSize
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperSize5",
                    Width = 250,
                    Height = 500
                },
            };

            var paperFormats = new[]
           {
                new PaperFormat
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperFormat1",
                    PaperSizeId = paperSizes[0].Id    
                },

                new PaperFormat
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperFormat2",
                    PaperSizeId = paperSizes[1].Id
                },

                new PaperFormat
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperFormat3",
                    PaperSizeId = paperSizes[2].Id
                },

                new PaperFormat
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperFormat4",
                    PaperSizeId = paperSizes[3].Id
                },
            };

            var paperPriceGroups = new[]
           {
                new PaperPriceGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperPriceGroup1",
                    PricePerKg = 120,
                    MarkupMaxAmount = 2,
                    MarkupMaxCoefficient = 2,
                    MarkupMinAmount = 4,
                    MarkupMinCoefficient = 4,
                    PaperClassId = paperClasses[0].Id
                },

                new PaperPriceGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperPriceGroup2",
                    PricePerKg = 220,
                    MarkupMaxAmount = 5,
                    MarkupMaxCoefficient = 1,
                    MarkupMinAmount = 3,
                    MarkupMinCoefficient = 2,
                    PaperClassId = paperClasses[1].Id
                },

                new PaperPriceGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperPriceGroup3",
                    PricePerKg = 420,
                    MarkupMaxAmount = 10,
                    MarkupMaxCoefficient = 3,
                    MarkupMinAmount = 5,
                    MarkupMinCoefficient = 4,
                    PaperClassId = paperClasses[2].Id
                },

                new PaperPriceGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperPriceGroup4",
                    PricePerKg = 800,
                    MarkupMaxAmount = 15,
                    MarkupMaxCoefficient = 5,
                    MarkupMinAmount = 3,
                    MarkupMinCoefficient = 10,
                    PaperClassId = paperClasses[0].Id
                },
            };

            var paperTypes = new[]
            {
                new PaperType
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperType1",
                    Width = 100,
                    OneSided = true,
                    MinMarkUpPurchasePrice = 10 ,
                    MarkupMaxAmount = 15,
                    MarkupMaxAmountCoefficient = 17,
                    MarkupMinAmount = 5,
                    MarkupMinAmountCoefficient =4 ,
                    PaperDensityId = paperDensities[0].Id,
                    PaperClassId = paperClasses[0].Id,
                    PaperPriceGroupId = paperPriceGroups[0].Id,
                },

                new PaperType
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperType2",
                    Width = 300,
                    OneSided = true,
                    MinMarkUpPurchasePrice = 12 ,
                    MarkupMaxAmount = 11,
                    MarkupMaxAmountCoefficient = 10,
                    MarkupMinAmount = 7,
                    MarkupMinAmountCoefficient =3 ,
                    PaperDensityId = paperDensities[1].Id,
                    PaperClassId = paperClasses[2].Id,
                    PaperPriceGroupId = paperPriceGroups[2].Id,
                },

                new PaperType
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperType3",
                    Width = 250,
                    OneSided = false,
                    MinMarkUpPurchasePrice = 13 ,
                    MarkupMaxAmount = 5,
                    MarkupMaxAmountCoefficient = 7,
                    MarkupMinAmount = 1,
                    MarkupMinAmountCoefficient =2 ,
                    PaperDensityId = paperDensities[1].Id,
                    PaperClassId = paperClasses[1].Id,
                    PaperPriceGroupId = paperPriceGroups[0].Id,
                },

                new PaperType
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperType4",
                    Width = 500,
                    OneSided = false,
                    MinMarkUpPurchasePrice = 14 ,
                    MarkupMaxAmount = 3,
                    MarkupMaxAmountCoefficient = 1,
                    MarkupMinAmount = 1,
                    MarkupMinAmountCoefficient =2 ,
                    PaperDensityId = paperDensities[1].Id,
                    PaperClassId = paperClasses[2].Id,
                    PaperPriceGroupId = paperPriceGroups[2].Id,
                },
            };

            var papers = new[]
     {
                new Paper
                {
                    Id = Guid.NewGuid(),
                    Title = "Paper1",
                    TitleOnStorage = storageProducts[0].Title,
                    Price = 100,
                    MarkupMaxAmount = 10,
                    MarkupMaxAmountCoefficient = 2,
                    MarkupMinAmount = 4,
                    MarkupMinAmountCoefficient = 3,
                    PriceKg = 200,
                    SuspendedSupply = true,
                    PaperTypeId = paperTypes[0].Id,
                    PaperPriceGroupId = paperPriceGroups[0].Id,
                    PaperDensityId = paperDensities[0].Id,
                    PaperSizeId = paperSizes[0].Id,

                },

                new Paper
                {
                    Id = Guid.NewGuid(),
                    Title = "Paper2",
                    TitleOnStorage = storageProducts[1].Title,
                    Price = 200,
                    MarkupMaxAmount = 11,
                    MarkupMaxAmountCoefficient = 5,
                    MarkupMinAmount = 2,
                    MarkupMinAmountCoefficient = 2,
                    PriceKg = 500,
                    SuspendedSupply = true,
                    PaperTypeId = paperTypes[2].Id,
                    PaperPriceGroupId = paperPriceGroups[2].Id,
                    PaperDensityId = paperDensities[2].Id,
                    PaperSizeId = paperSizes[2].Id,

                },

                new Paper
                {
                    Id = Guid.NewGuid(),
                    Title = "Paper3",
                    TitleOnStorage = storageProducts[2].Title,
                    Price = 140,
                    MarkupMaxAmount = 11,
                    MarkupMaxAmountCoefficient = 2,
                    MarkupMinAmount = 2,
                    MarkupMinAmountCoefficient = 1,
                    PriceKg = 320,
                    SuspendedSupply = true,
                    PaperTypeId = paperTypes[1].Id,
                    PaperPriceGroupId = paperPriceGroups[0].Id,
                    PaperDensityId = paperDensities[1].Id,
                    PaperSizeId = paperSizes[1].Id,

                },

                new Paper
                {
                    Id = Guid.NewGuid(),
                    Title = "Paper4",
                    TitleOnStorage = storageProducts[3].Title,
                    Price = 300,
                    MarkupMaxAmount = 6,
                    MarkupMaxAmountCoefficient = 1,
                    MarkupMinAmount = 6,
                    MarkupMinAmountCoefficient = 3,
                    PriceKg = 400,
                    SuspendedSupply = false,
                    PaperTypeId = paperTypes[2].Id,
                    PaperPriceGroupId = paperPriceGroups[2].Id,
                    PaperDensityId = paperDensities[2].Id,
                    PaperSizeId = paperSizes[2].Id,

                },

                new Paper
                {
                    Id = Guid.NewGuid(),
                    Title = "Paper5",
                    TitleOnStorage = storageProducts[2].Title,
                    Price = 240,
                    MarkupMaxAmount = 6,
                    MarkupMaxAmountCoefficient = 1,
                    MarkupMinAmount = 2,
                    MarkupMinAmountCoefficient = 6,
                    PriceKg = 730,
                    SuspendedSupply = false,
                    PaperTypeId = paperTypes[1].Id,
                    PaperPriceGroupId = paperPriceGroups[0].Id,
                    PaperDensityId = paperDensities[1].Id,
                    PaperSizeId = paperSizes[0].Id,

                },

                new Paper
                {
                    Id = Guid.NewGuid(),
                    Title = "Paper6",
                    TitleOnStorage = storageProducts[3].Title,
                    Price = 190,
                    MarkupMaxAmount = 9,
                    MarkupMaxAmountCoefficient = 4,
                    MarkupMinAmount = 5,
                    MarkupMinAmountCoefficient = 3,
                    PriceKg = 560,
                    SuspendedSupply = true,
                    PaperTypeId = paperTypes[2].Id,
                    PaperPriceGroupId = paperPriceGroups[0].Id,
                    PaperDensityId = paperDensities[2].Id,
                    PaperSizeId = paperSizes[1].Id,

                },

                new Paper
                {
                    Id = Guid.NewGuid(),
                    Title = "Paper7",
                    TitleOnStorage = storageProducts[4].Title,
                    Price = 450,
                    MarkupMaxAmount = 3,
                    MarkupMaxAmountCoefficient = 1,
                    MarkupMinAmount = 4,
                    MarkupMinAmountCoefficient = 3,
                    PriceKg = 1200,
                    SuspendedSupply = true,
                    PaperTypeId = paperTypes[1].Id,
                    PaperPriceGroupId = paperPriceGroups[2].Id,
                    PaperDensityId = paperDensities[0].Id,
                    PaperSizeId = paperSizes[1].Id,

                },

                new Paper
                {
                    Id = Guid.NewGuid(),
                    Title = "Paper8",
                    TitleOnStorage = storageProducts[5].Title,
                    Price = 350,
                    MarkupMaxAmount = 3,
                    MarkupMaxAmountCoefficient = 1,
                    MarkupMinAmount = 5,
                    MarkupMinAmountCoefficient = 3,
                    PriceKg = 1000,
                    SuspendedSupply = true,
                    PaperTypeId = paperTypes[1].Id,
                    PaperPriceGroupId = paperPriceGroups[2].Id,
                    PaperDensityId = paperDensities[1].Id,
                    PaperSizeId = paperSizes[1].Id,

                },

                new Paper
                {
                    Id = Guid.NewGuid(),
                    Title = "Paper9",
                    TitleOnStorage = storageProducts[6].Title,
                    Price = 400,
                    MarkupMaxAmount = 7,
                    MarkupMaxAmountCoefficient = 4,
                    MarkupMinAmount = 4,
                    MarkupMinAmountCoefficient = 2,
                    PriceKg = 940,
                    SuspendedSupply = true,
                    PaperTypeId = paperTypes[2].Id,
                    PaperPriceGroupId = paperPriceGroups[0].Id,
                    PaperDensityId = paperDensities[1].Id,
                    PaperSizeId = paperSizes[2].Id,

                },
            };

            

            var packagingTypes = new[]
            {
                new PackagingType
                {
                    Id = Guid.NewGuid(),
                    Title = "PackagingType1",
                    PreparationPrice = 10,
                    PerPackPrice = 3,
                    PreparationCostPrice = 7,
                    PerPackCostPrice = 3,
                    PreparationTime = 11,
                    PerPackTime = 3,
                    
                },

                new PackagingType
                {
                    Id = Guid.NewGuid(),
                    Title = "PackagingType2",
                    PreparationPrice = 15,
                    PerPackPrice = 5,
                    PreparationCostPrice = 8,
                    PerPackCostPrice = 4,
                    PreparationTime = 10,
                    PerPackTime = 2,

                },

                new PackagingType
                {
                    Id = Guid.NewGuid(),
                    Title = "PackagingType3",
                    PreparationPrice = 12,
                    PerPackPrice = 4,
                    PreparationCostPrice = 3,
                    PerPackCostPrice = 2,
                    PreparationTime = 5,
                    PerPackTime = 4,

                },


            };

            var postPrintGroups = new[]
           {
                new PostPrintGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintGroup1",
                    
                },

                new PostPrintGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintGroup2",

                },

                new PostPrintGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintGroup3",

                },
            };

            var postPrintPriceGroups = new[]
          {
                new PostPrintPriceGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintPriceGroup1",

                },

                new PostPrintPriceGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintPriceGroup2",

                },

                new PostPrintPriceGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintPriceGroup3",

                },
            };

            var postPrintTargets = new[]
           {
                new PostPrintTarget
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintTarget1",

                },

                new PostPrintTarget
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintTarget2",

                },

                new PostPrintTarget
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintTarget3",

                },
            };

            var sectors = new[]
           {
                new Sector
                {
                    Id = Guid.NewGuid(),
                    Title = "Sector1",
                    
                },

                new Sector
                {
                    Id = Guid.NewGuid(),
                    Title = "Sector2",

                },

                new Sector
                {
                    Id = Guid.NewGuid(),
                    Title = "Sector3",

                },
            };

            var postPrintPrices = new[]
            {
                new PostPrintPrice
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintPrice1",
                    MainPreparation = 10,
                    AdditionalPreparation = 15,
                    MainPerUnitMax = 15,
                    AdditionalPerUnitMax = 15,
                    MainPerUnitMin = 15,
                    AdditionalPerUnitMin = 15,
                    MainAmountForMaxPrice = 15,
                    AdditionalAmountForMaxPrice = 15,
                    MainAmountForMinPrice  = 15,
                    AdditionalAmountForMinPrice = 15,
                    MultiplierPreparation = 15,
                    PreparationCostPrice = 15,
                    ForUnitCostPrice = 15,
                    MeasureUnit = "MeasureUnit1",
                    FittingPerKPLpsc = 15,
                    FittingPerOrderpsc = 15,
                    FittingFromEditionCoefficient = 15,
                    Weight = 150,
                    Consumable = true,
                    AppliesTo = 0,
                    DestroySheet = true,
                    OneSide = true ,
                    RequirePrepress = true,
                    SheetWidth = 150,
                    SheetHeight = 150,
                    IndentLong = 10,
                    IndentShort = 10,
                    PostPrintPriceGroupId = postPrintPriceGroups[0].Id,
                    MainPostPrintTargetId = postPrintTargets[0].Id,
                    AdditionalPostPrintTargetId = postPrintTargets[1].Id,
                    PaperFormatId = paperFormats[0].Id,

                },

                new PostPrintPrice
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintPrice2",
                    MainPreparation = 15,
                    AdditionalPreparation = 10,
                    MainPerUnitMax = 25,
                    AdditionalPerUnitMax = 25,
                    MainPerUnitMin = 25,
                    AdditionalPerUnitMin = 25,
                    MainAmountForMaxPrice = 25,
                    AdditionalAmountForMaxPrice = 25,
                    MainAmountForMinPrice  = 25,
                    AdditionalAmountForMinPrice = 25,
                    MultiplierPreparation = 25,
                    PreparationCostPrice = 25,
                    ForUnitCostPrice = 25,
                    MeasureUnit = "MeasureUnit2",
                    FittingPerKPLpsc = 25,
                    FittingPerOrderpsc = 25,
                    FittingFromEditionCoefficient = 25,
                    Weight = 300,
                    Consumable = true,
                    AppliesTo = 0,
                    DestroySheet = false,
                    OneSide = true ,
                    RequirePrepress = false,
                    SheetWidth = 250,
                    SheetHeight = 100,
                    IndentLong = 15,
                    IndentShort = 10,
                    PostPrintPriceGroupId = postPrintPriceGroups[1].Id,
                    MainPostPrintTargetId = postPrintTargets[2].Id,
                    AdditionalPostPrintTargetId = postPrintTargets[2].Id,
                    PaperFormatId = paperFormats[1].Id,

                },

                new PostPrintPrice
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintPrice3",
                    MainPreparation = 30,
                    AdditionalPreparation = 20,
                    MainPerUnitMax = 30,
                    AdditionalPerUnitMax = 30,
                    MainPerUnitMin = 30,
                    AdditionalPerUnitMin = 30,
                    MainAmountForMaxPrice = 30,
                    AdditionalAmountForMaxPrice = 30,
                    MainAmountForMinPrice  = 30,
                    AdditionalAmountForMinPrice = 30,
                    MultiplierPreparation = 30,
                    PreparationCostPrice = 30,
                    ForUnitCostPrice = 30,
                    MeasureUnit = "MeasureUnit1",
                    FittingPerKPLpsc = 30,
                    FittingPerOrderpsc = 30,
                    FittingFromEditionCoefficient = 30,
                    Weight = 400,
                    Consumable = false,
                    AppliesTo = 0,
                    DestroySheet = true,
                    OneSide = false ,
                    RequirePrepress = true,
                    SheetWidth = 120,
                    SheetHeight = 200,
                    IndentLong = 10,
                    IndentShort = 10,
                    PostPrintPriceGroupId = postPrintPriceGroups[2].Id,
                    MainPostPrintTargetId = postPrintTargets[1].Id,
                    AdditionalPostPrintTargetId = postPrintTargets[2].Id,
                    PaperFormatId = paperFormats[2].Id,

                },

                new PostPrintPrice
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintPrice4",
                    MainPreparation = 5,
                    AdditionalPreparation = 30,
                    MainPerUnitMax = 20,
                    AdditionalPerUnitMax = 20,
                    MainPerUnitMin = 15,
                    AdditionalPerUnitMin = 20,
                    MainAmountForMaxPrice = 15,
                    AdditionalAmountForMaxPrice = 20,
                    MainAmountForMinPrice  = 15,
                    AdditionalAmountForMinPrice = 20,
                    MultiplierPreparation = 15,
                    PreparationCostPrice = 20,
                    ForUnitCostPrice = 15,
                    MeasureUnit = "MeasureUnit2",
                    FittingPerKPLpsc = 15,
                    FittingPerOrderpsc = 20,
                    FittingFromEditionCoefficient = 15,
                    Weight = 500,
                    Consumable = true,
                    AppliesTo = 0,
                    DestroySheet = false,
                    OneSide = true ,
                    RequirePrepress = true,
                    SheetWidth = 400,
                    SheetHeight = 300,
                    IndentLong = 15,
                    IndentShort = 20,
                    PostPrintPriceGroupId = postPrintPriceGroups[2].Id,
                    MainPostPrintTargetId = postPrintTargets[2].Id,
                    AdditionalPostPrintTargetId = postPrintTargets[1].Id,
                    PaperFormatId = paperFormats[1].Id,

                },
            };

            var postPrintOperations = new[]
           {
                new PostPrintOperation
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintOperation1",
                    MeasureUnit = "MeasureUntit1",
                    ConsumesPaperMaterial = true,
                    WaitingTime = 50,
                    PreparationTime = 120,
                    OperationTime = 150,
                    PostPrintGroupId = postPrintGroups[0].Id,
                    PostPrintTargetId = postPrintTargets[0].Id,
                    SectorId = sectors[0].Id,

                },

                new PostPrintOperation
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintOperation2",
                    MeasureUnit = "MeasureUntit1",
                    ConsumesPaperMaterial = true,
                    WaitingTime = 50,
                    PreparationTime = 120,
                    OperationTime = 50,
                    PostPrintGroupId = postPrintGroups[0].Id,
                    PostPrintTargetId = postPrintTargets[1].Id,
                    SectorId = sectors[0].Id,

                },

                new PostPrintOperation
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintOperation3",
                    MeasureUnit = "MeasureUntit2",
                    ConsumesPaperMaterial = true,
                    WaitingTime = 50,
                    PreparationTime = 100,
                    OperationTime = 200,
                    PostPrintGroupId = postPrintGroups[1].Id,
                    PostPrintTargetId = postPrintTargets[1].Id,
                    SectorId = sectors[2].Id,

                },

                new PostPrintOperation
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintOperation4",
                    MeasureUnit = "MeasureUntit3",
                    ConsumesPaperMaterial = true,
                    WaitingTime = 50,
                    PreparationTime = 140,
                    OperationTime = 250,
                    PostPrintGroupId = postPrintGroups[1].Id,
                    PostPrintTargetId = postPrintTargets[0].Id,
                    SectorId = sectors[2].Id,

                },

                new PostPrintOperation
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintOperation5",
                    MeasureUnit = "MeasureUntit2",
                    ConsumesPaperMaterial = false,
                    WaitingTime = 50,
                    PreparationTime = 100,
                    OperationTime = 10,
                    PostPrintGroupId = postPrintGroups[2].Id,
                    PostPrintTargetId = postPrintTargets[0].Id,
                    SectorId = sectors[0].Id,

                },

                new PostPrintOperation
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintOperation16",
                    MeasureUnit = "MeasureUntit1",
                    ConsumesPaperMaterial = true,
                    WaitingTime = 50,
                    PreparationTime = 120,
                    OperationTime = 300,
                    PostPrintGroupId = postPrintGroups[2].Id,
                    PostPrintTargetId = postPrintTargets[1].Id,
                    SectorId = sectors[1].Id,

                },

                new PostPrintOperation
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintOperation7",
                    MeasureUnit = "MeasureUntit2",
                    ConsumesPaperMaterial = true,
                    WaitingTime = 50,
                    PreparationTime = 120,
                    OperationTime = 310,
                    PostPrintGroupId = postPrintGroups[2].Id,
                    PostPrintTargetId = postPrintTargets[2].Id,
                    SectorId = sectors[0].Id,

                },

                new PostPrintOperation
                {
                    Id = Guid.NewGuid(),
                    Title = "PostPrintOperation8",
                    MeasureUnit = "MeasureUntit3",
                    ConsumesPaperMaterial = false,
                    WaitingTime = 50,
                    PreparationTime = 120,
                    OperationTime = 500,
                    PostPrintGroupId = postPrintGroups[1].Id,
                    PostPrintTargetId = postPrintTargets[2].Id,
                    SectorId = sectors[1].Id,

                },
            };
     

            var printTypes = new[]
           {
                new PrintType
                {
                    Id = Guid.NewGuid(),
                    Title = "PrintType1",
                    
                },

                new PrintType
                {
                    Id = Guid.NewGuid(),
                    Title = "PrintType2",

                },

                new PrintType
                {
                    Id = Guid.NewGuid(),
                    Title = "PrintType3",

                },
            };

            var options = new[]
           {
                new Option
                {
                    Id = Guid.NewGuid(),
                    Title = "Option1",
                    Description = "Description1",
                },

                new Option
                {
                    Id = Guid.NewGuid(),
                    Title = "Option2",
                    Description = "Description2",
                },

                new Option
                {
                    Id = Guid.NewGuid(),
                    Title = "Option3",
                    Description = "Description3",
                },

                new Option
                {
                    Id = Guid.NewGuid(),
                    Title = "Option4",
                    Description = "Description4",
                },
            };

            var techProcesses = new[]
            {
                new TechProcess
                {
                    Id = Guid.NewGuid(),
                    Title = "TechProcess1",
                    Color = 1,
                    Special = true,
                    MaxPaperWidth = 500,
                    MaxPaperHeight = 500,
                    MinPaperWidth = 100,
                    MinPaperHeight = 100,
                    BeforePrintTime = 20,
                    StartPrintTime = 50,
                    OneInstancePrintTime = 50,
                    WaitingPostPrintTime = 50,
                    DryingTime = 50,
                    CheckTime = 50 ,
                    InstallationTime = 50,
                    CostPrice = 50,
                    MaterialMarkup = 50,
                    FittingPrice = 50,
                    FittingWithoutTurnOver = 50,
                    FittingForeignerTurnOver = 50,
                    FittingKombo = 50,
                    FittingYourTurnOver = 50,
                    FormsPrice = 50,
                    PantonBatchPrice = 50,
                    LacquerPreparationPrice = 50,
                    PaperFittingFirstPrint = 50,
                    PaperFittingAdditionalPaint = 50,
                    PaperFittingPanton = 50,
                    PaperFittingFromEdition = 50,
                    CuttingCutPrice = 50,
                    PrintRunPrice = 50,
                    PrintRunLacquerPrice = 50,
                    CuttingPreparationPrice = 50,
                    ValveWidth = 50,
                    PaperTrim = 50,
                    FieldForCrosses = 50,
                    DiesWidth = 50,
                    SectionsInThePriceOfARun = 50,
                    FittingPerRunPrice = 50,
                    MinPrintPrice = 50,
                    MinPrintSheetPrice = 50,
                    IncreasedTireWear = 50,
                    PlatesCtPResource = 50,
                    CuttingWithACollarMarkUp = 50,
                    CoefficientPerTurnOver = 50,
                    CustomCutting = 50,
                    FittingYourTurnOverThroughValvePrice = 50,
                    FittingCoefficientForYourTurnOver =50 ,
                    Rewash = 50,
                    PrintTypeId = printTypes[0].Id,
                    SectorId = sectors[0].Id,
                    StorageId = storages[0].Id,
                    FormatId = paperFormats[0].Id,
                    PreferredPaperSizeId = paperSizes[0].Id,

                },

                 new TechProcess
                {
                    Id = Guid.NewGuid(),
                    Title = "TechProcess2",
                    Color = 3,
                    Special = false,
                    MaxPaperWidth = 700,
                    MaxPaperHeight = 700,
                    MinPaperWidth = 150,
                    MinPaperHeight = 150,
                    BeforePrintTime = 70,
                    StartPrintTime = 120,
                    OneInstancePrintTime = 100,
                    WaitingPostPrintTime = 100,
                    DryingTime = 100,
                    CheckTime = 100 ,
                    InstallationTime = 100,
                    CostPrice = 100,
                    MaterialMarkup = 100,
                    FittingPrice = 100,
                    FittingWithoutTurnOver = 100,
                    FittingForeignerTurnOver = 100,
                    FittingKombo = 100,
                    FittingYourTurnOver = 100,
                    FormsPrice = 100,
                    PantonBatchPrice = 100,
                    LacquerPreparationPrice = 100,
                    PaperFittingFirstPrint = 100,
                    PaperFittingAdditionalPaint = 100,
                    PaperFittingPanton = 100,
                    PaperFittingFromEdition = 100,
                    CuttingCutPrice = 100,
                    PrintRunPrice = 100,
                    PrintRunLacquerPrice = 100,
                    CuttingPreparationPrice = 100,
                    ValveWidth = 100,
                    PaperTrim = 100,
                    FieldForCrosses = 100,
                    DiesWidth = 100,
                    SectionsInThePriceOfARun = 100,
                    FittingPerRunPrice = 100,
                    MinPrintPrice = 100,
                    MinPrintSheetPrice = 100,
                    IncreasedTireWear = 100,
                    PlatesCtPResource = 100,
                    CuttingWithACollarMarkUp = 100,
                    CoefficientPerTurnOver = 100,
                    CustomCutting = 100,
                    FittingYourTurnOverThroughValvePrice = 100,
                    FittingCoefficientForYourTurnOver =100 ,
                    Rewash = 100,
                    PrintTypeId = printTypes[1].Id,
                    SectorId = sectors[1].Id,
                    StorageId = storages[0].Id,
                    FormatId = paperFormats[0].Id,
                    PreferredPaperSizeId = paperSizes[1].Id,

                },

                  new TechProcess
                {
                    Id = Guid.NewGuid(),
                    Title = "TechProcess3",
                    Color = 1,
                    Special = true,
                    MaxPaperWidth = 400,
                    MaxPaperHeight = 400,
                    MinPaperWidth = 50,
                    MinPaperHeight = 50,
                    BeforePrintTime = 50,
                    StartPrintTime = 150,
                    OneInstancePrintTime = 150,
                    WaitingPostPrintTime = 150,
                    DryingTime = 150,
                    CheckTime = 150 ,
                    InstallationTime = 150,
                    CostPrice = 150,
                    MaterialMarkup = 150,
                    FittingPrice = 150,
                    FittingWithoutTurnOver = 150,
                    FittingForeignerTurnOver = 150,
                    FittingKombo = 150,
                    FittingYourTurnOver = 150,
                    FormsPrice = 150,
                    PantonBatchPrice = 150,
                    LacquerPreparationPrice = 150,
                    PaperFittingFirstPrint = 150,
                    PaperFittingAdditionalPaint = 150,
                    PaperFittingPanton = 150,
                    PaperFittingFromEdition = 150,
                    CuttingCutPrice = 150,
                    PrintRunPrice = 150,
                    PrintRunLacquerPrice = 150,
                    CuttingPreparationPrice = 150,
                    ValveWidth = 150,
                    PaperTrim = 150,
                    FieldForCrosses = 150,
                    DiesWidth = 150,
                    SectionsInThePriceOfARun = 150,
                    FittingPerRunPrice = 150,
                    MinPrintPrice = 150,
                    MinPrintSheetPrice = 51500,
                    IncreasedTireWear = 150,
                    PlatesCtPResource = 150,
                    CuttingWithACollarMarkUp = 150,
                    CoefficientPerTurnOver = 150,
                    CustomCutting = 150,
                    FittingYourTurnOverThroughValvePrice = 150,
                    FittingCoefficientForYourTurnOver =150 ,
                    Rewash = 50,
                    PrintTypeId = printTypes[2].Id,
                    SectorId = sectors[2].Id,
                    StorageId = storages[1].Id,
                    FormatId = paperFormats[2].Id,
                    PreferredPaperSizeId = paperSizes[1].Id,

                },
            };


            var techProcessOptions = new[]
            {
                new TechProcessOption
                {
                    Id = Guid.NewGuid(),
                    TechProcessId = techProcesses[0].Id,
                    OptionId = options[0].Id,
                },

                new TechProcessOption
                {
                    Id = Guid.NewGuid(),
                    TechProcessId = techProcesses[1].Id,
                    OptionId = options[0].Id,
                },

                new TechProcessOption
                {
                    Id = Guid.NewGuid(),
                    TechProcessId = techProcesses[0].Id,
                    OptionId = options[1].Id,
                },

                new TechProcessOption
                {
                    Id = Guid.NewGuid(),
                    TechProcessId = techProcesses[1].Id,
                    OptionId = options[1].Id,
                },

                new TechProcessOption
                {
                    Id = Guid.NewGuid(),
                    TechProcessId = techProcesses[0].Id,
                    OptionId = options[2].Id,
                },

                new TechProcessOption
                {
                    Id = Guid.NewGuid(),
                    TechProcessId = techProcesses[1].Id,
                    OptionId = options[3].Id,
                },

                new TechProcessOption
                {
                    Id = Guid.NewGuid(),
                    TechProcessId = techProcesses[0].Id,
                    OptionId = options[2].Id,
                },
            };

            var paperCoefficients = new[]
            {
                new PaperCoefficient
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperCoefficient1",
                    Coefficient = 2.5f,
                    PaperDensityId = paperDensities[0].Id,
                    TechProcessId = techProcesses[0].Id,

                },

                new PaperCoefficient
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperCoefficient2",
                    Coefficient = 2,
                    PaperDensityId = paperDensities[2].Id,
                    TechProcessId = techProcesses[0].Id,

                },

                new PaperCoefficient
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperCoefficient3",
                    Coefficient = 3,
                    PaperDensityId = paperDensities[1].Id,
                    TechProcessId = techProcesses[1].Id,

                },

                new PaperCoefficient
                {
                    Id = Guid.NewGuid(),
                    Title = "PaperCoefficient4",
                    Coefficient = 5,
                    PaperDensityId = paperDensities[0].Id,
                    TechProcessId = techProcesses[2].Id,

                },
            };

            var users = new[]
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Login = "Dev",
                    Password = "123",
                    FIO = "Firo Biro Diro",
                    JobTitle = "Developer",
                    Role = Role.MainAdmin
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    Login = "Admin",
                    Password = "123",
                    FIO = "Pablo Picaso R",
                    JobTitle = "Admin",
                    Role = Role.Admin
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    Login = "Administrator",
                    Password = "111",
                    FIO = "Sveta Popova",
                    JobTitle = "Administrator",
                    Role = Role.Administrator
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    Login = "Worker1",
                    Password = "111",
                    FIO = "Vasya Petechkin",
                    JobTitle = "PrintWorker1",
                    Role = Role.Worker
                },

                new User
                {
                    Id = Guid.NewGuid(),
                    Login = "Worker2",
                    Password = "222",
                    FIO = "Petya Vasiliev",
                    JobTitle = "PrintWorker2",
                    Role = Role.Worker
                },
            };

            AddRange(storages);
            AddRange(unitMeasures);
            AddRange(categories);
            AddRange(subCategories);
            AddRange(storageProducts);

            AddRange(sectors);
            AddRange(printTypes);        
            AddRange(options);
            AddRange(techProcesses);
            AddRange(techProcessOptions);
            

            AddRange(packagingTypes);
            AddRange(postPrintTargets);
            AddRange(postPrintPriceGroups);
            AddRange(postPrintGroups);
            AddRange(postPrintPrices);
            AddRange(postPrintOperations);

            AddRange(paperDensities);
            AddRange(paperSizes);
            AddRange(paperTypes);
            AddRange(paperClasses);
            AddRange(paperFormats);
            AddRange(paperPriceGroups);
            AddRange(paperCoefficients);     
            AddRange(papers);

            AddRange(users);

            SaveChanges();
        }
    }
}
