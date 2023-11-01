using PrintCalculator.ViewModels.Data.Paper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PaperInterfaces
{
    public interface  IPaperPriceGroupServices
    {
        public Task<List<PaperPriceGroup>> TakePaperPriceGroups();

        public Task<PaperPriceGroup> TakePaperPriceGroupById(Guid id);

        public Task AddPaperPriceGroup(PaperPriceGroup paperPriceGroup);

        public Task DeletePaperPriceGroup(Guid id);

        public Task UpdatePaperPriceGroup(PaperPriceGroup updatedPaperPriceGroup);
    }
}
