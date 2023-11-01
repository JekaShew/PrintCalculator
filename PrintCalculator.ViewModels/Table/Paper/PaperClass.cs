using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.Paper
{
    public class PaperClass : TableModelAutoMapped<PrintCalculator.Data.Models.Paper.PaperClass>
    {
        public string Title { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperClass dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Title = dm.Title;
        }
    }
}
