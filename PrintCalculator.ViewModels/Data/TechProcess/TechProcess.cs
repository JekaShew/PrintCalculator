using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.ViewModels.Data.ObjectValues;
using PrintCalculator.ViewModels.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.TechProcess
{
    public class TechProcess : IdViewModel<PrintCalculator.Data.Models.TechProcess.TechProcess>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public int Color { get; set; }
        public bool Special { get; set; }


        public float MaxPaperWidth { get; set; }
        public float MaxPaperHeight { get; set; }
        public float MinPaperWidth { get; set; }
        public float MinPaperHeight { get; set; }
        public int BeforePrintTime { get; set; }
        public int StartPrintTime { get; set; }
        public int OneInstancePrintTime { get; set; }
        public int WaitingPostPrintTime { get; set; }
        public int DryingTime { get; set; }
        public int CheckTime { get; set; }
        public int InstallationTime { get; set; }
        public float CostPrice { get; set; }
        public float MaterialMarkup { get; set; }

        public float FittingPrice { get; set; }
        public float FittingWithoutTurnOver { get; set; }
        public float FittingForeignerTurnOver { get; set; }
        public float FittingKombo { get; set; }
        public float FittingYourTurnOver { get; set; }
        public float FormsPrice { get; set; }
        public float PantonBatchPrice { get; set; }
        public float LacquerPreparationPrice { get; set; }
        public int PaperFittingFirstPrint { get; set; }
        public int PaperFittingAdditionalPaint { get; set; }
        public int PaperFittingPanton { get; set; }
        public float PaperFittingFromEdition { get; set; }
        public float CuttingCutPrice { get; set; }
        public float PrintRunPrice { get; set; }
        public float PrintRunLacquerPrice { get; set; }
        public float CuttingPreparationPrice { get; set; }
        public int ValveWidth { get; set; }
        public int PaperTrim { get; set; }
        public int FieldForCrosses { get; set; }
        public int DiesWidth { get; set; }
        public int SectionsInThePriceOfARun { get; set; }
        public float FittingPerRunPrice { get; set; }
        public float MinPrintPrice { get; set; }
        public float MinPrintSheetPrice { get; set; }
        public float IncreasedTireWear { get; set; }
        public int PlatesCtPResource { get; set; }
        public float CuttingWithACollarMarkUp { get; set; }
        public float CoefficientPerTurnOver { get; set; }
        public float CustomCutting { get; set; }
        public float FittingYourTurnOverThroughValvePrice { get; set; }
        public float FittingCoefficientForYourTurnOver { get; set; }
        public float Rewash { get; set; }

        public Guid PrintTypeId { get; set; }
        public Guid SectorId { get; set; }
        public Guid StorageId { get; set; }
        public Guid PaperFormatId { get; set; }
        public Guid PaperSizeId { get; set; }

        public ObjectValue<StringObjectValue> PrintType { get; set; }
        public ObjectValue<StringObjectValue> Sector { get; set; }
        public ObjectValue<StringObjectValue> Storage { get; set; }
        public ObjectValue<StringObjectValue> PaperFormat { get; set; }
        public ObjectValue<StringObjectValue> PaperSize { get; set; }

        public List<PrintType> PrintTypes { get; set; }
        public List<Sector> Sectors { get; set; }
        public List<Storage.Storage> Storages { get; set; }
        public List<PaperFormat> PaperFormats { get; set; }
        public List<PaperSize> PaperSizes { get; set; }

        public List<TechProcessOption> TechProcessOptions { get; set; }
        public List<ObjectValue<StringObjectValue>> Options { get; private set; }

        //public List<Option> Options { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.TechProcess.TechProcess dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            PrintType = new ObjectValue<StringObjectValue>
            {
                Value = dm.PrintTypeId,
                VM = new StringObjectValue
                {
                    Id = dm.PrintTypeId,
                    Title = dm.PrintType.Title,
                },
            };

            Sector = new ObjectValue<StringObjectValue>
            {
                Value = dm.SectorId,
                VM = new StringObjectValue
                {
                    Id = dm.SectorId,
                    Title = dm.Sector.Title,
                },
            };

            Storage = new ObjectValue<StringObjectValue>
            {
                Value = dm.StorageId,
                VM = new StringObjectValue
                {
                    Id = dm.StorageId,
                    Title = dm.Storage.Title,
                },
            };

            PaperFormat = new ObjectValue<StringObjectValue>
            {
                Value = dm.PaperFormatId,
                VM = new StringObjectValue
                {
                    Id = dm.PaperFormatId,
                    Title = dm.PaperFormat.Title,
                },
            };

            PaperSize = new ObjectValue<StringObjectValue>
            {
                Value = dm.PaperSizeId,
                VM = new StringObjectValue
                {
                    Id = dm.PaperSizeId,
                    Title = dm.PaperSize.Title,
                },
            };

            TechProcessOptions = dm.TechProcessOptions.Select(x => new TechProcessOption
            {
                TechProcess = new ObjectValue<StringObjectValue>
                {
                    Value = x.TechProcessId,
                    VM = new StringObjectValue
                    {
                        Id = x.TechProcessId,
                        Title = x.TechProcess.Title,
                    }
                },

                Option = new ObjectValue<StringObjectValue>
                {
                    Value = x.OptionId,
                    VM = new StringObjectValue
                    {
                        Id = x.Option.Id,
                        Title = x.Option.Title,
                    }
                }
            }).ToList();

            Options = dm.TechProcessOptions.Select(x => new ObjectValue<StringObjectValue>
            {
                Value = x.OptionId,
                VM = new StringObjectValue
                {
                    Id = x.Option.Id,
                    Title = x.Option.Title,
                },
                
            }).ToList();

        }

        //??
        public override void ToDataModel(PrintCalculator.Data.Models.TechProcess.TechProcess dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.PrintTypeId = PrintType.Value;
            dm.SectorId = Sector.Value;
            dm.StorageId = Storage.Value;
            dm.PaperFormatId = PaperFormat.Value;
            dm.PaperSizeId = PaperSize.Value;



            if (dm.TechProcessOptions != null)
                service.AppDbContext.Set<PrintCalculator.Data.Models.TechProcess.TechProcessOption>().RemoveRange(dm.TechProcessOptions);
            if (TechProcessOptions != null)
            {

                dm.TechProcessOptions = TechProcessOptions.Select(x => new PrintCalculator.Data.Models.TechProcess.TechProcessOption
                {
                    OptionId = x.Option.Value,
                    //TechProcessId = x.TechProcess.Value,
                    Id = Guid.NewGuid(),
                }).ToList();
                service.AppDbContext.Set<PrintCalculator.Data.Models.TechProcess.TechProcessOption>().AddRange(dm.TechProcessOptions);
            }
        }
    }
}
