using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Abstract.Data
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }
        public string JobTitle { get; set; }
        public Role Role { get; set; }
    }

    public enum Role { MainAdmin, Admin, Administrator, Worker }
}
