﻿using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Table.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.ViewModels.Table.TechProcess
{
    public class Option : TableModelAutoMapped<PrintCalculator.Data.Models.TechProcess.Option>
    {
        public string Title
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }

        public override void FromDataModel(PrintCalculator.Data.Models.TechProcess.Option dm, UtilsServices utilsServices)
        {
            Id = dm.Id;
            Title = dm.Title;
        }
    }
}
