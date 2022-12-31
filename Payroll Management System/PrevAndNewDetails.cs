using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Management_System
{
    public class PrevAndNewDetails
    {
        public int employeeID { get; set; }
        public string employeeName { get; set; }
        public string PreviousDesignation { get; set; }
        public string NewDesignation { get; set; }
        public string PreviousDepartment { get; set; }
        public string NewDepartment { get; set; }
        public string UpdatedBy { get; set; }
        public string updatedOn { get; set; }
    }
}
