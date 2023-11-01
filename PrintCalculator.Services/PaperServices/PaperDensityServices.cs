using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.ViewModels.Data.Paper;
using PrintCalculator.Abstract.PaperInterfaces;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Services.PaperServices
{
    public class PaperDensityServices : IPaperDensityServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PaperDensityServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPaperDensity(PaperDensity paperDensity)
        {
            var newPaperDensity = _mapper.Map<Data.Models.Paper.PaperDensity>(paperDensity);

            await _appDBContext.AddAsync(newPaperDensity);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePaperDensity(Guid id)
        {
            _appDBContext.PaperDensities.Remove(await _appDBContext.PaperDensities.FirstOrDefaultAsync(pd => pd.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PaperDensity>> TakePaperDensities()
        {
            var paperDensities = _mapper.Map<List<PaperDensity>>(await _appDBContext.PaperDensities.AsNoTracking().ToListAsync());

            return paperDensities;
        }

        public async Task<PaperDensity> TakePaperDensityById(Guid id)
        {
            var paperDensity = _mapper.Map<PaperDensity>(await _appDBContext.PaperDensities.AsNoTracking().FirstOrDefaultAsync(pd => pd.Id == id));

            return paperDensity;
        }

        public async Task UpdatePaperDensity(PaperDensity updatedPaperDensity)
        {
            var paperDensity = await _appDBContext.PaperDensities.FirstOrDefaultAsync(pd => pd.Id == updatedPaperDensity.Id);

            paperDensity.Id = updatedPaperDensity.Id.Value;
            paperDensity.Density = updatedPaperDensity.Density;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
