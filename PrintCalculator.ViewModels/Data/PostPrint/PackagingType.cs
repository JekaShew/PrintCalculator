using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.PostPrint
{
    public class PackagingType : IdViewModel<PrintCalculator.Data.Models.PostPrint.PackagingType>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public float PreparationPrice { get; set; }
        public float PerPackPrice { get; set; }
        public float PreparationCostPrice { get; set; }
        public float PerPackCostPrice { get; set; }
        public int PreparationTime { get; set; }
        public int PerPackTime { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.PostPrint.PackagingType dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            Title = dm.Title;
        }

        public override void ToDataModel(PrintCalculator.Data.Models.PostPrint.PackagingType dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.Title = Title;
        }
    }

    
}
