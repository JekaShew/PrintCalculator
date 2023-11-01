using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.ViewModels.Data.Storage;
using PrintCalculator.Abstract.StorageInterfaces;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Services.StorageServices
{
   public class StorageServices : IStorageServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public StorageServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddStorage(Storage storage)
        {
            var newStorage = _mapper.Map<Data.Models.Storage.Storage>(storage);
              
            await _appDBContext.AddAsync(newStorage);
            await _appDBContext.SaveChangesAsync();
        }
        public async Task DeleteStorage(Guid id)
        {
            _appDBContext.Storages.Remove(await _appDBContext.Storages.FirstOrDefaultAsync(s => s.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<Storage>> TakeStorages()
        {
            var storages = _mapper.Map<List<Storage>>(await _appDBContext.Storages.AsNoTracking().ToListAsync());

            return storages;
        }
        public async Task<Storage> TakeStorageById(Guid id)
        {
            var storage = _mapper.Map<Storage>(await _appDBContext.Storages.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id));

            return storage;
        }
        public async Task UpdateStorage(Storage updatedStorage)
        {
            var storage = await _appDBContext.Storages.FirstOrDefaultAsync(s => s.Id == updatedStorage.Id);

            storage.Id = updatedStorage.Id.Value;
            storage.Title = updatedStorage.Title;
            storage.Description = updatedStorage.Description;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
