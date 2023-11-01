
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.TechProcess
{
    public class Sector : TableModelAutoMapped<PrintCalculator.Data.Models.TechProcess.Sector>
    {
        public string Title { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.TechProcess.Sector dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Title = dm.Title;
        }
    }
}
