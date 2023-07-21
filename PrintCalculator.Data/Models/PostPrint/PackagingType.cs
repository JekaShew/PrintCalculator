using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data.Models.PostPrint
{
    public class PackagingType
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public float PreparationPrice { get; set; }
        public float PerPackPrice { get; set; }
        public float PreparationCostPrice { get; set; }
        public float PerPackCostPrice { get; set; }
        public int PreparationTime { get; set; }
        public int PerPackTime { get; set; }
    }
}
