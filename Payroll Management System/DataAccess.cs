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

        public void addBonus(BonusClass bonus)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                dbConnection.Execute("insert into BonusTable  values ('" + bonus.employeeID + "', '" + bonus.date + "' ,'" + bonus.hours + "','" + bonus.details +"') ");
            }
        }
        public List<BonusClass> getBonus()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<BonusClass>("select e.employeeId,e.employeeName,b.Details,b.Date,b.Hours,(select BonusPerHour from DesignationTable where designationID = e.employeeDesignation) * b.Hours as TotalBonus from BonusTable b inner join EmployeesTable e on b.employeeId = e.employeeID order by Date desc").ToList();
                return output;
            }

        }
        public List<String> getEmployeeName(int empID)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                    var output = dbConnection.Query<String>("select employeeName from EmployeesTable where employeeID =  '" + empID + "'").ToList();
                    return output;
            }
        }
        public List<TotalAttendanceNos> getAttenanceNos(string date)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<TotalAttendanceNos>("select (select count(*) from AttendanceTable where Status = 'Present' and Date = '"+date.ToString()+"') as Presents ,(select count(*) from AttendanceTable where Status = 'Leave' and Date = '"+ date.ToString() + "') as Leaves,(select count(*) from AttendanceTable where Status = 'Leave' and Leave = 'Rejected' and Date = '"+ date.ToString() + "') as RejectedLeaves,(select count(*) from AttendanceTable where Status = 'Leave' and Leave = 'Accepted' and Date = '"+ date.ToString() + "') as AcceptedLeaves").ToList();
                return output;
            }
        }

        public List<int> getTotalEmployees()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<int>("select count(*) from employeesTable").ToList();
                return output;
            }
        }

        public List<ReadingEmployees> getAttendance(string date)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<ReadingEmployees>("select e.employeeId,e.employeeName,a.Status,a.leave from AttendanceTable a inner join EmployeesTable e on a.employeeId = e.employeeID where a.Date = '"+date.ToString()+"' order by e.employeeID").ToList();
                return output;
            }
        }

        public List<Calculations> getSalaryDetails(int id,string date)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<Calculations>("DECLARE\t@return_value int EXEC\t@return_value = SPCalculateTotalSalaryBonus @employeeID = "+id+", @monthYear ='"+date.ToString()+"'\r\n").ToList();
                return output;
            }
        }
        public List<ReadingEmployees> getEmployeeSalaryDetails(int id,string date)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<ReadingEmployees>("DECLARE\t@return_value int EXEC\t@return_value = SPEmployeeDetails @employeeID = "+id+", @monthYear ='"+date.ToString()+"'\r\n").ToList();
                return output;
            }
        }

        public void addNewSalary(SalaryClass sal)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                dbConnection.Execute("insert into PayrollTable  values ("+sal.employeeID+",'"+sal.Details+"','"+sal.Date+"',"+sal.Deduction+","+sal.Bonus+","+sal.TotalSalary + ")");
            }
        }

        public List<ReadingEmployees> getEmployeeByDep(string departName)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<ReadingEmployees>("EXEC SPEmployeesOfDepartment @departmentName = '"+departName+"'").ToList();
                return output;
            }
        }
        public List<ReadingEmployees> getManagingDirectors()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<ReadingEmployees>("select * from VManagingDirectors").ToList();
                return output;
            }
        }

        public List<ToDoList> getToDoList()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                int ID = MainPage.currentUser.employeeID;
                var output = dbConnection.Query<ToDoList>("select * from ToDoTable where employeeID = "+ID+"").ToList();
                return output;
            }
        }

        public List<Employees> getEmployeeDetails(int id)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<Employees>("select * from EmployeesTable where employeeID = " + id + "").ToList();
                return output;
            }
        }
        public void updateEmployee(Employees employee,int id)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                dbConnection.Execute("update EmployeesTable set employeeName = '"+employee.employeeName+"',employeeDOB = '"+employee.employeeDOB+"',employeeNIC = '"+employee.employeeNIC+"',employeeContact='"+employee.employeeContact+"',gender='"+employee.gender+"',houseNo='"+employee.houseNo+"',street='"+employee.street+"',town='"+employee.town+"',city='"+employee.city+"' where employeeID = "+id+"\r\n");
            }
        }
    }
}
