using AutoMapper;
using PrintCalculator.FileStorage;
using Microsoft.EntityFrameworkCore;

namespace PrintCalculator.UI.Gen2.Crud.ViewModels
{
    /// <summary>
    /// Crud services container
    /// </summary>
    public class UtilsServices
    {
        /// <summary>
        /// Database context
        /// </summary>
        public DbContext AppDbContext { get; set; }
        /// <summary>
        /// Storage context
        /// </summary>
        public StorageService StorageService { get; set; }
        public IMapper AutoMapper { get; set; }
    }
}
