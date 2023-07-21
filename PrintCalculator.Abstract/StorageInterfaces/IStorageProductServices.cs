using PrintCalculator.Abstract.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.StorageInterfaces
{
    public interface IStorageProductServices
    {
        public Task<List<StorageProduct>> TakeStorageProducts();

        public Task<StorageProduct> TakeStorageProductById(Guid id);

        public Task AddStorageProduct(StorageProduct storageProduct);

        public Task DeleteStorageProduct(Guid id);

        public Task UpdateStorageProduct(StorageProduct updatedStorageProduct);
    }
}
