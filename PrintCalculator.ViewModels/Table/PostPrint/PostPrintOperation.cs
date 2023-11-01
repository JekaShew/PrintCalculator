using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using PrintCalculator.ViewModels.Table.TechProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.PostPrint
{
    public class PostPrintOperation : TableModelAutoMapped<PrintCalculator.Data.Models.PostPrint.PostPrintOperation>
    {
        public string Title { get; set; }
        public string MeasureUnit { get; set; }
        public bool ConsumesPaperMaterial { get; set; }
        public int WaitingTime { get; set; }
        public int PreparationTime { get; set; }
        public int OperationTime { get; set; }
        public Guid PostPrintGroupId { get; set; }
        public Guid PostPrintTargetId { get; set; }
        public Guid SectorId { get; set; }

        public string PostPrintGroup { get; set; }
        public string PostPrintTarget { get; set; }
        public string Sector { get; set; }

        public List<PostPrintGroup> PostPrintGroups { get; set; }
        public List<PostPrintTarget> PostPrintTargets { get; set; }
        public List<Sector> Sectors { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.PostPrint.PostPrintOperation dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            PostPrintGroup = dm.PostPrintGroup.Title;
            PostPrintTarget = dm.PostPrintTarget.Title;
            Sector = dm.Sector.Title;

        }
    }
}
