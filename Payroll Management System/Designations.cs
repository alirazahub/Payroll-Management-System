using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Management_System
{
    public class Designations
    {
        public int designationID { get; set; }
        public string designationName { get; set; }
        public int PerDay { get; set; }
        public int BonusPerHour { get; set; }
    }
}
