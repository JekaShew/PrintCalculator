using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.UI.Gen2.Table.Abstract
{
    public abstract class TableModelAutoMapped<TDM> : TableModel<TDM>
    {
        public override void FromDataModel(TDM dm, UtilsServices utilsServices)
        {
            
        }
    }
}
