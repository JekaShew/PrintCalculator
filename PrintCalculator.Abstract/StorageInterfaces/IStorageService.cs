using PrintCalculator.Abstract.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.StorageInterfaces
{
    public interface IStorageServices
    {

        public Task<List<Storage>> TakeStorages();

        public Task<Storage> TakeStorageById(Guid id);

        public Task AddStorage(Storage storage);

        public Task DeleteStorage(Guid id);

        public Task UpdateStorage(Storage updatedStorage);

    }
}
