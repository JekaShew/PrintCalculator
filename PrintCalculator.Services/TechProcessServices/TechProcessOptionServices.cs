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
    public class TechProcessOptionServices : ITechProcessOptionServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public TechProcessOptionServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddTechProcessOption(TechProcessOption techProcessOption)
        {
            var newTechProcessOption = _mapper.Map<Data.Models.TechProcess.TechProcessOption>(techProcessOption);

            newTechProcessOption.Option = null;
            newTechProcessOption.TechProcess = null;

            await _appDBContext.AddAsync(newTechProcessOption);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeleteTechProcessOption(Guid id)
        {
            _appDBContext.TechProcessOptions.Remove(await _appDBContext.TechProcessOptions.FirstOrDefaultAsync(tpo => tpo.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<TechProcessOption>> TakeTechProcessOptions()
        {
            var techProcessOptions = _mapper.Map<List<TechProcessOption>>(await _appDBContext.TechProcessOptions.AsNoTracking()
                
                                                                                    .Include(tpo => tpo.TechProcess)
                                                                                   .ToListAsync());

            return techProcessOptions;
        }

        public async Task<TechProcessOption> TakeTechProcessOptionById(Guid id)
        {
            var techProcessOption = _mapper.Map<TechProcessOption>(await _appDBContext.TechProcessOptions.AsNoTracking()
                                                                            .Include(tpo => tpo.TechProcess)
                                                                            .FirstOrDefaultAsync(tpo => tpo.Id == id));
            return techProcessOption;
        }

        public async Task UpdateTechProcessOption(TechProcessOption updatedTechProcessOption)
        {
            var techProcessOption = await _appDBContext.TechProcessOptions.FirstOrDefaultAsync(tpo => tpo.Id == updatedTechProcessOption.Id);

            techProcessOption.Id = updatedTechProcessOption.Id.Value;
            techProcessOption.OptionId = updatedTechProcessOption.Option.VM.Id.Value;
            techProcessOption.TechProcessId = updatedTechProcessOption.TechProcess.VM.Id.Value;
            techProcessOption.Option = null;
            techProcessOption.TechProcess = null;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
