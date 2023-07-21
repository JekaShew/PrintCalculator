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
    public class PaperSizeServices : IPaperSizeServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PaperSizeServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPaperSize(PaperSize paperSize)
        {
            var newPaperSize = _mapper.Map<Data.Models.Paper.PaperSize>(paperSize);

            await _appDBContext.AddAsync(newPaperSize);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePaperSize(Guid id)
        {
            _appDBContext.PaperSizes.Remove(await _appDBContext.PaperSizes.FirstOrDefaultAsync(ps => ps.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PaperSize>> TakePaperSizes()
        {
            var paperSizes = _mapper.Map<List<PaperSize>>(await _appDBContext.PaperSizes.AsNoTracking().ToListAsync());

            return paperSizes;
        }

        public async Task<PaperSize> TakePaperSizeById(Guid id)
        {
            var paperSize = _mapper.Map<PaperSize>(await _appDBContext.PaperSizes.AsNoTracking().FirstOrDefaultAsync(ps => ps.Id == id));

            return paperSize;
        }

        public async Task UpdatePaperSize(PaperSize updatedPaperSize)
        {
            var paperSize = await _appDBContext.PaperSizes.FirstOrDefaultAsync(ps => ps.Id == updatedPaperSize.Id);

            paperSize.Id = updatedPaperSize.Id;
            paperSize.Title = updatedPaperSize.Title;
            paperSize.Height = updatedPaperSize.Height;
            paperSize.Width = updatedPaperSize.Width;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
