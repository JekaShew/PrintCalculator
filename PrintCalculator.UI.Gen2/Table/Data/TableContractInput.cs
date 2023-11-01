using PrintCalculator.UI.Gen2.Table.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PrintCalculator.UI.Gen2.Table.Data
{
    /// <summary>
    /// Input for refresh table logic
    /// </summary>
    public class TableContractInput
    {
        /// <summary>
        /// Column filters
        /// </summary>
        public List<ColumnFilter> Filters { get; set; }
        /// <summary>
        /// Skip items count
        /// </summary>
        public int Skip { get; set; }
        /// <summary>
        /// Take items count
        /// </summary>
        public int Take { get; set; }
        /// <summary>
        /// Order column
        /// </summary>
        public string Order { get; set; }
        /// <summary>
        /// <see langword="true"/> if order is ascending, otherwise descending
        /// </summary>
        public bool IsOrderAsc { get; set; }



        private string filtersRaw;
        /// <summary>
        /// Json encoded filters
        /// </summary>
        public string FiltersRaw
        {
            get => filtersRaw; 
            set
            {
                filtersRaw = value;
                Filters = JsonConvert.DeserializeObject<List<ColumnFilter>>(filtersRaw, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
            }
        }
    }
}
