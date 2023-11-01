using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;

namespace PrintCalculator.UI.Gen2.Table.Abstract
{
    /// <summary>
    /// Base client model
    /// </summary>
    /// <typeparam name="TDM">Data model type</typeparam>
    public abstract class TableModel<TDM>
    {
        /// <summary>
        /// Unique identifier
        /// Null when adding, value when editing
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Fill data from data model
        /// </summary>
        public abstract void FromDataModel(TDM dm, UtilsServices utilsServices);
    }
}
