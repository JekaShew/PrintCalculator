using AutoMapper;

namespace PrintCalculator.Services
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Data.Models.Storage.Storage, ViewModels.Data.Storage.Storage>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Storage.Storage, Data.Models.Storage.Storage>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.Storage.Category, ViewModels.Data.Storage.Category>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Storage.Category, Data.Models.Storage.Category>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.Storage.SubCategory, ViewModels.Data.Storage.SubCategory>()
                .ForMember(d => d.Category, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Storage.SubCategory, Data.Models.Storage.SubCategory>()
                .ForMember(d => d.Category, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.Storage.UnitMeasure, ViewModels.Data.Storage.UnitMeasure>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Storage.UnitMeasure, Data.Models.Storage.UnitMeasure>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.Storage.StorageProduct, ViewModels.Data.Storage.StorageProduct>()
                .ForMember(d => d.UnitMeasure, (options)  => options.Ignore())
                .ForMember(d => d.SubCategory, (options)  => options.Ignore())
                .ForMember(d => d.Storage, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Storage.StorageProduct, Data.Models.Storage.StorageProduct>()
                .ForMember(d => d.UnitMeasure, (options)  => options.Ignore())
                .ForMember(d => d.SubCategory, (options)  => options.Ignore())
                .ForMember(d => d.Storage, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());


            CreateMap<Data.Models.Storage.Storage, ViewModels.Table.Storage.Storage>().ReverseMap();
            CreateMap<Data.Models.Storage.Category, ViewModels.Table.Storage.Category>().ReverseMap();
            CreateMap<Data.Models.Storage.SubCategory, ViewModels.Table.Storage.SubCategory>().ReverseMap();
            CreateMap<Data.Models.Storage.UnitMeasure, ViewModels.Table.Storage.UnitMeasure>().ReverseMap();
            CreateMap<Data.Models.Storage.StorageProduct, ViewModels.Table.Storage.StorageProduct>().ReverseMap();



            CreateMap<Data.Models.TechProcess.Option, ViewModels.Data.TechProcess.Option>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.TechProcess.Option, Data.Models.TechProcess.Option>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.TechProcess.PrintType, ViewModels.Data.TechProcess.PrintType>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.TechProcess.PrintType, Data.Models.TechProcess.PrintType>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.TechProcess.Sector, ViewModels.Data.TechProcess.Sector>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.TechProcess.Sector, Data.Models.TechProcess.Sector>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.TechProcess.TechProcessOption, ViewModels.Data.TechProcess.TechProcessOption>()
                .ForMember(d => d.TechProcess, (options)  => options.Ignore())
                .ForMember(d => d.Option, (options)  => options.Ignore())   
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.TechProcess.TechProcessOption, Data.Models.TechProcess.TechProcessOption>()
                .ForMember(d => d.TechProcess, (options) => options.Ignore())
                .ForMember(d => d.Option, (options) => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.TechProcess.TechProcess, ViewModels.Data.TechProcess.TechProcess>()
                .ForMember(d => d.PrintType, (options) => options.Ignore())
                .ForMember(d => d.Sector, (options) => options.Ignore())
                .ForMember(d => d.Storage, (options) => options.Ignore())
                .ForMember(d => d.PaperFormat, (options) => options.Ignore())
                .ForMember(d => d.PaperSize, (options) => options.Ignore())
                .ForMember(d => d.TechProcessOptions, (options) => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.TechProcess.TechProcess, Data.Models.TechProcess.TechProcess>()
                .ForMember(d => d.PrintType, (options) => options.Ignore())
                .ForMember(d => d.Sector, (options) => options.Ignore())
                .ForMember(d => d.Storage, (options) => options.Ignore())
                .ForMember(d => d.PaperFormat, (options) => options.Ignore())
                .ForMember(d => d.PaperSize, (options) => options.Ignore())
                .ForMember(d => d.TechProcessOptions, (options) => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());


            CreateMap<Data.Models.TechProcess.Option, ViewModels.Table.TechProcess.Option>().ReverseMap();
            CreateMap<Data.Models.TechProcess.PrintType, ViewModels.Table.TechProcess.PrintType>().ReverseMap();
            CreateMap<Data.Models.TechProcess.Sector, ViewModels.Table.TechProcess.Sector>().ReverseMap();
            CreateMap<Data.Models.TechProcess.TechProcessOption, ViewModels.Table.TechProcess.TechProcessOption>().ReverseMap();
            CreateMap<Data.Models.TechProcess.TechProcess, ViewModels.Table.TechProcess.TechProcess>().ReverseMap();



            CreateMap<Data.Models.PostPrint.PackagingType, ViewModels.Data.PostPrint.PackagingType>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.PostPrint.PackagingType, Data.Models.PostPrint.PackagingType>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.PostPrint.PostPrintGroup, ViewModels.Data.PostPrint.PostPrintGroup>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.PostPrint.PostPrintGroup, Data.Models.PostPrint.PostPrintGroup>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.PostPrint.PostPrintPriceGroup, ViewModels.Data.PostPrint.PostPrintPriceGroup>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.PostPrint.PostPrintPriceGroup, Data.Models.PostPrint.PostPrintPriceGroup>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.PostPrint.PostPrintTarget, ViewModels.Data.PostPrint.PostPrintTarget>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.PostPrint.PostPrintTarget, Data.Models.PostPrint.PostPrintTarget>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.PostPrint.PostPrintOperation, ViewModels.Data.PostPrint.PostPrintOperation>()
                .ForMember(d => d.PostPrintGroup, (options)  => options.Ignore())
                .ForMember(d => d.PostPrintTarget, (options)  => options.Ignore())
                .ForMember(d => d.Sector, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.PostPrint.PostPrintOperation, Data.Models.PostPrint.PostPrintOperation>()
                .ForMember(d => d.PostPrintGroup, (options)  => options.Ignore())
                .ForMember(d => d.PostPrintTarget, (options)  => options.Ignore())
                .ForMember(d => d.Sector, (options)  => options.Ignore()) 
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.PostPrint.PostPrintPrice, ViewModels.Data.PostPrint.PostPrintPrice>()
                .ForMember(d => d.PostPrintPriceGroup, (options)  => options.Ignore()) 
                .ForMember(d => d.MainPostPrintTarget, (options)  => options.Ignore()) 
                .ForMember(d => d.AdditionalPostPrintTarget, (options)  => options.Ignore()) 
                .ForMember(d => d.PaperFormat, (options)  => options.Ignore()) 
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.PostPrint.PostPrintPrice, Data.Models.PostPrint.PostPrintPrice>()
                .ForMember(d => d.PostPrintPriceGroup, (options)  => options.Ignore()) 
                .ForMember(d => d.MainPostPrintTarget, (options)  => options.Ignore()) 
                .ForMember(d => d.AdditionalPostPrintTarget, (options)  => options.Ignore()) 
                .ForMember(d => d.PaperFormat, (options)  => options.Ignore()) 
                .ForMember(d => d.Id, (options) => options.Ignore());


            CreateMap<Data.Models.PostPrint.PackagingType, ViewModels.Table.PostPrint.PackagingType>().ReverseMap();
            CreateMap<Data.Models.PostPrint.PostPrintGroup, ViewModels.Table.PostPrint.PostPrintGroup>().ReverseMap();
            CreateMap<Data.Models.PostPrint.PostPrintOperation, ViewModels.Table.PostPrint.PostPrintOperation>().ReverseMap();
            CreateMap<Data.Models.PostPrint.PostPrintPrice, ViewModels.Table.PostPrint.PostPrintPrice>().ReverseMap();
            CreateMap<Data.Models.PostPrint.PostPrintPriceGroup, ViewModels.Table.PostPrint.PostPrintPriceGroup>().ReverseMap();
            CreateMap<Data.Models.PostPrint.PostPrintTarget, ViewModels.Table.PostPrint.PostPrintTarget>().ReverseMap();



            CreateMap<Data.Models.Paper.Paper, ViewModels.Data.Paper.Paper>()
                .ForMember(d => d.PaperType, (options)  => options.Ignore())
                .ForMember(d => d.PaperPriceGroup, (options)  => options.Ignore())
                .ForMember(d => d.PaperDensity, (options)  => options.Ignore())
                .ForMember(d => d.PaperSize, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Paper.Paper, Data.Models.Paper.Paper>()
                .ForMember(d => d.PaperType, (options)  => options.Ignore())
                .ForMember(d => d.PaperPriceGroup, (options)  => options.Ignore())
                .ForMember(d => d.PaperDensity, (options)  => options.Ignore())
                .ForMember(d => d.PaperSize, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.Paper.PaperClass, ViewModels.Data.Paper.PaperClass>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Paper.PaperClass, Data.Models.Paper.PaperClass>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.Paper.PaperCoefficient, ViewModels.Data.Paper.PaperCoefficient>()
                .ForMember(d => d.TechProcess, (options)  => options.Ignore())
                .ForMember(d => d.PaperDensity, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());
           CreateMap<ViewModels.Data.Paper.PaperCoefficient, Data.Models.Paper.PaperCoefficient>()
                .ForMember(d => d.TechProcess, (options)  => options.Ignore())
                .ForMember(d => d.PaperDensity, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.Paper.PaperDensity, ViewModels.Data.Paper.PaperDensity>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Paper.PaperDensity, Data.Models.Paper.PaperDensity>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.Paper.PaperFormat, ViewModels.Data.Paper.PaperFormat>()
                .ForMember(d => d.PaperSize, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Paper.PaperFormat, Data.Models.Paper.PaperFormat>()
                .ForMember(d => d.PaperSize, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.Paper.PaperPriceGroup, ViewModels.Data.Paper.PaperPriceGroup>()
                .ForMember(d => d.PaperClass, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Paper.PaperPriceGroup, Data.Models.Paper.PaperPriceGroup>()
                .ForMember(d => d.PaperClass, (options) => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.Paper.PaperSize, ViewModels.Data.Paper.PaperSize>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Paper.PaperSize, Data.Models.Paper.PaperSize>()
                .ForMember(d => d.Id, (options) => options.Ignore());

            CreateMap<Data.Models.Paper.PaperType, ViewModels.Data.Paper.PaperType>()
                .ForMember(d => d.PaperDensity, (options)  => options.Ignore())
                .ForMember(d => d.PaperClass, (options)  => options.Ignore())
                .ForMember(d => d.PaperPriceGroup, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.Data.Paper.PaperType, Data.Models.Paper.PaperType>()
                .ForMember(d => d.PaperDensity, (options)  => options.Ignore())
                .ForMember(d => d.PaperClass, (options)  => options.Ignore())
                .ForMember(d => d.PaperPriceGroup, (options)  => options.Ignore())
                .ForMember(d => d.Id, (options) => options.Ignore());


            CreateMap<Data.Models.Paper.Paper, ViewModels.Table.Paper.Paper>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperClass, ViewModels.Table.Paper.PaperClass>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperCoefficient, ViewModels.Table.Paper.PaperCoefficient>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperDensity, ViewModels.Table.Paper.PaperDensity>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperFormat, ViewModels.Table.Paper.PaperFormat>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperPriceGroup, ViewModels.Table.Paper.PaperPriceGroup>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperSize, ViewModels.Table.Paper.PaperSize>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperType, ViewModels.Table.Paper.PaperType>().ReverseMap();



            CreateMap<Data.Models.Paper.PaperClass, ViewModels.AutoComplete.PaperClass>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.PaperClass, Data.Models.Paper.PaperClass>()
               .ForMember(d => d.Id, (options) => options.Ignore());

             CreateMap<Data.Models.Storage.Category, ViewModels.AutoComplete.Category>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.Category, Data.Models.Storage.Category>()
               .ForMember(d => d.Id, (options) => options.Ignore());

             CreateMap<Data.Models.TechProcess.Option, ViewModels.AutoComplete.Option>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.Option, Data.Models.TechProcess.Option>()
               .ForMember(d => d.Id, (options) => options.Ignore());
               
             CreateMap<Data.Models.Paper.PaperDensity, ViewModels.AutoComplete.PaperDensity>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.PaperDensity, Data.Models.Paper.PaperDensity>()
               .ForMember(d => d.Id, (options) => options.Ignore());
                 
             CreateMap<Data.Models.Paper.PaperFormat, ViewModels.AutoComplete.PaperFormat>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.PaperFormat, Data.Models.Paper.PaperFormat>()
               .ForMember(d => d.Id, (options) => options.Ignore());               

             CreateMap<Data.Models.Paper.PaperPriceGroup, ViewModels.AutoComplete.PaperPriceGroup>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.PaperPriceGroup, Data.Models.Paper.PaperPriceGroup>()
               .ForMember(d => d.Id, (options) => options.Ignore());

             CreateMap<Data.Models.Paper.PaperSize, ViewModels.AutoComplete.PaperSize>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.PaperSize, Data.Models.Paper.PaperSize>()
               .ForMember(d => d.Id, (options) => options.Ignore());        

             CreateMap<Data.Models.Paper.PaperType, ViewModels.AutoComplete.PaperType>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.PaperType, Data.Models.Paper.PaperType>()
               .ForMember(d => d.Id, (options) => options.Ignore());
               
             CreateMap<Data.Models.PostPrint.PostPrintGroup, ViewModels.AutoComplete.PostPrintGroup>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.PostPrintGroup, Data.Models.PostPrint.PostPrintGroup>()
               .ForMember(d => d.Id, (options) => options.Ignore());
               
             CreateMap<Data.Models.PostPrint.PostPrintPriceGroup, ViewModels.AutoComplete.PostPrintPriceGroup>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.PostPrintPriceGroup, Data.Models.PostPrint.PostPrintPriceGroup>()
               .ForMember(d => d.Id, (options) => options.Ignore());
               
             CreateMap<Data.Models.PostPrint.PostPrintTarget, ViewModels.AutoComplete.PostPrintTarget>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.PostPrintTarget, Data.Models.PostPrint.PostPrintTarget>()
               .ForMember(d => d.Id, (options) => options.Ignore());
               
             CreateMap<Data.Models.TechProcess.PrintType, ViewModels.AutoComplete.PrintType>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.PrintType, Data.Models.TechProcess.PrintType>()
               .ForMember(d => d.Id, (options) => options.Ignore());
               
             CreateMap<Data.Models.TechProcess.Sector, ViewModels.AutoComplete.Sector>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.Sector, Data.Models.TechProcess.Sector>()
               .ForMember(d => d.Id, (options) => options.Ignore());
               
             CreateMap<Data.Models.Storage.Storage, ViewModels.AutoComplete.Storage>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.Storage, Data.Models.Storage.Storage>()
               .ForMember(d => d.Id, (options) => options.Ignore());
               
             CreateMap<Data.Models.Storage.SubCategory, ViewModels.AutoComplete.SubCategory>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.SubCategory, Data.Models.Storage.SubCategory>()
               .ForMember(d => d.Id, (options) => options.Ignore());
               
             CreateMap<Data.Models.Storage.UnitMeasure, ViewModels.AutoComplete.UnitMeasure>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.UnitMeasure, Data.Models.Storage.UnitMeasure>()
               .ForMember(d => d.Id, (options) => options.Ignore());
               
             CreateMap<Data.Models.TechProcess.TechProcess, ViewModels.AutoComplete.TechProcess>()
                .ForMember(d => d.Id, (options) => options.Ignore());
            CreateMap<ViewModels.AutoComplete.TechProcess, Data.Models.TechProcess.TechProcess>()
               .ForMember(d => d.Id, (options) => options.Ignore());
               

        }
    }
}