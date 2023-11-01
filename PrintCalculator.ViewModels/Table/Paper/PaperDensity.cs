using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.Paper
{
    public class PaperDensity : TableModelAutoMapped<PrintCalculator.Data.Models.Paper.PaperDensity>
    {
        public string Density { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperDensity dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Density = dm.Density;
        }
    }
}
