using PrintCalculator.Abstract.Data.PostPrint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PostPrintInterfaces
{
    public interface IPostPrintOperationServices
    {
        public Task<List<PostPrintOperation>> TakePostPrintOperations();

        public Task<PostPrintOperation> TakePostPrintOperationById(Guid id);

        public Task AddPostPrintOperation(PostPrintOperation postPrintOperation);

        public Task DeletePostPrintOperation(Guid id);

        public Task UpdatePostPrintOperation(PostPrintOperation updatedPostPrintOperation);
    }
}
