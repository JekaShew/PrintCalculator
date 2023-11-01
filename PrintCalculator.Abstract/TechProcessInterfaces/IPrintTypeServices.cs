using PrintCalculator.ViewModels.Data.TechProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.TechProcessInterfaces
{
    public interface IPrintTypeServices
    {
        public Task<List<PrintType>> TakePrintTypes();

        public Task<PrintType> TakePrintTypeById(Guid id);

        public Task AddPrintType(PrintType printType);

        public Task DeletePrintType(Guid id);

        public Task UpdatePrintType(PrintType updatedPrintType);
    }
}
