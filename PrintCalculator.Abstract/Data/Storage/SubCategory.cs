using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.Data.Storage
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}
