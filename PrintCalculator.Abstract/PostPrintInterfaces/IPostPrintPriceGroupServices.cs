using PrintCalculator.ViewModels.Data.PostPrint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PostPrintInterfaces
{
    public interface IPostPrintPriceGroupServices
    {
        public Task<List<PostPrintPriceGroup>> TakePostPrintPriceGroups();

        public Task<PostPrintPriceGroup> TakePostPrintPriceGroupById(Guid id);

        public Task AddPostPrintPriceGroup(PostPrintPriceGroup postPrintPriceGroup);

        public Task DeletePostPrintPriceGroup(Guid id);

        public Task UpdatePostPrintPriceGroup(PostPrintPriceGroup updatedPostPrintPriceGroup);
    }
}
