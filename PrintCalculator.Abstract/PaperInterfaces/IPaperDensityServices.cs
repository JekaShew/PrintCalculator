using PrintCalculator.ViewModels.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PaperInterfaces
{
    public interface IPaperDensityServices
    {
        public Task<List<PaperDensity>> TakePaperDensities();

        public Task<PaperDensity> TakePaperDensityById(Guid id);

        public Task AddPaperDensity(PaperDensity paperDensity);

        public Task DeletePaperDensity(Guid id);

        public Task UpdatePaperDensity(PaperDensity updatedPaperDensity);
    }
}
