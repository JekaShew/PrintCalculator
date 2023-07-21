using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.Data.Paper
{
    public class PaperType
    {
        public Guid Id { get; set; }
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

        public PaperDensity PaperDensity { get; set; }
        public PaperClass PaperClass { get; set; }
        public PaperPriceGroup PaperPriceGroup { get; set; }

        public List<PaperDensity> PaperDensities { get; set; }
        public List<PaperClass> PaperClasses { get; set; }
        public List<PaperPriceGroup> PaperPriceGroups { get; set; }
    }
}
