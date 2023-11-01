using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.ViewModels.Data.TechProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.PostPrint
{
    public class PostPrintOperation : IdViewModel<PrintCalculator.Data.Models.PostPrint.PostPrintOperation>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public string MeasureUnit { get; set; }
        public bool ConsumesPaperMaterial { get; set; }
        public int WaitingTime { get; set; }
        public int PreparationTime { get; set; }
        public int OperationTime { get; set; }

        public Guid PostPrintGroupId { get; set; }
        public Guid PostPrintTargetId { get; set; }
        public Guid SectorId { get; set; }

        public ObjectValue<StringObjectValue> PostPrintGroup { get; set; }
        public ObjectValue<StringObjectValue> PostPrintTarget { get; set; }
        public ObjectValue<StringObjectValue> Sector { get; set; }

        public List<PostPrintGroup> PostPrintGroups { get; set; }
        public List<PostPrintTarget> PostPrintTargets { get; set; }
        public List<Sector> Sectors { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.PostPrint.PostPrintOperation dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            PostPrintGroup = new ObjectValue<StringObjectValue>
            {
                Value = dm.PostPrintGroupId,
                VM = new StringObjectValue
                {
                    Id = dm.PostPrintGroupId,
                    Title = dm.PostPrintGroup.Title,
                },
            };

            PostPrintTarget = new ObjectValue<StringObjectValue>
            {
                Value = dm.PostPrintTargetId,
                VM = new StringObjectValue
                {
                    Id = dm.PostPrintTargetId,
                    Title = dm.PostPrintTarget.Title,
                },
            };

            Sector = new ObjectValue<StringObjectValue>
            {
                Value = dm.SectorId,
                VM = new StringObjectValue
                {
                    Id = dm.SectorId,
                    Title = dm.Sector.Title,
                },
            };

        }

        public override void ToDataModel(PrintCalculator.Data.Models.PostPrint.PostPrintOperation dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.PostPrintGroupId = PostPrintGroup.Value;
            dm.PostPrintTargetId = PostPrintTarget.Value;
            dm.SectorId = Sector.Value;
        }
    }

    
}
