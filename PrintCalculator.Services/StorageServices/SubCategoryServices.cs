using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.Abstract.Data.Storage;
using PrintCalculator.Abstract.StorageInterfaces;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Services.StorageServices
{
    public class SubCategoryServices : ISubCategoryServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public SubCategoryServices(AppDBContext appDBContext, IMapper mapper )
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddSubCategory(SubCategory subCategory)
        {
            var newSubCategory = _mapper.Map<Data.Models.Storage.SubCategory>(subCategory);
            
            newSubCategory.Category = null;

            await _appDBContext.AddAsync(newSubCategory);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task DeleteSubCategory(Guid id)
        {
            _appDBContext.SubCategories.Remove(await _appDBContext.SubCategories.FirstOrDefaultAsync(sc => sc.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<SubCategory>> TakeSubCategories()
        {
            var subCategories = await _appDBContext.SubCategories.AsNoTracking()
                                        .Include(c => c.Categories)
                                        .ToListAsync();

            return _mapper.Map<List<SubCategory>>(subCategories);
        }

        public async Task<SubCategory> TakeSubCategoryById(Guid id)
        {
            var subCategory = await _appDBContext.SubCategories.AsNoTracking()
                                        .Include(c=> c.Categories)
                                        .FirstOrDefaultAsync(sc => sc.Id == id);

            return _mapper.Map<SubCategory>(subCategory);
        }

        public async Task UpdateSubCategory(SubCategory updatedSubCategory)
        {
            var subCategory = await _appDBContext.SubCategories.FirstOrDefaultAsync(sc => sc.Id == updatedSubCategory.Id);

            subCategory.Id = updatedSubCategory.Id;
            subCategory.Title = updatedSubCategory.Title;
            subCategory.CategoryId = updatedSubCategory.Category.Id;
            subCategory.Category = null;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
