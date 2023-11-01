using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.Paper
{
    public class PaperPriceGroup : TableModelAutoMapped<PrintCalculator.Data.Models.Paper.PaperPriceGroup>
    {
        public string Title { get; set; }
        public float PricePerKg { get; set; }
        public int MarkupMaxAmount { get; set; }
        public float MarkupMaxCoefficient { get; set; }
        public int MarkupMinAmount { get; set; }
        public float MarkupMinCoefficient { get; set; }

        public Guid PaperClassId { get; set; }

        public string PaperClass { get; set; }

        public List<PaperClass> PaperClasses { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperPriceGroup dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            PaperClass = dm.PaperClass.Title;

        }
    }
}
