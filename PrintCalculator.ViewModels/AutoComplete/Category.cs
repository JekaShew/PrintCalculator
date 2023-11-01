using PrintCalculator.UI.Gen2.Autocomplete.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.AutoComplete
{
    public class Category : AutocompleteModel<PrintCalculator.Data.Models.Storage.Category>
    {
        public string Title { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Storage.Category dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Title = dm.Title;
        }
    }
}
