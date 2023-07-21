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
    public class PaperPriceGroupServices : IPaperPriceGroupServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PaperPriceGroupServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPaperPriceGroup(PaperPriceGroup paperPriceGroup)
        {
            var newPaperPriceGroup = _mapper.Map<Data.Models.Paper.PaperPriceGroup>(paperPriceGroup);
            newPaperPriceGroup.PaperClass = null;

            await _appDBContext.AddAsync(newPaperPriceGroup);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePaperPriceGroup(Guid id)
        {
            _appDBContext.PaperPriceGroups.Remove(await _appDBContext.PaperPriceGroups.FirstOrDefaultAsync(ppg => ppg.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PaperPriceGroup>> TakePaperPriceGroups()
        {
            var paperPriceGroups = _mapper.Map<List<PaperPriceGroup>>(await _appDBContext.PaperPriceGroups.AsNoTracking()
                                                                            .Include(pc => pc.PaperClasses)
                                                                            .ToListAsync());

            return paperPriceGroups;
        }

        public async Task<PaperPriceGroup> TakePaperPriceGroupById(Guid id)
        {
            var paperPriceGroup = _mapper.Map<PaperPriceGroup>(await _appDBContext.PaperPriceGroups.AsNoTracking()
                                                                        .Include(pc => pc.PaperClasses)
                                                                        .FirstOrDefaultAsync(ppg => ppg.Id == id));

            return paperPriceGroup;
        }

        public async Task UpdatePaperPriceGroup(PaperPriceGroup updatedPaperPriceGroup)
        {
            var paperPriceGroup = await _appDBContext.PaperPriceGroups.FirstOrDefaultAsync(ppg => ppg.Id == updatedPaperPriceGroup.Id);

            paperPriceGroup.Id = updatedPaperPriceGroup.Id;
            paperPriceGroup.Title = updatedPaperPriceGroup.Title;
            paperPriceGroup.PricePerKg = updatedPaperPriceGroup.PricePerKg;
            paperPriceGroup.MarkupMaxAmount = updatedPaperPriceGroup.MarkupMaxAmount;
            paperPriceGroup.MarkupMaxCoefficient = updatedPaperPriceGroup.MarkupMaxCoefficient;
            paperPriceGroup.MarkupMinAmount = updatedPaperPriceGroup.MarkupMinAmount;
            paperPriceGroup.MarkupMinCoefficient = updatedPaperPriceGroup.MarkupMinCoefficient;
            paperPriceGroup.PaperClassId = updatedPaperPriceGroup.PaperClass.Id;
            paperPriceGroup.PaperClass = null;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
