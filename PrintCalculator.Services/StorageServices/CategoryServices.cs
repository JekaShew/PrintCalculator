using Microsoft.EntityFrameworkCore;
using PrintCalculator.ViewModels.Data.Storage;
using PrintCalculator.Abstract.StorageInterfaces;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Services.StorageServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public CategoryServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }
        
        public async Task AddCategory(Category category)
        {
            var newCategory = _mapper.Map<Data.Models.Storage.Category>(category);
            
            await _appDBContext.AddAsync(newCategory);
            await _appDBContext.SaveChangesAsync();
            
        }   
        public async Task DeleteCategory(Guid id)
        {
            _appDBContext.Categories.Remove(await _appDBContext.Categories.FirstOrDefaultAsync(c=> c.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<Category>> TakeCategories()
        {
            var categories =  _mapper.Map<List<Category>>(await _appDBContext.Categories.AsNoTracking().ToListAsync());

            return categories;
        }

        public async Task<Category> TakeCategoryById(Guid id)
        {
            var category = _mapper.Map<Category>(await _appDBContext.Categories.AsNoTracking().FirstOrDefaultAsync(c=> c.Id == id));

            return category;
        }

        public async Task UpdateCategory(Category updatedCategory)
        {
            var category = await _appDBContext.Categories.FirstOrDefaultAsync(c=> c.Id == updatedCategory.Id);

            category.Id = updatedCategory.Id.Value;
            category.Title = updatedCategory.Title;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
