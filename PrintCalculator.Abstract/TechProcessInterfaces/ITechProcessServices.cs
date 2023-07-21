using PrintCalculator.Abstract.Data.TechProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.TechProcessInterfaces
{
    public interface  ITechProcessServices
    {
        public Task<List<TechProcess>> TakeTechProcesses();

        public Task<TechProcess> TakeTechProcessById(Guid id);

        public Task AddTechProcess(TechProcess techProcess);

        public Task DeleteTechProcess(Guid id);

        public Task UpdateTechProcess(TechProcess updatedTechProcess);
    }
}
