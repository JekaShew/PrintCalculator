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
    public class PaperTypeServices : IPaperTypeServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PaperTypeServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPaperType(PaperType paperType)
        {
            var newPaperType = _mapper.Map<Data.Models.Paper.PaperType>(paperType);
            newPaperType.PaperDensity = null;
            newPaperType.PaperClass = null;
            newPaperType.PaperPriceGroup = null;

            await _appDBContext.AddAsync(newPaperType);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePaperType(Guid id)
        {
            _appDBContext.PaperTypes.Remove(await _appDBContext.PaperTypes.FirstOrDefaultAsync(pt => pt.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PaperType>> TakePaperTypes()
        {
            var paperTypes = _mapper.Map<List<PaperType>>(await _appDBContext.PaperTypes.AsNoTracking()
                                                                    .Include(pd => pd.PaperDensities)
                                                                    .Include(pc => pc.PaperClasses)
                                                                    .Include(ppg => ppg.PaperPriceGroups)
                                                                    .ToListAsync());

            return paperTypes;
        }

        public async Task<PaperType> TakePaperTypeById(Guid id)
        {
            var paperType = _mapper.Map<PaperType>(await _appDBContext.PaperTypes.AsNoTracking()
                                                                .Include(pd => pd.PaperDensities)
                                                                .Include(pc => pc.PaperClasses)
                                                                .Include(ppg => ppg.PaperPriceGroups)
                                                                .FirstOrDefaultAsync(pt => pt.Id == id));

            return paperType;
        }

        public async Task UpdatePaperType(PaperType updatedPaperType)
        {
            var paperType = await _appDBContext.PaperTypes.FirstOrDefaultAsync(pt => pt.Id == updatedPaperType.Id);

            paperType.Id = updatedPaperType.Id.Value;
            paperType.Title = updatedPaperType.Title;
            paperType.Width = updatedPaperType.Width;
            paperType.OneSided = updatedPaperType.OneSided;
            paperType.MinMarkUpPurchasePrice = updatedPaperType.MinMarkUpPurchasePrice;
            paperType.MarkupMaxAmount = updatedPaperType.MarkupMaxAmount;
            paperType.MarkupMaxAmountCoefficient = updatedPaperType.MarkupMaxAmountCoefficient;
            paperType.MarkupMinAmount = updatedPaperType.MarkupMinAmount;
            paperType.MarkupMinAmountCoefficient = updatedPaperType.MarkupMinAmountCoefficient;

            paperType.PaperDensityId = updatedPaperType.PaperDensity.VM.Id.Value;
            paperType.PaperClassId = updatedPaperType.PaperClass.VM.Id.Value;
            paperType.PaperPriceGroupId = updatedPaperType.PaperPriceGroup.VM.Id.Value;

            paperType.PaperDensity = null;
            paperType.PaperClass = null;
            paperType.PaperPriceGroup = null;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
