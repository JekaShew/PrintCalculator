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
    public class StorageProductServices : IStorageProductServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public StorageProductServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddStorageProduct(StorageProduct storageProduct)
        {
            var newStorageProduct = _mapper.Map<Data.Models.Storage.StorageProduct>(storageProduct);

            newStorageProduct.SubCategory = null;
            newStorageProduct.Storage = null;
            newStorageProduct.UnitMeasure = null;

            await _appDBContext.AddAsync(newStorageProduct);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task DeleteStorageProduct(Guid id)
        {
            _appDBContext.StorageProducts.Remove(await _appDBContext.StorageProducts.FirstOrDefaultAsync(sp => sp.Id == id));
            await _appDBContext.SaveChangesAsync();
        }
        public async Task<List<StorageProduct>> TakeStorageProducts()
        {
            var storageProducts = await _appDBContext.StorageProducts.AsNoTracking()
                                        .Include(sc => sc.SubCategories)
                                            .ThenInclude(c=> c.Categories)
                                        .Include(um=> um.UnitMeasures)
                                        .Include(s=> s.Storages)
                                        .ToListAsync();

            return _mapper.Map<List<StorageProduct>>(storageProducts);
        }
        public async Task<StorageProduct> TakeStorageProductById(Guid id)
        {
            var storageProduct = await _appDBContext.StorageProducts.AsNoTracking()
                                        .Include(sc=> sc.SubCategories)
                                            .ThenInclude(c=> c.Categories)
                                        .Include(s=> s.Storages)
                                        .Include(um=> um.UnitMeasures)
                                        .FirstOrDefaultAsync(sp => sp.Id == id);

            return _mapper.Map<StorageProduct>(storageProduct);
        }

        public async Task UpdateStorageProduct(StorageProduct updatedStorageProduct)
        {
            var storageProduct = await _appDBContext.StorageProducts.FirstOrDefaultAsync(sp => sp.Id == updatedStorageProduct.Id);

            storageProduct.Id = updatedStorageProduct.Id;
            storageProduct.Title = updatedStorageProduct.Title;
            storageProduct.SubCategoryId = updatedStorageProduct.SubCategory.Id;
            storageProduct.StorageId = updatedStorageProduct.Storage.Id;
            storageProduct.UnitMeasureId = updatedStorageProduct.UnitMeasure.Id;
            storageProduct.SubCategory = null;
            storageProduct.Storage = null;
            storageProduct.UnitMeasure = null;
            
            await _appDBContext.SaveChangesAsync();
        }
    }
}
