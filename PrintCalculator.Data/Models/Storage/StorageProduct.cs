using PrintCalculator.UI.Gen2.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data.Models.Storage
{
    public class StorageProduct : Model
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public float AmountPackages { get; set; }
        public int Amount { get; set; }
        public Guid UnitMeasureId { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid StorageId { get; set; }
        public UnitMeasure UnitMeasure { get; set; }
        public SubCategory SubCategory { get; set; }
        public Storage Storage { get; set; }


        public List<UnitMeasure> UnitMeasures { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Storage> Storages { get; set; }
    }
}
