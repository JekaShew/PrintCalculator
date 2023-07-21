using PrintCalculator.Abstract.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.StorageInterfaces
{
    public interface ISubCategoryServices
    {
        public Task<List<SubCategory>> TakeSubCategories();

        public Task<SubCategory> TakeSubCategoryById(Guid id);

        public Task AddSubCategory(SubCategory subCategory);

        public Task DeleteSubCategory(Guid id);

        public Task UpdateSubCategory(SubCategory updatedSubCategory);
    }
}
