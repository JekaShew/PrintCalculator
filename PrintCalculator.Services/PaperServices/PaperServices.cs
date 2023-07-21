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
    public class PaperServices : IPaperServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PaperServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPaper(Paper paper)
        {
            var newPaper = _mapper.Map<Data.Models.Paper.Paper>(paper);
            newPaper.PaperType = null;
            newPaper.PaperPriceGroup = null;
            newPaper.PaperDensity = null;
            newPaper.PaperSize = null;

            await _appDBContext.AddAsync(newPaper);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePaper(Guid id)
        {
            _appDBContext.Papers.Remove(await _appDBContext.Papers.FirstOrDefaultAsync(p => p.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<Paper>> TakePapers()
        {
            var papers = _mapper.Map<List<Paper>>(await _appDBContext.Papers.AsNoTracking()
                                                            .Include(pt => pt.PaperTypes)
                                                            .Include(ppg => ppg.PaperPriceGroups)
                                                            .Include(pd => pd.PaperDensities)
                                                            .Include(ps => ps.PaperSizes)
                                                            .ToListAsync());

            return papers;
        }

        public async Task<Paper> TakePaperById(Guid id)
        {
            var paper = _mapper.Map<Paper>(await _appDBContext.Papers.AsNoTracking()
                                                    .Include(pt => pt.PaperTypes)
                                                    .Include(ppg => ppg.PaperPriceGroups)
                                                    .Include(pd => pd.PaperDensities)
                                                    .Include(ps => ps.PaperSizes)
                                                    .FirstOrDefaultAsync(p => p.Id == id));

            return paper;
        }

        public async Task UpdatePaper(Paper updatedPaper)
        {
            var paper = await _appDBContext.Papers.FirstOrDefaultAsync(p => p.Id == updatedPaper.Id);

            paper.Id = updatedPaper.Id;
            paper.Title = updatedPaper.Title;
            paper.TitleOnStorage = updatedPaper.TitleOnStorage;
            paper.Price = updatedPaper.Price;
            paper.MarkupMaxAmount = updatedPaper.MarkupMaxAmount;
            paper.MarkupMaxAmountCoefficient = updatedPaper.MarkupMaxAmountCoefficient;
            paper.MarkupMinAmount = updatedPaper.MarkupMinAmount;
            paper.MarkupMinAmountCoefficient = updatedPaper.MarkupMinAmountCoefficient;
            paper.PriceKg = updatedPaper.PriceKg;
            paper.SuspendedSupply = updatedPaper.SuspendedSupply;

            paper.PaperTypeId = updatedPaper.PaperType.Id;
            paper.PaperPriceGroupId = updatedPaper.PaperPriceGroup.Id;
            paper.PaperDensityId = updatedPaper.PaperDensity.Id;
            paper.PaperSizeId = updatedPaper.PaperSize.Id;

            paper.PaperType = null;
            paper.PaperPriceGroup = null;
            paper.PaperDensity = null;
            paper.PaperSize = null;
            
            await _appDBContext.SaveChangesAsync();
        }
    }
}
