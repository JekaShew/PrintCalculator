using PrintCalculator.Abstract.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.Data.TechProcess
{
    public class TechProcess
    {
        public Guid Id { get; set; }
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
        public Guid FormatId { get; set; }
        public Guid PreferredPaperSizeId { get; set; }

        public PrintType PrintType { get; set; }
        public Sector Sector { get; set; }
        public Storage.Storage Storage { get; set; }
        public PaperFormat PaperFormat { get; set; }
        public PaperSize PrefferedPaperSize { get; set; }

        public List<PrintType> PrintTypes { get; set; }
        public List<Sector> Sectors { get; set; }
        public List<Storage.Storage> Storages { get; set; }
        public List<PaperFormat> PaperFormats { get; set; }
        public List<PaperSize> PaperSizes { get; set; }

        public List<TechProcessOption> TechProcessOptions { get; set; }
    }
}
