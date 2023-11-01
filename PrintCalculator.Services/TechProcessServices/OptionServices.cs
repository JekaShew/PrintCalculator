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
    public class OptionServices : IOptionServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public OptionServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddOption(Option option)
        {
            var newOption = _mapper.Map<Data.Models.TechProcess.Option>(option);

            await _appDBContext.AddAsync(newOption);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeleteOption(Guid id)
        {
            _appDBContext.Options.Remove(await _appDBContext.Options.FirstOrDefaultAsync(o => o.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<Option>> TakeOptions()
        {
            var options = _mapper.Map<List<Option>>(await _appDBContext.Options.AsNoTracking().ToListAsync());

            return options;
        }

        public async Task<Option> TakeOptionById(Guid id)
        {
            var option = _mapper.Map<Option>(await _appDBContext.Options.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id));

            return option;
        }

        public async Task UpdateOption(Option updatedOption)
        {
            var option = await _appDBContext.Options.FirstOrDefaultAsync(o => o.Id == updatedOption.Id);

            option.Id = updatedOption.Id.Value;
            option.Title = updatedOption.Title;
            option.Description = updatedOption.Description;

            await _appDBContext.SaveChangesAsync();
        }
    }
}
