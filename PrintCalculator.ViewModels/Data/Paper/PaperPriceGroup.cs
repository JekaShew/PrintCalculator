using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.Paper
{
    public class PaperPriceGroup : IdViewModel<PrintCalculator.Data.Models.Paper.PaperPriceGroup>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public float PricePerKg { get; set; }
        public int MarkupMaxAmount { get; set; }
        public float MarkupMaxCoefficient { get; set; }
        public int MarkupMinAmount { get; set; }
        public float MarkupMinCoefficient { get; set; }

        //public Guid PaperClassId { get; set; }

        public ObjectValue<StringObjectValue> PaperClass { get; set; }
        //public PaperClass PaperClass { get; set; }

        public List<PaperClass> PaperClasses { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperPriceGroup dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            PaperClass = new ObjectValue<StringObjectValue>
            {
                Value = dm.PaperClassId,
                VM = new StringObjectValue
                {
                    Id = dm.PaperClassId,
                    Title = dm.PaperClass.Title,                    
                },
            };

            //PaperClasses = dm.PaperClasses.Select(x => new PaperClass
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //}).ToList();
        }

        public override void ToDataModel(PrintCalculator.Data.Models.Paper.PaperPriceGroup dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.PaperClassId = PaperClass.Value;
        }
    }
}
