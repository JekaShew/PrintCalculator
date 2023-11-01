using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.Paper
{
    public class PaperCoefficient : IdViewModel<PrintCalculator.Data.Models.Paper.PaperCoefficient>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public float Coefficient { get; set; }
        public Guid PaperDensityId { get; set; }
        public Guid TechProcessId { get; set; }
        public ObjectValue<StringObjectValue> TechProcess { get; set; }
        public ObjectValue<StringObjectValue> PaperDensity { get; set; }

        //public List<PaperDensity> PaperDensities { get; set; }
        //public List<TechProcess.TechProcess> TechProcesses { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperCoefficient dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            TechProcess = new ObjectValue<StringObjectValue>
            {
                Value = dm.TechProcessId,
                VM = new StringObjectValue
                {
                    Id = dm.TechProcessId,
                    Title = dm.TechProcess.Title,
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
        }

        public override void ToDataModel(PrintCalculator.Data.Models.Paper.PaperCoefficient dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.TechProcessId = TechProcess.Value;
            dm.PaperDensityId = PaperDensity.Value;
        }
    }

    
}
