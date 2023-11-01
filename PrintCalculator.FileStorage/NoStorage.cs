using PrintCalculator.FileStorage.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.FileStorage
{
    public class NoStorage : IStorage
    {
        public Task Delete(IFileModel media, string group)
        {
            throw new NotImplementedException();
        }

        public Func<IFileModel, Stream> GetStream(string group)
        {
            throw new NotImplementedException();
        }

        public Task Save(IFileModel media, string group)
        {
            throw new NotImplementedException();
        }
    }
}
