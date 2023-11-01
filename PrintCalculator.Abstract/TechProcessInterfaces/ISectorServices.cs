using PrintCalculator.ViewModels.Data.TechProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.TechProcessInterfaces
{
    public interface ISectorServices
    {
        public Task<List<Sector>> TakeSectors();

        public Task<Sector> TakeSectorById(Guid id);

        public Task AddSector(Sector sector);

        public Task DeleteSector(Guid id);

        public Task UpdateSector(Sector updatedSector);
    }
}
