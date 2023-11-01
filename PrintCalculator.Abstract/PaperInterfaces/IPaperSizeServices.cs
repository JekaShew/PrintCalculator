using PrintCalculator.ViewModels.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PaperInterfaces
{
    public interface IPaperSizeServices
    {
        public Task<List<PaperSize>> TakePaperSizes();

        public Task<PaperSize> TakePaperSizeById(Guid id);

        public Task AddPaperSize(PaperSize paperSize);

        public Task DeletePaperSize(Guid id);

        public Task UpdatePaperSize(PaperSize updatedPaperSize);
    }
}
