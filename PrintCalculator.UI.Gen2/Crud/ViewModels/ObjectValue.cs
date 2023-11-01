using System;

namespace PrintCalculator.UI.Gen2.Crud.ViewModels
{
    /// <summary>
    /// View model connected object value
    /// </summary>
    /// <typeparam name="TVM"></typeparam>
    public class ObjectValue<TVM>
    {
        /// <summary>
        /// Id of connected object
        /// </summary>
        public Guid Value { get; set; }
        /// <summary>
        /// View model of connected object
        /// </summary>
        public TVM VM { get; set; }
    }
}
