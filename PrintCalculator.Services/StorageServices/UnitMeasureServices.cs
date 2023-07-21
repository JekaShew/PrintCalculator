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
    public class UnitMeasureServices : IUnitMeasureServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public UnitMeasureServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddUnitMeasure(UnitMeasure unitMeasure)
        {
            var newUnitMeasure = _mapper.Map<Data.Models.Storage.UnitMeasure>(unitMeasure);

            await _appDBContext.AddAsync(newUnitMeasure);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task DeleteUnitMeasure(Guid id)
        {
            _appDBContext.UnitMeasures.Remove(await _appDBContext.UnitMeasures.FirstOrDefaultAsync(um => um.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<UnitMeasure>> TakeUnitMeasures()
        {
            var unitMeasures = _mapper.Map<List<UnitMeasure>>(await _appDBContext.UnitMeasures.AsNoTracking().ToListAsync());

            return unitMeasures;
        }
        public async Task<UnitMeasure> TakeUnitMeasureById(Guid id)
        {
            var unitMeasure = _mapper.Map<UnitMeasure>(await _appDBContext.UnitMeasures.AsNoTracking().FirstOrDefaultAsync(um => um.Id == id));

            return unitMeasure;
        }
        public async Task UpdateUnitMeasure(UnitMeasure updatedUnitMeasure)
        {
            var unitMeasure = await _appDBContext.UnitMeasures.FirstOrDefaultAsync(um => um.Id == updatedUnitMeasure.Id);

            unitMeasure.Id = updatedUnitMeasure.Id;
            unitMeasure.Title = updatedUnitMeasure.Title;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
