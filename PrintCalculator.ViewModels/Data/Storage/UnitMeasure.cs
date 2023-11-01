using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.Storage
{
    public class UnitMeasure : IdViewModel<PrintCalculator.Data.Models.Storage.UnitMeasure>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Storage.UnitMeasure dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            Title = dm.Title;
        }

        public override void ToDataModel(PrintCalculator.Data.Models.Storage.UnitMeasure dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.Title = Title;
        }
    }

   
}
