using PrintCalculator.FileStorage.Abstract;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PrintCalculator.FileStorage
{
    /// <summary>
    /// Local storage
    /// </summary>
    public class LocalStorage : IStorage
    {
        private readonly IHostEnvironment webHostEnvironment;

        public LocalStorage(IHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        /// <inheritdoc/>
        public Task Save(IFileModel media, string group)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task Delete(IFileModel media, string group) => Task.Run(() =>
        {
            File.Delete(Path.Combine(webHostEnvironment.ContentRootPath, "wwwroot", group, $"{media.Id}.{media.Extension}"));
        });

        /// <inheritdoc/>
        public Func<IFileModel, Stream> GetStream(string group)
        {
            return (media) => new FileStream(Path.Combine(webHostEnvironment.ContentRootPath, "wwwroot", $"{group}/{media.Id}.{media.Extension}"), FileMode.Open, FileAccess.Read);
        }
    }
}
