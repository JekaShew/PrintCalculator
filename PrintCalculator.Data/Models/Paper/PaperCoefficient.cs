﻿using System;
using PrintCalculator.Data.Models.TechProcess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintCalculator.UI.Gen2.Data.Abstract;

namespace PrintCalculator.Data.Models.Paper
{
    public class PaperCoefficient : Model
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public float Coefficient { get; set; }

        public Guid PaperDensityId { get; set; }
        public Guid TechProcessId { get; set; }

        public TechProcess.TechProcess TechProcess { get; set; }
        public PaperDensity PaperDensity { get; set; }

        public List<PaperDensity> PaperDensities { get; set; }
        public List<TechProcess.TechProcess> TechProcesses { get; set; }
    }
}
