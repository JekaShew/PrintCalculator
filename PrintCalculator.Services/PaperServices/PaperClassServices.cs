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
    public class PaperClassServices : IPaperClassServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PaperClassServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPaperClass(PaperClass paperClass)
        {
            var newPaperClass = _mapper.Map<Data.Models.Paper.PaperClass>(paperClass);

            await _appDBContext.AddAsync(newPaperClass);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePaperClass(Guid id)
        {
            _appDBContext.PaperClasses.Remove(await _appDBContext.PaperClasses.FirstOrDefaultAsync(pc => pc.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PaperClass>> TakePaperClasses()
        {
            var paperClasses = _mapper.Map<List<PaperClass>>(await _appDBContext.PaperClasses.AsNoTracking().ToListAsync());

            return paperClasses;
        }

        public async Task<PaperClass> TakePaperClassById(Guid id)
        {
            var paperClass = _mapper.Map<PaperClass>(await _appDBContext.PaperClasses.AsNoTracking().FirstOrDefaultAsync(pc => pc.Id == id));

            return paperClass;
        }

        public async Task UpdatePaperClass(PaperClass updatedPaperClass)
        {
            var paperClass = await _appDBContext.PaperClasses.FirstOrDefaultAsync(pc => pc.Id == updatedPaperClass.Id);

            paperClass.Id = updatedPaperClass.Id.Value;
            paperClass.Title = updatedPaperClass.Title;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
