using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.Abstract.Data.TechProcess;
using PrintCalculator.Abstract.TechProcessInterfaces;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Services.TechProcessServices
{
    public class PrintTypeServices : IPrintTypeServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PrintTypeServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPrintType(PrintType printType)
        {
            var newPrintType = _mapper.Map<Data.Models.TechProcess.PrintType>(printType);

            await _appDBContext.AddAsync(newPrintType);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePrintType(Guid id)
        {
            _appDBContext.PrintTypes.Remove(await _appDBContext.PrintTypes.FirstOrDefaultAsync(pt => pt.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PrintType>> TakePrintTypes()
        {
            var printTypes = _mapper.Map<List<PrintType>>(await _appDBContext.PrintTypes.AsNoTracking().ToListAsync());

            return printTypes;
        }

        public async Task<PrintType> TakePrintTypeById(Guid id)
        {
            var printType = _mapper.Map<PrintType>(await _appDBContext.PrintTypes.AsNoTracking().FirstOrDefaultAsync(pt => pt.Id == id));

            return printType;
        }

        public async Task UpdatePrintType(PrintType updatedPrintType)
        {
            var printType = await _appDBContext.PrintTypes.FirstOrDefaultAsync(pt => pt.Id == updatedPrintType.Id);

            printType.Id = updatedPrintType.Id;
            printType.Title = updatedPrintType.Title;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
