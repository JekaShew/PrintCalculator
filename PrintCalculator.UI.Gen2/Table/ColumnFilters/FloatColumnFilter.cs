using PrintCalculator.UI.Gen2.Table.Abstract;

namespace PrintCalculator.UI.Gen2.Table.ColumnFilters
{
    /// <summary>
    /// Float column filter
    /// </summary>
    public class FloatColumnFilter : ColumnFilter
    {
        /// <summary>
        /// Min value
        /// </summary>
        public float? Min { get; set; }
        /// <summary>
        /// Max value
        /// </summary>
        public float? Max { get; set; }

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
