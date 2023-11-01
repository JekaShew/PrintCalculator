using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.ViewModels.Data.TechProcess;
using PrintCalculator.Abstract.TechProcessInterfaces;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Services.TechProcessServices
{
    public class SectorServices : ISectorServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public SectorServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddSector(Sector sector)
        {
            var newSector = _mapper.Map<Data.Models.TechProcess.Sector>(sector);

            await _appDBContext.AddAsync(newSector);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeleteSector(Guid id)
        {
            _appDBContext.Sectors.Remove(await _appDBContext.Sectors.FirstOrDefaultAsync(s => s.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<Sector>> TakeSectors()
        {
            var sectors = _mapper.Map<List<Sector>>(await _appDBContext.Sectors.AsNoTracking().ToListAsync());

            return sectors;
        }

        public async Task<Sector> TakeSectorById(Guid id)
        {
            var sector = _mapper.Map<Sector>(await _appDBContext.Sectors.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id));

            return sector;
        }

        public async Task UpdateSector(Sector updatedSector)
        {
            var sector = await _appDBContext.Sectors.FirstOrDefaultAsync(s => s.Id == updatedSector.Id);

            sector.Id = updatedSector.Id.Value;
            sector.Title = updatedSector.Title;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
