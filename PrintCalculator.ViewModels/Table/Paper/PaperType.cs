using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.Paper
{
    public class PaperType : TableModelAutoMapped<PrintCalculator.Data.Models.Paper.PaperType>
    {
        public string Title { get; set; }
        public float Width { get; set; }
        public bool OneSided { get; set; }
        public float MinMarkUpPurchasePrice { get; set; }
        public int MarkupMaxAmount { get; set; }
        public float MarkupMaxAmountCoefficient { get; set; }
        public int MarkupMinAmount { get; set; }
        public float MarkupMinAmountCoefficient { get; set; }

        public Guid PaperDensityId { get; set; }
        public Guid PaperClassId { get; set; }
        public Guid PaperPriceGroupId { get; set; }

        public string PaperDensity { get; set; }
        public string PaperClass { get; set; }
        public string PaperPriceGroup { get; set; }

        public List<PaperDensity> PaperDensities { get; set; }
        public List<PaperClass> PaperClasses { get; set; }
        public List<PaperPriceGroup> PaperPriceGroups { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperType dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            PaperDensity = dm.PaperDensity.Density;
            PaperClass = dm.PaperClass.Title;
            PaperPriceGroup = dm.PaperPriceGroup.Title;

        }
    }
}
