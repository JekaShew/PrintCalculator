using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.Storage
{
    public class SubCategory : TableModelAutoMapped<PrintCalculator.Data.Models.Storage.SubCategory>
    {
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public string Category { get; set; }
        public List<Category> Categories { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Storage.SubCategory dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Category = dm.Category.Title;

        }
    }
}
