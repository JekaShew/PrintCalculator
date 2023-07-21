using PrintCalculator.Abstract.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PaperInterfaces
{
    public interface IPaperServices
    {
        public Task<List<Paper>> TakePapers();

        public Task<Paper> TakePaperById(Guid id);

        public Task AddPaper(Paper paper);

        public Task DeletePaper(Guid id);

        public Task UpdatePaper(Paper updatedPaper);
    }
}
