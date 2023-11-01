using PrintCalculator.UI.Gen2.Table.Abstract;

namespace PrintCalculator.UI.Gen2.Table.ColumnFilters
{
    /// <summary>
    /// String column filter
    /// </summary>
    public class StringColumnFilter : ColumnFilter
    {
        /// <summary>
        /// Part of string value
        /// </summary>
        public string Query { get; set; }

        /// <inheritdoc/>
        public override bool InUse => !string.IsNullOrWhiteSpace(Query);

        /// <inheritdoc/>
        public override string BuildQuery()
        {
            return $"({Name} LIKE '%{Query}%')";
        }
    }
}
