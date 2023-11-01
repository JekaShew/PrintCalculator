using PrintCalculator.UI.Gen2.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data.Models.Paper
{
    public class PaperPriceGroup : Model
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public float PricePerKg { get; set; }
        public int MarkupMaxAmount { get; set; }
        public float MarkupMaxCoefficient { get; set; }
        public int MarkupMinAmount { get; set; }
        public float MarkupMinCoefficient { get; set; }

        public Guid PaperClassId { get; set; }

        public PaperClass PaperClass { get; set; }

        public List<PaperClass> PaperClasses { get; set; }
    }
}
