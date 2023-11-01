using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using PrintCalculator.ViewModels.Table.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.PostPrint
{
    public class PostPrintPrice : TableModelAutoMapped<PrintCalculator.Data.Models.PostPrint.PostPrintPrice>
    {
        public string Title { get; set; }
        public int MainPreparation { get; set; }
        public int AdditionalPreparation { get; set; }
        public float MainPerUnitMax { get; set; }
        public float AdditionalPerUnitMax { get; set; }
        public float MainPerUnitMin { get; set; }
        public float AdditionalPerUnitMin { get; set; }
        public int MainAmountForMaxPrice { get; set; }
        public int AdditionalAmountForMaxPrice { get; set; }
        public int MainAmountForMinPrice { get; set; }
        public int AdditionalAmountForMinPrice { get; set; }
        public int MultiplierPreparation { get; set; }
        public float PreparationCostPrice { get; set; }
        public float ForUnitCostPrice { get; set; }
        public string MeasureUnit { get; set; }
        public int FittingPerKPLpsc { get; set; }
        public int FittingPerOrderpsc { get; set; }
        public float FittingFromEditionCoefficient { get; set; }
        public int Weight { get; set; }
        public bool Consumable { get; set; }
        public int AppliesTo { get; set; }
        public bool DestroySheet { get; set; }
        public bool OneSide { get; set; }
        public bool RequirePrepress { get; set; }
        public int SheetWidth { get; set; }
        public int SheetHeight { get; set; }
        public int IndentLong { get; set; }
        public int IndentShort { get; set; }

        public Guid PostPrintPriceGroupId { get; set; }
        public Guid MainPostPrintTargetId { get; set; }
        public Guid AdditionalPostPrintTargetId { get; set; }
        public Guid PaperFormatId { get; set; }

        public string PostPrintPriceGroup { get; set; }
        public string MainPostPrintTarget { get; set; }
        public string AdditionalPostPrintTarget { get; set; }
        public string PaperFormat { get; set; }

        public List<PostPrintPriceGroup> PostPrintPriceGroups { get; set; }
        public List<PostPrintTarget> PostPrintTargets { get; set; }
        public List<PaperFormat> PaperFormats { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.PostPrint.PostPrintPrice dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            PostPrintPriceGroup = dm.PostPrintPriceGroup.Title;
            MainPostPrintTarget = dm.MainPostPrintTarget.Title;
            AdditionalPostPrintTarget = dm.AdditionalPostPrintTarget.Title;
            PaperFormat = dm.PaperFormat.Title;

        }
    }
}
