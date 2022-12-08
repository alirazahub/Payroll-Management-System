using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Payroll_Management_System
{
    class DataAccess
    {
        string connectionString = "Server=.,61099;Database=payrollManagementDB;User Id=devil;pwd=angel";
        public List<ReadingEmployees> getUsers()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<ReadingEmployees>("select employeeID,employeeDOB,joiningDate,gender,houseNo,street,town,employeeName,employeeNIC,employeeContact,employeeEmail,departmentName,designationName,city,username,password from [EmployeesTable] as e inner join [DepartmentsTable] as d on e.employeeDepartment = d.departmentID inner join [DesignationTable] as s on e.employeeDesignation = s.designationID").ToList();
                return output;
            }

        }

        public void addEmployee(Employees emp)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                dbConnection.Execute("insert into EmployeesTable (employeeName,employeeNIC,employeeContact,employeeEmail,gender,houseNo,street,town,city,employeeDepartment,employeeDesignation,joiningDate,employeeDOB) values ('" + emp.employeeName + "', '" + emp.employeeNIC + "' ,'" + emp.employeeContact + "','" + emp.employeeEmail +"','"+emp.gender+"','"+emp.houseNo+"','"+emp.street+"','"+emp.town+"','"+emp.city+"','"+emp.employeeDepartment+"','"+emp.employeeDesignation+"','"+emp.joiningDate+"','"+emp.employeeDOB+"') ");

            }
        }
    }
}
