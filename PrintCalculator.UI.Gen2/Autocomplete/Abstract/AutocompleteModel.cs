using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;

namespace PrintCalculator.UI.Gen2.Autocomplete.Abstract
{
    /// <summary>
    /// Autocomplete base client model
    /// </summary>
    /// <typeparam name="TDM"></typeparam>
    public abstract class AutocompleteModel<TDM>
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Fill data from data model
        /// </summary>
        public abstract void FromDataModel(TDM dm, UtilsServices utilsServices);
    }
}
