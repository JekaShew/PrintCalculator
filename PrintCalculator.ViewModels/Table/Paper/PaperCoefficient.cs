using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.Paper
{
    public class PaperCoefficient : TableModelAutoMapped<PrintCalculator.Data.Models.Paper.PaperCoefficient>
    {
        public string Title { get; set; }
        public float Coefficient { get; set; }
        public Guid PaperDensityId { get; set; }
        public Guid TechProcessId { get; set; }
        public string TechProcess { get; set; }
        public string PaperDensity { get; set; }

         public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperCoefficient dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            TechProcess = dm.TechProcess.Title;
            PaperDensity = dm.PaperDensity.Density;

        }
    }
}
