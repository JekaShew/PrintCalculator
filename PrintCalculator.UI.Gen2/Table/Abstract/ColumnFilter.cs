namespace PrintCalculator.UI.Gen2.Table.Abstract
{
    /// <summary>
    /// Interface to filter column data
    /// </summary>
    public abstract class ColumnFilter
    {
        /// <summary>
        /// Name of column
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <see langword="true"/> if must be processed
        /// </summary>
        public abstract bool InUse { get; }

        /// <summary>
        /// Build part of filter query
        /// </summary>
        public abstract string BuildQuery();
    }
}
