using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.Paper
{
    public class PaperFormat : TableModelAutoMapped<PrintCalculator.Data.Models.Paper.PaperFormat>
    {
        public string Title { get; set; }
        public Guid PaperSizeId { get; set; }
        public string PaperSize { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperFormat dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            PaperSize = dm.PaperSize.Title;

        }
    }
}
