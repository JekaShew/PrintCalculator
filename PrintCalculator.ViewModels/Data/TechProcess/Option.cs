﻿using PrintCalculator.UI.Gen2.Crud.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Data.TechProcess
{
    public class Option : IdViewModel<PrintCalculator.Data.Models.TechProcess.Option>
    {
        //public Guid Id {  get; set;  }
        public string Title { get; set;  }
        public string Description { get; set; }

        public override void FromDataModel(PrintCalculator.Data.Models.TechProcess.Option dm, UtilsServices service)
        {
            base.FromDataModel(dm, service);

            Title = dm.Title;
        }

        public override void ToDataModel(PrintCalculator.Data.Models.TechProcess.Option dm, UtilsServices service)
        {
            base.ToDataModel(dm, service);

            dm.Title = Title;
        }
    }
}
