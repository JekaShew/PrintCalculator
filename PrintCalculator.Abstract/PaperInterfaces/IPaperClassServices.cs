using PrintCalculator.ViewModels.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PaperInterfaces
{
    public interface IPaperClassServices
    {
        public Task<List<PaperClass>> TakePaperClasses();

        public Task<PaperClass> TakePaperClassById(Guid id);

        public Task AddPaperClass(PaperClass paperClass);

        public Task DeletePaperClass(Guid id);

        public Task UpdatePaperClass(PaperClass updatedPaperClass);
    }
}
