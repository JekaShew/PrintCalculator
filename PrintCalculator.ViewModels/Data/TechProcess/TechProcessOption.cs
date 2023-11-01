using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.TechProcess
{
    public class TechProcessOption : IdViewModel<PrintCalculator.Data.Models.TechProcess.TechProcessOption>
    {
        //public Guid Id { get; set; }
        public Guid TechProcessId { get; set; }
        public Guid OptionId { get; set; }
        public ObjectValue<StringObjectValue> TechProcess { get; set; }
        public ObjectValue<StringObjectValue> Option { get; set; }

        public List<TechProcess> TechProcesses { get; set; }
        public List<Option> Options { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.TechProcess.TechProcessOption dm, UtilsServices service)
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

            Option = new ObjectValue<StringObjectValue>
            {
                Value = dm.OptionId,
                VM = new StringObjectValue
                {
                    Id = dm.OptionId,
                    Title = dm.Option.Title,
                },
            };
        }

        public override void ToDataModel(PrintCalculator.Data.Models.TechProcess.TechProcessOption dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.TechProcessId = TechProcess.Value;
            dm.OptionId = Option.Value;
        }
    }
}
