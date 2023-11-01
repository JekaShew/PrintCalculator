using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.TechProcess
{
    public class TechProcessOption : TableModelAutoMapped<PrintCalculator.Data.Models.TechProcess.TechProcessOption>
    {
        public Guid TechProcessId { get; set; }
        public Guid OptionId { get; set; }
        public string TechProcess { get; set; }
        public string Option { get; set; }

        public List<TechProcess> TechProcesses { get; set; }
        public List<Option> Options { get; set; }

         public override void FromDataModel(PrintCalculator.Data.Models.TechProcess.TechProcessOption dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            TechProcess = dm.TechProcess.Title;
            Option = dm.Option.Title;

        }
    }
}
