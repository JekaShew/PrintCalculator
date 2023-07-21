using PrintCalculator.Abstract.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PaperInterfaces
{
    public interface IPaperFormatServices
    {
        public Task<List<PaperFormat>> TakePaperFormats();

        public Task<PaperFormat> TakePaperFormatById(Guid id);

        public Task AddPaperFormat(PaperFormat paperFormat);

        public Task DeletePaperFormat(Guid id);

        public Task UpdatePaperFormat(PaperFormat updatedPaperFormat);
    }
}
