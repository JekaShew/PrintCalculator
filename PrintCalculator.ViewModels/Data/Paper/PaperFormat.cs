using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.Paper
{
    public class PaperFormat : IdViewModel<PrintCalculator.Data.Models.Paper.PaperFormat>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid PaperSizeId { get; set; }
        public ObjectValue<StringObjectValue> PaperSize { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperFormat dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            PaperSize = new ObjectValue<StringObjectValue>
            {
                Value = dm.PaperSizeId,
                VM = new StringObjectValue
                {
                    Id = dm.PaperSizeId,
                    Title = dm.PaperSize.Title,
                },
            };
        }

        public override void ToDataModel(PrintCalculator.Data.Models.Paper.PaperFormat dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.PaperSizeId = PaperSize.Value;
        }
    }

     
}
