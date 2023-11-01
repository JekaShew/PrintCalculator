using PrintCalculator.UI.Gen2.Autocomplete.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.AutoComplete
{
    public class TechProcess : AutocompleteModel<PrintCalculator.Data.Models.TechProcess.TechProcess>
    {
        public string Title { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.TechProcess.TechProcess dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Title = dm.Title;
        }
    }
}
