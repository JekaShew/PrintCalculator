using PrintCalculator.ViewModels.Data.PostPrint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.PostPrintInterfaces
{
    public interface IPackagingTypeServices
    {
        public Task<List<PackagingType>> TakePackagingTypes();

        public Task<PackagingType> TakePackagingTypeById(Guid id);

        public Task AddPackagingType(PackagingType packagingType);

        public Task DeletePackagingType(Guid id);

        public Task UpdatePackagingType(PackagingType updatedPackagingType);
    }
}
