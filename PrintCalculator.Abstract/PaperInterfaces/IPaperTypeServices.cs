using PrintCalculator.Abstract.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PaperInterfaces
{
    public interface IPaperTypeServices
    {
        public Task<List<PaperType>> TakePaperTypes();

        public Task<PaperType> TakePaperTypeById(Guid id);

        public Task AddPaperType(PaperType paperType);

        public Task DeletePaperType(Guid id);

        public Task UpdatePaperType(PaperType updatedPaperType);
    }
}
