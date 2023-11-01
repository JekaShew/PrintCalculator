using PrintCalculator.UI.Gen2.Autocomplete.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.AutoComplete
{
    public class PaperDensity : AutocompleteModel<PrintCalculator.Data.Models.Paper.PaperDensity>
    {
        public string Title { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Paper.PaperDensity dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Title = dm.Density.ToString();
        }
    }
}
