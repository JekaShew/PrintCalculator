using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.ViewModels.Data.PostPrint;
using PrintCalculator.Abstract.PostPrintInterfaces;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Services.PostPrintServices
{
    public class PackagingTypeServices : IPackagingTypeServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PackagingTypeServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPackagingType(PackagingType packagingType)
        {
            var newPackagingType = _mapper.Map<Data.Models.PostPrint.PackagingType>(packagingType);

            await _appDBContext.AddAsync(newPackagingType);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePackagingType(Guid id)
        {
            _appDBContext.PackagingTypes.Remove(await _appDBContext.PackagingTypes.FirstOrDefaultAsync(pt => pt.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PackagingType>> TakePackagingTypes()
        {
            var packagingTypes = _mapper.Map<List<PackagingType>>(await _appDBContext.PackagingTypes.AsNoTracking().ToListAsync());

            return packagingTypes;
        }

        public async Task<PackagingType> TakePackagingTypeById(Guid id)
        {
            var packagingType = _mapper.Map<PackagingType>(await _appDBContext.PackagingTypes.AsNoTracking().FirstOrDefaultAsync(pt => pt.Id == id));

            return packagingType;
        }

        public async Task UpdatePackagingType(PackagingType updatedPackagingType)
        {
            var packagingType = await _appDBContext.PackagingTypes.FirstOrDefaultAsync(pt => pt.Id == updatedPackagingType.Id);

            packagingType.Id = updatedPackagingType.Id.Value;
            packagingType.Title = updatedPackagingType.Title;
            packagingType.PreparationPrice = updatedPackagingType.PreparationPrice;
            packagingType.PerPackPrice = updatedPackagingType.PerPackPrice;
            packagingType.PreparationCostPrice = updatedPackagingType.PreparationCostPrice;
            packagingType.PerPackCostPrice = updatedPackagingType.PerPackCostPrice;
            packagingType.PreparationTime = updatedPackagingType.PreparationTime;
            packagingType.PerPackTime = updatedPackagingType.PerPackTime;

            await _appDBContext.SaveChangesAsync();
        }

    }
}
