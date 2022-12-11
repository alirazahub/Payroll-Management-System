using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Management_System
{
    internal class SalaryClass
    {
        public int employeeID { get; set; }
        public string Details { get; set; }
        public string Date { get; set; }
        public int TotalSalary { get; set; }
        public int Deduction { get; set; }
        public int Bonus { get; set; }
    }
}
