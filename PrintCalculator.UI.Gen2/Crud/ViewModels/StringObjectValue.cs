using System;
using System.ComponentModel.DataAnnotations;

namespace PrintCalculator.UI.Gen2.Crud.ViewModels
{
    /// <summary>
    /// Simple string object view model
    /// </summary>
    public class StringObjectValue
    {
        /// <summary>
        /// Id of connected object
        /// </summary>
        [Required]
        public Guid? Id { get; set; }
        /// <summary>
        /// Text of connected object
        /// </summary>
        public string Title { get; set; }
    }
}
