using PrintCalculator.ViewModels.Data.PostPrint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PostPrintInterfaces
{
    public interface IPostPrintGroupServices
    {
        public Task<List<PostPrintGroup>> TakePostPrintGroups();

        public Task<PostPrintGroup> TakePostPrintGroupById(Guid id);

        public Task AddPostPrintGroup(PostPrintGroup postPrintGroup);

        public Task DeletePostPrintGroup(Guid id);

        public Task UpdatePostPrintGroup(PostPrintGroup updatedPostPrintGroup);
    }
}
