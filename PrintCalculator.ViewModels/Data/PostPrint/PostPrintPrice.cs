using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.ViewModels.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.PostPrint
{
    public class PostPrintPrice : IdViewModel<PrintCalculator.Data.Models.PostPrint.PostPrintPrice>
    {
        //public Guid Id { get; set; }
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

        public ObjectValue<StringObjectValue> PostPrintPriceGroup { get; set; }
        public ObjectValue<StringObjectValue> MainPostPrintTarget { get; set; }
        public ObjectValue<StringObjectValue> AdditionalPostPrintTarget { get; set; }
        public ObjectValue<StringObjectValue> PaperFormat { get; set; }

        public List<PostPrintPriceGroup> PostPrintPriceGroups { get; set; }
        public List<PostPrintTarget> PostPrintTargets { get; set; }
        public List<PaperFormat> PaperFormats { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.PostPrint.PostPrintPrice dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            PostPrintPriceGroup = new ObjectValue<StringObjectValue>
            {
                Value = dm.PostPrintPriceGroupId,
                VM = new StringObjectValue
                {
                    Id = dm.PostPrintPriceGroupId,
                    Title = dm.PostPrintPriceGroup.Title,
                },
            };

            MainPostPrintTarget = new ObjectValue<StringObjectValue>
            {
                Value = dm.MainPostPrintTargetId,
                VM = new StringObjectValue
                {
                    Id = dm.MainPostPrintTargetId,
                    Title = dm.MainPostPrintTarget.Title,
                },
            };

            AdditionalPostPrintTarget = new ObjectValue<StringObjectValue>
            {
                Value = dm.AdditionalPostPrintTargetId,
                VM = new StringObjectValue
                {
                    Id = dm.AdditionalPostPrintTargetId,
                    Title = dm.AdditionalPostPrintTarget.Title,
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
        }

        public override void ToDataModel(PrintCalculator.Data.Models.PostPrint.PostPrintPrice dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.PostPrintPriceGroupId = PostPrintPriceGroup.Value;
            dm.MainPostPrintTargetId = MainPostPrintTarget.Value;
            dm.AdditionalPostPrintTargetId = AdditionalPostPrintTarget.Value;
            dm.PaperFormatId = PaperFormat.Value;
        }
    }

     
}
