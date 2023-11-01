using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.Storage
{
    public class SubCategory : IdViewModel<PrintCalculator.Data.Models.Storage.SubCategory>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public ObjectValue<StringObjectValue> Category { get; set; }
        public List<Category> Categories { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Storage.SubCategory dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            Category = new ObjectValue<StringObjectValue>
            {
                Value = dm.CategoryId,
                VM = new StringObjectValue
                {
                    Id = dm.CategoryId,
                    Title = dm.Category.Title,
                },
            };
        }

        public override void ToDataModel(PrintCalculator.Data.Models.Storage.SubCategory dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.CategoryId = Category.Value;
        }
    }

    
}
