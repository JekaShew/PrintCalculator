using PrintCalculator.ViewModels.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.StorageInterfaces
{
    public interface IUnitMeasureServices
    {
        public Task<List<UnitMeasure>> TakeUnitMeasures();

        public Task<UnitMeasure> TakeUnitMeasureById(Guid id);

        public Task AddUnitMeasure(UnitMeasure unitMeasure);

        public Task DeleteUnitMeasure(Guid id);

        public Task UpdateUnitMeasure(UnitMeasure updatedUnitMeasure);
    }
}
