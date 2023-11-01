using PrintCalculator.UI.Gen2.Table.Abstract;
using System;

namespace PrintCalculator.UI.Gen2.Table.ColumnFilters
{
    /// <summary>
    /// Identifier column filter
    /// </summary>
    public class IdColumnFilter : ColumnFilter
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public Guid? Id { get; set; }

        /// <inheritdoc/>
        public override bool InUse => Id.HasValue;

        /// <inheritdoc/>
        public override string BuildQuery()
        {
            return $"({Name} = '{Id}')";
        }
    }
}
