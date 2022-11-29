using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Management_System
{
    class DataAccess
    {
        string connectionString = "Server=.,61099;Database=payrollManagementDB;User Id=devil;pwd=angel";
        public List<Employees> getUsers()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<Employees>("select * from EmployeesTable").ToList();
                return output;
            }

        }
    }
}
