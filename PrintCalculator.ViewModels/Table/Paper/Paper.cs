using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.Paper
{
    public class Paper : TableModelAutoMapped<PrintCalculator.Data.Models.Paper.Paper>
    {
        public string Title { get; set; }
        public string TitleOnStorage { get; set; }
        public float Price { get; set; }
        public int MarkupMaxAmount { get; set; }
        public float MarkupMaxAmountCoefficient { get; set; }
        public int MarkupMinAmount { get; set; }
        public float MarkupMinAmountCoefficient { get; set; }
        public float PriceKg { get; set; }
        public bool SuspendedSupply { get; set; }

        public Guid PaperTypeId { get; set; }
        public Guid PaperPriceGroupId { get; set; }
        public Guid PaperDensityId { get; set; }
        public Guid PaperSizeId { get; set; }

        public string PaperType { get; set; }
        public string PaperPriceGroup { get; set; }
        public string PaperDensity { get; set; }
        public string PaperSize { get; set; }

        public List<PaperType> PaperTypes { get; set; }
        public List<PaperPriceGroup> PaperPriceGroups { get; set; }
        public List<PaperDensity> PaperDensities { get; set; }
        public List<PaperSize> PaperSizes { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.Paper dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            PaperType = dm.PaperType.Title;
            PaperPriceGroup = dm.PaperPriceGroup.Title;
            PaperDensity = dm.PaperDensity.Density;
            PaperSize = dm.PaperSize.Title;

        }
    }
}
