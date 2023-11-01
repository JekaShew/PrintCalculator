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
    public class PaperFormatServices : IPaperFormatServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PaperFormatServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPaperFormat(PaperFormat paperFormat)
        {
            var newPaperFormat = _mapper.Map<Data.Models.Paper.PaperFormat>(paperFormat);
            newPaperFormat.PaperSize = null;

            await _appDBContext.AddAsync(newPaperFormat);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePaperFormat(Guid id)
        {
            _appDBContext.PaperFormats.Remove(await _appDBContext.PaperFormats.FirstOrDefaultAsync(pf => pf.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PaperFormat>> TakePaperFormats()
        {
            var paperFormats = _mapper.Map<List<PaperFormat>>(await _appDBContext.PaperFormats.AsNoTracking()
                                                                    .Include(ps => ps.PaperSizes)
                                                                    .ToListAsync());

            return paperFormats;
        }

        public async Task<PaperFormat> TakePaperFormatById(Guid id)
        {
            var paperFormat = _mapper.Map<PaperFormat>(await _appDBContext.PaperFormats.AsNoTracking()
                                                                .Include(ps => ps.PaperSizes)
                                                                .FirstOrDefaultAsync(pf => pf.Id == id));

            return paperFormat;
        }

        public async Task UpdatePaperFormat(PaperFormat updatedPaperFormat)
        {
            var paperFormat = await _appDBContext.PaperFormats.FirstOrDefaultAsync(pf => pf.Id == updatedPaperFormat.Id);

            paperFormat.Id = updatedPaperFormat.Id.Value;
            paperFormat.Title = updatedPaperFormat.Title;

            paperFormat.PaperSizeId = updatedPaperFormat.PaperSize.VM.Id.Value;
            paperFormat.PaperSize = null;

            await _appDBContext.SaveChangesAsync();
        }  
    }
}
