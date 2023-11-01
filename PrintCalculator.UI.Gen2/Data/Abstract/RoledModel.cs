using System;

namespace PrintCalculator.UI.Gen2.Data.Abstract
{
    /// <summary>
    /// Base data model for authorization based logic
    /// </summary>
    public class RoledModel : Model
    {
        /// <summary>
        /// Datetime of last update
        /// </summary>
        public DateTime UpdatedOn { get; set; }
        /// <summary>
        /// Last update user id
        /// </summary>
        public Guid UpdatedBy { get; set; }
    }
}
