using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.PostPrint
{
    public class PostPrintGroup : IdViewModel<PrintCalculator.Data.Models.PostPrint.PostPrintGroup>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.PostPrint.PostPrintGroup dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            Title = dm.Title;
        }

        public override void ToDataModel(PrintCalculator.Data.Models.PostPrint.PostPrintGroup dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.Title = Title;
        }
    }

   
}
