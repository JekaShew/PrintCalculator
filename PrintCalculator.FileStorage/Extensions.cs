using PrintCalculator.FileStorage.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace PrintCalculator.FileStorage
{
    /// <summary>
    /// File storage extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Add file storage services
        /// </summary>
        public static IServiceCollection AddStorageServices<TStorage>(this IServiceCollection services) where TStorage : class, IStorage
        {
            services.AddTransient<Converter>();
            services.AddTransient<StorageService>();
            services.AddTransient<IStorage, TStorage>();

            return services;
        }
    }
}
