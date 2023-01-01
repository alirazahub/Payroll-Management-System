using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Management_System
{
    public class PayrollDetailsss
    {
        public int employeeID { get; set; }
        public int TotalPresents { get; set; }
        public int TotalAbsents { get; set; }
        public int RejectedLeaves { get; set; }
        public int AcceptedLeaves { get; set; }
        public int PerDay { get; set; }
        public int BonusPerHour { get; set; }
        public string employeeName { get; set; }
        public string employeeContact { get; set; }
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
        public string Details { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Date { get; set; }
        public int TotalSalary { get; set; }
        public int TotalDeduction { get; set; }
        public int TotalBonus { get; set; }
        public int TotalSalaryAfterBonus { get; set; }
    }
}
