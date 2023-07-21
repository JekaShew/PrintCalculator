using PrintCalculator.Abstract.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.StorageInterfaces
{
    public interface ICategoryServices
    {
        public Task<List<Category>> TakeCategories();

        public Task<Category> TakeCategoryById(Guid id);

        public Task AddCategory(Category category);

        public Task DeleteCategory(Guid id);

        public Task UpdateCategory(Category updatedCategory);
    }
}
