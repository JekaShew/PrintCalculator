using PrintCalculator.ViewModels.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PaperInterfaces
{
    public interface IPaperCoefficientServices
    {
        public Task<List<PaperCoefficient>> TakePaperCoefficients();

        public Task<PaperCoefficient> TakePaperCoefficientById(Guid id);

        public Task AddPaperCoefficient(PaperCoefficient paperCoefficient);

        public Task DeletePaperCoefficient(Guid id);

        public Task UpdatePaperCoefficient(PaperCoefficient updatedPaperCoefficient);
    }
}
