using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.Storage
{
    public class StorageProduct : TableModelAutoMapped<PrintCalculator.Data.Models.Storage.StorageProduct>
    {
        public string Title { get; set; }
        public float AmountPackages { get; set; }
        public int Amount { get; set; }
        public Guid UnitMeasureId { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid StorageId { get; set; }

        public string UnitMeasure { get; set; }
        public string SubCategory { get; set; }
        public string Storage { get; set; }

        public List<UnitMeasure> UnitMeasures { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Storage> Storages { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Storage.StorageProduct dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            UnitMeasure = dm.UnitMeasure.Title;
            SubCategory = dm.SubCategory.Title;
            Storage = dm.Storage.Title;

        }
    }
}
