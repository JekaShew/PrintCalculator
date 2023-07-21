using AutoMapper;

namespace PrintCalculator.Services
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {

            CreateMap<Data.Models.Storage.Storage, Abstract.Data.Storage.Storage>().ReverseMap();
            CreateMap<Data.Models.Storage.Category, Abstract.Data.Storage.Category>().ReverseMap();
            CreateMap<Data.Models.Storage.SubCategory, Abstract.Data.Storage.SubCategory>().ReverseMap();
            CreateMap<Data.Models.Storage.UnitMeasure, Abstract.Data.Storage.UnitMeasure>().ReverseMap();
            CreateMap<Data.Models.Storage.StorageProduct, Abstract.Data.Storage.StorageProduct>().ReverseMap();

            CreateMap<Data.Models.TechProcess.Option, Abstract.Data.TechProcess.Option>().ReverseMap();
            CreateMap<Data.Models.TechProcess.PrintType, Abstract.Data.TechProcess.PrintType>().ReverseMap();
            CreateMap<Data.Models.TechProcess.Sector, Abstract.Data.TechProcess.Sector>().ReverseMap();
            CreateMap<Data.Models.TechProcess.TechProcessOption, Abstract.Data.TechProcess.TechProcessOption>().ReverseMap();
            CreateMap<Data.Models.TechProcess.TechProcess, Abstract.Data.TechProcess.TechProcess>().ReverseMap();

            CreateMap<Data.Models.PostPrint.PackagingType, Abstract.Data.PostPrint.PackagingType>().ReverseMap();
            CreateMap<Data.Models.PostPrint.PostPrintGroup, Abstract.Data.PostPrint.PostPrintGroup>().ReverseMap();
            CreateMap<Data.Models.PostPrint.PostPrintOperation, Abstract.Data.PostPrint.PostPrintOperation>().ReverseMap();
            CreateMap<Data.Models.PostPrint.PostPrintPrice, Abstract.Data.PostPrint.PostPrintPrice>().ReverseMap();
            CreateMap<Data.Models.PostPrint.PostPrintPriceGroup, Abstract.Data.PostPrint.PostPrintPriceGroup>().ReverseMap();
            CreateMap<Data.Models.PostPrint.PostPrintTarget, Abstract.Data.PostPrint.PostPrintTarget>().ReverseMap();

            CreateMap<Data.Models.Paper.Paper, Abstract.Data.Paper.Paper>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperClass, Abstract.Data.Paper.PaperClass>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperCoefficient, Abstract.Data.Paper.PaperCoefficient>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperDensity, Abstract.Data.Paper.PaperDensity>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperFormat, Abstract.Data.Paper.PaperFormat>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperPriceGroup, Abstract.Data.Paper.PaperPriceGroup>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperSize, Abstract.Data.Paper.PaperSize>().ReverseMap();
            CreateMap<Data.Models.Paper.PaperType, Abstract.Data.Paper.PaperType>().ReverseMap();
        }
    }
}