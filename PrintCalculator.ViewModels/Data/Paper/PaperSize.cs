using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.Paper
{
    public class PaperSize : IdViewModel<PrintCalculator.Data.Models.Paper.PaperSize>
    {
        public string Title { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperSize dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            Title = dm.Title;
        }

        public override void ToDataModel(PrintCalculator.Data.Models.Paper.PaperSize dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.Title = Title;
        }
    }

   
}
