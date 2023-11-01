using PrintCalculator.UI.Gen2.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data.Models.Paper
{
    public class Paper : Model
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public string TitleOnStorage { get; set; }
        public float Price { get; set; }
        public int MarkupMaxAmount { get; set; }
        public float MarkupMaxAmountCoefficient { get; set; }
        public int MarkupMinAmount { get; set; }
        public float MarkupMinAmountCoefficient { get; set; }
        public float PriceKg {get;set;}
        public bool SuspendedSupply { get; set; }

        public Guid PaperTypeId { get; set; }
        public Guid PaperPriceGroupId { get; set; }
        public Guid PaperDensityId { get; set; }
        public Guid PaperSizeId { get; set; }

        public PaperType PaperType { get; set; }
        public PaperPriceGroup PaperPriceGroup { get; set; }
        public PaperDensity PaperDensity { get; set; }
        public PaperSize PaperSize { get; set; }

        public List<PaperType> PaperTypes { get; set; }
        public List<PaperPriceGroup> PaperPriceGroups { get; set; }
        public List<PaperDensity> PaperDensities { get; set; }
        public List<PaperSize> PaperSizes { get; set; }

    }
}
