using PrintCalculator.FileStorage.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace PrintCalculator.FileStorage
{
    /// <summary>
    /// General storage service
    /// </summary>
    public class StorageService
    {
        private readonly IHostEnvironment webHostEnvironment;
        private readonly Converter converterService;
        private readonly IStorage storageService;

        public StorageService(IHostEnvironment webHostEnvironment, Converter converterService, IStorage storageService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.converterService = converterService;
            this.storageService = storageService;
        }

        /// <summary>
        /// Save file
        /// </summary>
        public async Task SaveMedia(IFileModel media, IFormFile modelFile, string group)
        {
            await SaveOriginal(media, modelFile);

            if (media.Type == FileType.Image)
                await converterService.ConvertImage(media);

            await storageService.Save(media, group);
        }

        /// <summary>
        /// Remove file
        /// </summary>
        public async Task RemoveMedia(IFileModel media, string group)
        {
            await storageService.Delete(media, group);
        }

        private async Task SaveOriginal(IFileModel media, IFormFile modelFile)
        {
            using var fs = new FileStream(GetFullMediaPath(media), FileMode.Create);
            await modelFile.CopyToAsync(fs);
        }

        public string GetFullMediaPath(IFileModel media) => Path.Combine(webHostEnvironment.ContentRootPath, "wwwroot/media", $"{media.Id}.{media.Extension}");
    }
}
