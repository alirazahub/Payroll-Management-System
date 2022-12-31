using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Management_System
{
    public class ChangedSalaries
    {
        public int designationID { get; set; }
        public string DesignationName { get; set; }
        public string UpdatedBy { get; set; }
        public int perDay { get; set; }
        public int BonusPerHour { get; set; }
        public string wasValidTill { get; set; }
    }
}
