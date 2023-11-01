using System.Collections.Generic;

namespace PrintCalculator.UI.Gen2.Table.Data
{
    /// <summary>
    /// Output for refresh table logic
    /// </summary>
    /// <typeparam name="TVM">View model type</typeparam>
    public class TableContractOutput<TVM>
    {
        /// <summary>
        /// List of items
        /// </summary>
        public List<TVM> Data { get; set; }
    }
}
