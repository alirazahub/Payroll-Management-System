using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Management_System
{
    internal class ToDoList
    {
        public int taskID { get; set; }
        public int employeeID { get; set; }
        public string date { get; set; }
        public string Details { get; set; }
        public string status { get; set; }
    }
}
