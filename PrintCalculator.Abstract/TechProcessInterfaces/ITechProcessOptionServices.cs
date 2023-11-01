using PrintCalculator.ViewModels.Data.TechProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.TechProcessInterfaces
{
    public interface ITechProcessOptionServices
    {
        public Task<List<TechProcessOption>> TakeTechProcessOptions();
        public Task<TechProcessOption> TakeTechProcessOptionById(Guid id);
        public Task AddTechProcessOption(TechProcessOption techProcessOption);
        public Task DeleteTechProcessOption(Guid id);
        public Task UpdateTechProcessOption(TechProcessOption updatedTechProcessOption);
    }
}
