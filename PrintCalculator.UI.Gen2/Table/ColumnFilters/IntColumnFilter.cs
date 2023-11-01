using PrintCalculator.UI.Gen2.Table.Abstract;

namespace PrintCalculator.UI.Gen2.Table.ColumnFilters
{
    /// <summary>
    /// Int column filter
    /// </summary>
    public class IntColumnFilter : ColumnFilter
    {
        /// <summary>
        /// Min value
        /// </summary>
        public int? Min { get; set; }
        /// <summary>
        /// Min value
        /// </summary>
        public int? Max { get; set; }

        /// <inheritdoc/>
        public override bool InUse => Min.HasValue || Max.HasValue;

        /// <inheritdoc/>
        public override string BuildQuery()
        {
            if (Min.HasValue && Max.HasValue)
                return $"({Name} > {Min} AND {Name} < {Max})";
            else if (Min.HasValue)
                return $"({Name} > {Min})";
            else if (Max.HasValue)
                return $"({Name} < {Max})";
            else
                return "";
        }
    }
}
