using Microsoft.AspNetCore.Http;
using System;

namespace PrintCalculator.UI.Gen2.Crud.ViewModels
{
    /// <summary>
    /// View model media value
    /// </summary>
    public class MediaValue
    {
        /// <summary>
        /// Posted media file content
        /// </summary>
        public IFormFile Update { get; set; }
        /// <summary>
        /// Id of existing media
        /// </summary>
        public Guid? Id { get; set; }
    }
}
