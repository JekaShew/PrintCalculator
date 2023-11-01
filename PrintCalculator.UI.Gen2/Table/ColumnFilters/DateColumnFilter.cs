using PrintCalculator.UI.Gen2.Table.Abstract;
using System;

namespace PrintCalculator.UI.Gen2.Table.ColumnFilters
{
    /// <summary>
    /// Date column filter
    /// </summary>
    public class DateColumnFilter : ColumnFilter
    {
        public const string FORMAT = "dd.MM.yyyy hh:mm";

        /// <summary>
        /// Min value
        /// </summary>
        public DateTime? Min { get; set; }
        /// <summary>
        /// Max value
        /// </summary>
        public DateTime? Max { get; set; }

        /// <inheritdoc/>
        public override bool InUse => Min.HasValue || Max.HasValue;

        /// <inheritdoc/>
        public override string BuildQuery()
        {
            if (Min.HasValue && Max.HasValue)
                return $"({Name} > '{Min.Value.ToString(FORMAT)}' AND {Name} < '{Max.Value.ToString(FORMAT)}')";
            else if (Min.HasValue)
                return $"({Name} > '{Min.Value.ToString(FORMAT)}')";
            else if (Max.HasValue)
                return $"({Name} < '{Max.Value.ToString(FORMAT)}')";
            else
                return "";
        }
    }
}
