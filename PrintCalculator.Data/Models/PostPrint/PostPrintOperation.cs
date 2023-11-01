using PrintCalculator.UI.Gen2.Data.Abstract;
using PrintCalculator.Data.Models.TechProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data.Models.PostPrint
{
    public class PostPrintOperation : Model
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

        public PostPrintGroup PostPrintGroup { get; set; }
        public PostPrintTarget PostPrintTarget { get; set; }
        public Sector Sector { get; set; }

        public List<PostPrintGroup> PostPrintGroups { get; set; }
        public List<PostPrintTarget> PostPrintTargets { get; set; }
        public List<Sector> Sectors { get; set; }
    }
}
