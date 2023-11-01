using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.Paper
{
    public class PaperType : IdViewModel<PrintCalculator.Data.Models.Paper.PaperType>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public float Width { get; set; }
        public bool OneSided { get; set; }
        public float MinMarkUpPurchasePrice { get; set; }
        public int MarkupMaxAmount { get; set; }
        public float MarkupMaxAmountCoefficient { get; set; }
        public int MarkupMinAmount { get; set; }
        public float MarkupMinAmountCoefficient { get; set; }

        public Guid PaperDensityId { get; set; }
        public Guid PaperClassId { get; set; }
        public Guid PaperPriceGroupId { get; set; }

        public ObjectValue<StringObjectValue> PaperDensity { get; set; }
        public ObjectValue<StringObjectValue> PaperClass { get; set; }
        public ObjectValue<StringObjectValue> PaperPriceGroup { get; set; }

        public List<PaperDensity> PaperDensities { get; set; }
        public List<PaperClass> PaperClasses { get; set; }
        public List<PaperPriceGroup> PaperPriceGroups { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperType dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            PaperDensity = new ObjectValue<StringObjectValue>
            {
                Value = dm.PaperDensityId,
                VM = new StringObjectValue
                {
                    Id = dm.PaperDensityId,
                    Title = dm.PaperDensity.Density,
                },
            };

            PaperClass = new ObjectValue<StringObjectValue>
            {
                Value = dm.PaperClassId,
                VM = new StringObjectValue
                {
                    Id = dm.PaperClassId,
                    Title = dm.PaperClass.Title,
                },
            };

            PaperPriceGroup = new ObjectValue<StringObjectValue>
            {
                Value = dm.PaperPriceGroupId,
                VM = new StringObjectValue
                {
                    Id = dm.PaperPriceGroupId,
                    Title = dm.PaperPriceGroup.Title,
                },
            };
        }

        public override void ToDataModel(PrintCalculator.Data.Models.Paper.PaperType dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.PaperDensityId = PaperDensity.Value;
            dm.PaperClassId = PaperClass.Value;
            dm.PaperPriceGroupId = PaperPriceGroup.Value;
        }
    }

   
}
