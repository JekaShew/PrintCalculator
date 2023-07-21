using PrintCalculator.Abstract.Data.TechProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.TechProcessInterfaces
{
    public interface IOptionServices
    {
        public Task<List<Option>> TakeOptions();

        public Task<Option> TakeOptionById(Guid id);

        public Task AddOption(Option option);

        public Task DeleteOption(Guid id);

        public Task UpdateOption(Option updatedOption);
    }
}
