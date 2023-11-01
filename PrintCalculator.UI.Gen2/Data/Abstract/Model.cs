using System;

namespace PrintCalculator.UI.Gen2.Data.Abstract
{
    /// <summary>
    /// Base data model
    /// </summary>
    public abstract class Model
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}
