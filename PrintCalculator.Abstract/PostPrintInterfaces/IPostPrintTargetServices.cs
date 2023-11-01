using PrintCalculator.ViewModels.Data.PostPrint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PostPrintInterfaces
{
    public interface IPostPrintTargetServices
    {
        public Task<List<PostPrintTarget>> TakePostPrintTargets();

        public Task<PostPrintTarget> TakePostPrintTargetById(Guid id);

        public Task AddPostPrintTarget(PostPrintTarget postPrintTarget);

        public Task DeletePostPrintTarget(Guid id);

        public Task UpdatePostPrintTarget(PostPrintTarget updatedPostPrintTarget);
    }
}
