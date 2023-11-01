using PrintCalculator.ViewModels.Data.PostPrint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PostPrintInterfaces
{
    public interface IPostPrintPriceServices
    {
        public Task<List<PostPrintPrice>> TakePostPrintPrices();

        public Task<PostPrintPrice> TakePostPrintPriceById(Guid id);

        public Task AddPostPrintPrice(PostPrintPrice postPrintPrice);

        public Task DeletePostPrintPrice(Guid id);

        public Task UpdatePostPrintPrice(PostPrintPrice updatedPostPrintPrice);
    }
}
