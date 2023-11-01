using PrintCalculator.FileStorage.Abstract;
using Microsoft.Extensions.Hosting;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace PrintCalculator.FileStorage
{
    /// <summary>
    /// File converter
    /// </summary>
    public class Converter
    {
        private static Size ImageTargetSize { get; } = new Size(400, 400);

        private readonly IHostEnvironment webHostEnvironment;

        public Converter(IHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Post process image
        /// </summary>
        public Task ConvertImage(IFileModel media) => ConvertImage(media, ImageTargetSize.Width, ImageTargetSize.Height);

        /// <summary>
        /// Post process image
        /// </summary>
        private Task ConvertImage(IFileModel media, int targetWidth, int targetHeight) => Task.Run(() =>
        {
            var inputFileName = GetMediaPath(media, media.Extension);
            var tempFileName = GetMediaPath(media, media.Extension, "TEMPIMG");
            var outputFileName = GetMediaPath(media, "png");

            File.Copy(inputFileName, tempFileName, true);

            using (var source = Image.FromFile(tempFileName))
            {
                OrientationHelper.RotateImageByExifOrientationData(source, true);

                var sourceRatio = (float)source.Width / source.Height;

                using var target = new Bitmap(targetWidth, targetHeight);
                using var g = Graphics.FromImage(target);

                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                float scaling;
                var scalingY = (float)source.Height / targetHeight;
                var scalingX = (float)source.Width / targetWidth;
                if (scalingX < scalingY)
                    scaling = scalingX;
                else
                    scaling = scalingY;

                var newWidth = (int)(source.Width / scaling);
                var newHeight = (int)(source.Height / scaling);

                if (newWidth < targetWidth)
                    newWidth = targetWidth;
                if (newHeight < targetHeight)
                    newHeight = targetHeight;

                var shiftX = 0;
                var shiftY = 0;

                if (newWidth > targetWidth)
                    shiftX = (newWidth - targetWidth) / 2;
                if (newHeight > targetHeight)
                    shiftY = (newHeight - targetHeight) / 2;

                g.DrawImage(source, -shiftX, -shiftY, newWidth, newHeight);

                var bmp = new Bitmap(target);

                using var ms = new MemoryStream();
                using var fs = new FileStream(outputFileName, FileMode.OpenOrCreate, FileAccess.Write);
                bmp.Save(ms, ImageFormat.Png);
                var bytes = ms.ToArray();
                fs.Write(bytes, 0, bytes.Length);
            }

            if (media.Extension != "png")
            {
                media.Extension = "png";
                File.Delete(inputFileName);
            }
            File.Delete(tempFileName);
        });

        private string GetMediaPath(IFileModel media, string extension, string prefix = null)
        {
            return Path.Combine(webHostEnvironment.ContentRootPath, $"wwwroot/media/{(string.IsNullOrWhiteSpace(prefix) ? "" : prefix)}{media.Id}.{extension}");
        }
    }
}
