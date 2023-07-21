using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.Abstract.Data.Paper;
using PrintCalculator.Abstract.PaperInterfaces;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Services.PaperServices
{
    public class PaperCoefficientServices : IPaperCoefficientServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PaperCoefficientServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPaperCoefficient(PaperCoefficient paperCoefficient)
        {
            var newPaperCoefficient = _mapper.Map<Data.Models.Paper.PaperCoefficient>(paperCoefficient);
            newPaperCoefficient.PaperDensity = null;
            newPaperCoefficient.TechProcess = null;

            await _appDBContext.AddAsync(newPaperCoefficient);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePaperCoefficient(Guid id)
        {
            _appDBContext.PaperCoefficients.Remove(await _appDBContext.PaperCoefficients.FirstOrDefaultAsync(pc => pc.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PaperCoefficient>> TakePaperCoefficients()
        {
            var paperCoefficients = _mapper.Map<List<PaperCoefficient>>(await _appDBContext.PaperCoefficients.AsNoTracking()
                                                                                .Include(tp => tp.TechProcesses)
                                                                                .Include(pd => pd.PaperDensities)
                                                                                .ToListAsync());

            return paperCoefficients;
        }

        public async Task<PaperCoefficient> TakePaperCoefficientById(Guid id)
        {
            var paperCoefficient = _mapper.Map<PaperCoefficient>(await _appDBContext.PaperCoefficients.AsNoTracking()
                                                                        .Include(tp => tp.TechProcesses)
                                                                        .Include(pd => pd.PaperDensities)
                                                                        .FirstOrDefaultAsync(pc => pc.Id == id));

            return paperCoefficient;
        }

        public async Task UpdatePaperCoefficient(PaperCoefficient updatedPaperCoefficient)
        {
            var paperCoefficient = await _appDBContext.PaperCoefficients.FirstOrDefaultAsync(pc => pc.Id == updatedPaperCoefficient.Id);

            paperCoefficient.Id = updatedPaperCoefficient.Id;
            paperCoefficient.Title = updatedPaperCoefficient.Title;
            paperCoefficient.Coefficient = updatedPaperCoefficient.Coefficient;
            paperCoefficient.TechProcessId = updatedPaperCoefficient.TechProcess.Id;
            paperCoefficient.PaperDensityId = updatedPaperCoefficient.PaperDensity.Id;

            paperCoefficient.TechProcess = null;
            paperCoefficient.PaperDensity = null;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
