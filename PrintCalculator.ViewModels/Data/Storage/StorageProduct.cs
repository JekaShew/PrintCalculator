using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.Storage
{
    public class StorageProduct : IdViewModel<PrintCalculator.Data.Models.Storage.StorageProduct>
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public float AmountPackages { get; set; }
        public int Amount { get; set; }
        public Guid UnitMeasureId { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid StorageId { get; set; }

        public ObjectValue<StringObjectValue> UnitMeasure { get; set; }
        public ObjectValue<StringObjectValue> SubCategory { get; set; }
        public ObjectValue<StringObjectValue> Storage { get; set; }
       
        public List<UnitMeasure> UnitMeasures { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Storage> Storages { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.Storage.StorageProduct dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            UnitMeasure = new ObjectValue<StringObjectValue>
            {
                Value = dm.UnitMeasureId,
                VM = new StringObjectValue
                {
                    Id = dm.UnitMeasureId,
                    Title = dm.UnitMeasure.Title,
                },
            };

            SubCategory = new ObjectValue<StringObjectValue>
            {
                Value = dm.SubCategoryId,
                VM = new StringObjectValue
                {
                    Id = dm.SubCategoryId,
                    Title = dm.SubCategory.Title,
                },
            };

            Storage = new ObjectValue<StringObjectValue>
            {
                Value = dm.StorageId,
                VM = new StringObjectValue
                {
                    Id = dm.StorageId,
                    Title = dm.Storage.Title,
                },
            };

        }

        public override void ToDataModel(PrintCalculator.Data.Models.Storage.StorageProduct dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.UnitMeasureId = UnitMeasure.Value;
            dm.SubCategoryId = SubCategory.Value;
            dm.StorageId = Storage.Value;
        }
    }

    
}
