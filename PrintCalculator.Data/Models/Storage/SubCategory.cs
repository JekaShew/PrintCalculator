﻿using PrintCalculator.UI.Gen2.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data.Models.Storage
{
    public class SubCategory : Model
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }

    }

}
