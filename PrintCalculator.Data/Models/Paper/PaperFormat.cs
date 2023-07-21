using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Data.Models.Paper
{
    public class PaperFormat
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public Guid PaperSizeId { get; set; }

        public PaperSize PaperSize { get; set; }

        public List<PaperSize> PaperSizes { get; set; }

    }

}
