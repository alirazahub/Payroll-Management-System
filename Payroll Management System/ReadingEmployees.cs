using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Management_System
{
    public class ReadingEmployees
    {
        public int employeeID { get; set; }
        public string employeeName { get; set; }
        public string employeeEmail { get; set; }
        public string employeeNIC { get; set; }
        public string employeeDOB { get; set; }
        public string departmentName { get; set; }
        public string designationName { get; set; }
        public string joiningDate { get; set; }
        public string employeeContact { get; set; }
        public string gender { get; set; }
        public string houseNo { get; set; }
        public string street { get; set; }
        public string town { get; set; }
        public string city { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public string leave { get; set; }
        public int TotalPresents { get; set; }
        public int TotalAbsents { get; set; }
        public int RejectedLeaves { get; set; }
        public int AcceptedLeaves { get; set; }
        public int PerDay { get; set; }
        public int BonusPerHour { get; set; }
        public string employeeCINIC { get; set; }
    }
}
