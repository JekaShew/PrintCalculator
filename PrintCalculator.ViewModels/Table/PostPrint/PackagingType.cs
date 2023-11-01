using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.PostPrint
{
    public class PackagingType : TableModelAutoMapped<PrintCalculator.Data.Models.PostPrint.PackagingType>
    {
        public string Title { get; set; }
        public float PreparationPrice { get; set; }
        public float PerPackPrice { get; set; }
        public float PreparationCostPrice { get; set; }
        public float PerPackCostPrice { get; set; }
        public int PreparationTime { get; set; }
        public int PerPackTime { get; set; }

         public override void FromDataModel(PrintCalculator.Data.Models.PostPrint.PackagingType dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Title = dm.Title;
        }
    }
}
