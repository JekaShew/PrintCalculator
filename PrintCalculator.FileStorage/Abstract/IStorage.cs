using System;
using System.IO;
using System.Threading.Tasks;

namespace PrintCalculator.FileStorage.Abstract
{
    /// <summary>
    /// File storage
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Save file
        /// </summary>
        Task Save(IFileModel media, string group);
        /// <summary>
        /// Delete file
        /// </summary>
        Task Delete(IFileModel media, string group);
        /// <summary>
        /// File stream getter
        /// </summary>
        Func<IFileModel, Stream> GetStream(string group);
    }
}
