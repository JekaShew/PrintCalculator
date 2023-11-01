using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Data.Abstract;
using System;

namespace PrintCalculator.UI.Gen2.Crud.Abstract
{
    /// <summary>
    /// Base client model for authorization based logic
    /// </summary>
    /// <typeparam name="TDM">Data model type</typeparam>
    public class RoledViewModel<TDM> : IdViewModel<TDM> where TDM : RoledModel
    {
        /// <summary>
        /// Datetime of last update
        /// </summary>
        public DateTime UpdatedOn { get; set; }
        /// <summary>
        /// Last update user id
        /// </summary>
        public Guid UpdatedBy { get; set; }

        /// <inheritdoc/>
        public override void FromDataModel(TDM dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            UpdatedOn = dm.UpdatedOn;
            UpdatedBy = dm.UpdatedBy;
        }
    }
}
