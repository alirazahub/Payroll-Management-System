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

        public string addEmployee(Employees emp)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("insert into EmployeesTable (employeeName,employeeNIC,employeeContact,employeeEmail,gender,houseNo,street,town,city,employeeDepartment,employeeDesignation,joiningDate,employeeDOB) values ('" + emp.employeeName + "', '" + emp.employeeNIC + "' ,'" + emp.employeeContact + "','" + emp.employeeEmail +"','"+emp.gender+"','"+emp.houseNo+"','"+emp.street+"','"+emp.town+"','"+emp.city+"','"+emp.employeeDepartment+"','"+emp.employeeDesignation+"','"+emp.joiningDate+"','"+emp.employeeDOB+"') ");
                    return "Done";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex;
                }
            }
        }

        public string addBonus(BonusClass bonus)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("insert into BonusTable  values ('" + bonus.employeeID + "', '" + bonus.date + "' ,'" + bonus.hours + "','" + bonus.details + "') ");
                    return "Done";
                }catch(Exception ex)
                {
                    return "Error: "+ex;
                }
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

        public string addNewSalary(SalaryClass sal)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("insert into PayrollTable  values ("+sal.employeeID+",'"+sal.Details+"','"+sal.Year+"','"+sal.Month+"','"+sal.Date+"',"+sal.Deduction+","+sal.Bonus+","+sal.TotalSalary + ")");
                    return "Done";
                }
                catch (Exception ex)
                {
                    return "Error" + ex;
                }
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
                var output = dbConnection.Query<ToDoList>("select * from ToDoTable where employeeID = "+ID+ " order by taskid desc").ToList();
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
                dbConnection.Execute("update EmployeesTable set employeeName = '"+employee.employeeName+"',employeeEmail = '"+employee.employeeEmail+"',employeeDOB = '"+employee.employeeDOB+"',employeeNIC = '"+employee.employeeNIC+"',employeeContact='"+employee.employeeContact+"',gender='"+employee.gender+"',houseNo='"+employee.houseNo+"',street='"+employee.street+"',town='"+employee.town+"',city='"+employee.city+"' where employeeID = "+id+"\r\n");
            }
        }

        public string present(string date,int id)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("EXEC SPMarkAttendance @employeeID = "+id+", @status ='Present',@date = '"+date+"'");
                    return "Done";
                }
                catch (Exception ex)
                {
                    return "Error: "+ex;
                }
            }
        }

        public string absent(string date, int id)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("EXEC SPMarkAttendance @employeeID = " + id + ", @status ='Absent',@date = '" + date + "'");
                    return "Done";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex;
                }
            }
        }

        public string leaveA(string date, int id)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("EXEC SPMarkAttendance @employeeID = " + id + ", @status ='LeaveAccepted',@date = '" + date + "'");
                    return "Done";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex;
                }
            }
        }

        public string leaveR(string date, int id)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("EXEC SPMarkAttendance @employeeID = " + id + ", @status ='LeaveRejected',@date = '" + date + "'");
                    return "Done";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex;
                }
                
            }
        }
        public string deleteAttend(string date, int id)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("delete from attendanceTable where employeeid = " + id + " and date = '" + date + "'");
                    return "Done";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex;
                }
                
            }
        }

        public void addNewTask(string date, string task)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                dbConnection.Execute("insert into ToDoTable values("+MainPage.currentUser.employeeID+",'"+date+"','"+task+ "','Pending')");
            }
        }

        public string updateTask(int taskid,string task,string status)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("update ToDoTable SET [Status] = '"+status+ "',Details = '" + task+"' where taskID = "+ taskid + "");
                    return "Done";
                }
                catch (Exception ex)
                {
                    return "Error" + ex;
                }
            }
        }

        public void deleteTask(int taskID)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                dbConnection.Execute("delete from ToDoTable where taskID = "+ taskID + "");
            }
        }

        public int getDepartID(string name)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                int output = (int)dbConnection.Query<int>("SELECT payrollManagementDB.dbo.[FDepartmentID]('"+name+"')").FirstOrDefault();
                return output;
            }
        }
        public string getDepartName(int id)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                string output = (string)dbConnection.Query<string>("select departmentName from departmentsTable where departmentId = '" + id + "'").FirstOrDefault();
                return output;
            }
        }

        public List<ReadingEmployees> getAllDepartments()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<ReadingEmployees>("SELECT departmentName from DepartmentsTable").ToList();
                return output;
            }
        }

        public int getDesigID(string name)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                int output = (int)dbConnection.Query<int>("SELECT payrollManagementDB.dbo.[FDesignationID]('" + name + "')").FirstOrDefault();
                return output;
            }
        }
        public string getDesigName(int id)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                string output = (string)dbConnection.Query<string>("select designationName from designationTable where designationId = '" + id + "'").FirstOrDefault();
                return output;
            }
        }

        public List<ReadingEmployees> getAllDesignations()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<ReadingEmployees>("SELECT designationName from DesignationTable").ToList();
                return output;
            }
        }
        public List<Designations> getAllDesigs()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<Designations>("SELECT * from DesignationTable").ToList();
                return output;
            }
        }

        public void updateDepart(int EmpID, int PrevDepartID, int NewDepartID, int PrevDesigID, int NewDesigID)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                string date = System.DateTime.Now.ToString("yyyy/MM/dd");
                dbConnection.Execute("EXEC SPUpdateEmployeeDetails @employeeID = " + EmpID + ", @PrevDepartID = " + PrevDepartID + ", @PrevDesigID = " + PrevDesigID + ", @NewDepartID = " + NewDepartID + ", @NewDesigID = " + NewDesigID + ", @updatedBy = " + MainPage.currentUser.employeeID + ", @updatedOn = '" + date + "'\r\n");
            }
        }

        public void updateDesig(int EmpID, int PrevDepartID, int NewDepartID,int PrevDesigID, int NewDesigID)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                string date = System.DateTime.Now.ToString("yyyy/MM/dd");
                dbConnection.Execute("EXEC SPUpdateEmployeeDetails @employeeID = "+EmpID+", @PrevDepartID = "+PrevDepartID+", @PrevDesigID = "+ PrevDesigID + ", @NewDepartID = "+ NewDepartID + ", @NewDesigID = "+ NewDesigID + ", @updatedBy = "+MainPage.currentUser.employeeID+", @updatedOn = '"+ date + "'\r\n");
            }
        }

        public Employees getEmployeesDetails(int id)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<Employees>("select * from EmployeesTable where employeeID = " + id + "").FirstOrDefault();
                return output;
            }
        }

        public List<PrevAndNewDetails> getPrevAndNewDetails()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<PrevAndNewDetails>("EXEC SPGetPreviousAndNewDetails").ToList();
                return output;
            }
        }
        public string changeSalary(int desigID, int perDay, int perHour,string date,int changedBy)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("EXEC SPChangeSalary @designationID = "+ desigID + ", @changedBy = "+ changedBy + ", @PerDay = "+ perDay + ", @BonusPerHour = "+ perHour + ", @wasValidTill = '"+date+"'");
                    return "Done";
                }catch(Exception ex)
                {
                    return "Error: "+ex;
                }
            }
        }
        public  Designations getDesigs(int desigID)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<Designations>("select * from DesignationTable where designationID = "+desigID+"").FirstOrDefault();
                return output;
            }
        }
        public List<ChangedSalaries> getPreviousSalaries()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<ChangedSalaries>("EXEC SPGetPreviousSalaryDetails").ToList();
                return output;
            }
        }
        public List<ReadingEmployees> getNonAdmins()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<ReadingEmployees>("EXEC SPGetEmployeeDetailsByUserNameAndPassword").ToList();
                return output;
            }
        }

        public string makeAdmin(int id, string username, string password)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("EXEC SPUpdateUsernameAndPassword @employeeID = "+id+", @username = '"+ username + "', @password = '"+ password + "'");
                    return "Done";
                }
                catch (Exception ex)
                {
                    return "Error: "+ex;
                }
            }
        }
        public string removeAdmin(int id)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("EXEC SPSetUsernameAndPasswordToNull @employeeID ="+ id+"");
                    return "Done";
                }
                catch (Exception ex)
                {
                    return "Error: "+ex;
                }
            }
        }
        public ReadingEmployees getEmpDetail(int empID)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<ReadingEmployees>("EXEC SPGetEmployeeDetailsByEmployeeID @employeeID = "+empID+"").FirstOrDefault();
                return output;
            }
        }
        public string passwordReset(int empID)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    dbConnection.Execute("EXEC SPResetUsernameAndPassword @employeeID = "+empID+"");
                    return "Done";
                }catch(Exception ex)
                {
                    return "Error: " +ex;
                }
            }
        }
        public List<Payroll> Payroll()
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<Payroll>("SELECT employeeID, payrollManagementDB.dbo.FEmployeeName(employeeID) as employeeName, Year, payrollManagementDB.dbo.FMonthName(Month) as [Month], Date, Deduction, Bonus, TotalSalary FROM PayrollTable ").ToList();
                return output;
            }
        }

        public List<Payroll> PayrollMonth(string year, string month)
        {
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<Payroll>("SELECT employeeID, payrollManagementDB.dbo.FEmployeeName(employeeID) as employeeName, Year, payrollManagementDB.dbo.FMonthName(Month) as [Month], Date, Deduction, Bonus, TotalSalary FROM PayrollTable  where Month = '" + month + "' and Year = '" + year + "'").ToList();
                return output;
            }
        }
        public PayrollDetailsss SalaryPayrollDetails(int id, string year, string month)
        {
            string date = year + "-" + month + "%";
            using (IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                var output = dbConnection.Query<PayrollDetailsss>("DECLARE	@return_value int EXEC	@return_value = SPEmployeeDetailsWithSalary @employeeID = "+id+", @monthYear ='"+ date + "'").FirstOrDefault();
                return output;
            }
        }
    }
}
