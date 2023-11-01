using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.Storage
{
    public class Category : TableModelAutoMapped<PrintCalculator.Data.Models.Storage.Category>
    {
        public string Title { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Storage.Category dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Title = dm.Title;
        }
    }
}
