using PrintCalculator.UI.Gen2.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data.Models.TechProcess
{
    public class TechProcessOption : Model
    {
        //public Guid Id { get; set; }
        public Guid TechProcessId { get; set; }
        public Guid OptionId { get; set; }
        public TechProcess TechProcess { get; set; }
        public Option Option { get; set; }

        //public List<TechProcess> TechProcesses { get; set; }
        //public List<Option> Options { get; set; }
    }
}
