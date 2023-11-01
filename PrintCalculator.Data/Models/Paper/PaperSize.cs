using PrintCalculator.UI.Gen2.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data.Models.Paper
{
     public class PaperSize : Model
    {
        public string Title { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

    }
}
