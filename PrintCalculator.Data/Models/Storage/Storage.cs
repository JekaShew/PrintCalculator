﻿using PrintCalculator.UI.Gen2.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data.Models.Storage
{
    public class Storage : Model
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
    }
}
