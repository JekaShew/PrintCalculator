using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data.Models.Paper
{
     public class PaperSize
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

    }
}
