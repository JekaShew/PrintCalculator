using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.PostPrint
{
    public class PostPrintPriceGroup : TableModelAutoMapped<PrintCalculator.Data.Models.PostPrint.PostPrintPriceGroup>
    {
        public string Title { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.PostPrint.PostPrintPriceGroup dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Title = dm.Title;
        }
    }
}
