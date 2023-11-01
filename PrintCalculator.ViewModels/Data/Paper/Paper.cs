using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.Paper
{
    public class Paper : IdViewModel<PrintCalculator.Data.Models.Paper.Paper>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public string TitleOnStorage { get; set; }
        public float Price { get; set; }
        public int MarkupMaxAmount { get; set; }
        public float MarkupMaxAmountCoefficient { get; set; }
        public int MarkupMinAmount { get; set; }
        public float MarkupMinAmountCoefficient { get; set; }
        public float PriceKg { get; set; }
        public bool SuspendedSupply { get; set; }

        public Guid PaperTypeId { get; set; }
        public Guid PaperPriceGroupId { get; set; }
        public Guid PaperDensityId { get; set; }
        public Guid PaperSizeId { get; set; }

        public ObjectValue<StringObjectValue> PaperType { get; set; }
        public ObjectValue<StringObjectValue> PaperPriceGroup { get; set; }
        public ObjectValue<StringObjectValue> PaperDensity { get; set; }
        public ObjectValue<StringObjectValue> PaperSize { get; set; }

        public List<PaperType> PaperTypes { get; set; }
        public List<PaperPriceGroup> PaperPriceGroups { get; set; }
        public List<PaperDensity> PaperDensities { get; set; }
        public List<PaperSize> PaperSizes { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.Paper dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            PaperType = new ObjectValue<StringObjectValue>
            {
                Value = dm.PaperTypeId,
                VM = new StringObjectValue
                {
                    Id = dm.PaperTypeId,
                    Title = dm.PaperType.Title,
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

            PaperDensity = new ObjectValue<StringObjectValue>
            {
                Value = dm.PaperDensityId,
                VM = new StringObjectValue
                {
                    Id = dm.PaperDensityId,
                    Title = dm.PaperDensity.Density,
                },
            };

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

        public override void ToDataModel(PrintCalculator.Data.Models.Paper.Paper dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.PaperTypeId = PaperType.Value;
            dm.PaperPriceGroupId = PaperPriceGroup.Value;
            dm.PaperDensityId = PaperDensity.Value;
            dm.PaperSizeId = PaperSize.Value;
        }
    }
    
    
}
