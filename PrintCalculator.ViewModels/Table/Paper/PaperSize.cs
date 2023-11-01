using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.Paper
{
    public class PaperSize : TableModelAutoMapped<PrintCalculator.Data.Models.Paper.PaperSize>
    {
        public string Title { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperSize dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Title = dm.Title;
        }
    }
}
