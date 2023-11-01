using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.Paper
{
    public class PaperDensity : IdViewModel<PrintCalculator.Data.Models.Paper.PaperDensity>
    {
        //public Guid Id { get; set; }
        public string Density { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperDensity dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            Density = dm.Density;
        }

        public override void ToDataModel(PrintCalculator.Data.Models.Paper.PaperDensity dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.Density = Density;
        }
    }

   
}
