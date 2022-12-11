using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static System.Net.Mime.MediaTypeNames;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Payroll_Management_System
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Salary : Page
    {
        List<Calculations> salaries = new List<Calculations>();
        List<ReadingEmployees> employeeDetails = new List<ReadingEmployees>();
        DataAccess cont = new DataAccess();
        public Salary()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt16(EmpID.Text);
            string year = SalaryDate.Date.Year.ToString();
            string month = SalaryDate.Date.Month.ToString();
            string date = year + "-"+ month+ "%";
            salaries = cont.getSalaryDetails(id,date);

            TotalSalary.Text= salaries[0].TotalSalary.ToString();
            TotalBonus.Text= salaries[0].TotalBonus.ToString();
            TotalDeduction.Text= salaries[0].TotalDeduction.ToString();
            TotalSalaryAfterBonus.Text= salaries[0].TotalSalaryAfterBonus.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt16(EmpID.Text);
            string year = SalaryDate.Date.Year.ToString();
            string month = SalaryDate.Date.Month.ToString();
            string date = year + "-"+ month+ "%";
            employeeDetails = cont.getEmployeeSalaryDetails(id, date);
            employeeName.Text = employeeDetails[0].employeeName.ToString();
            employeeNIC.Text = employeeDetails[0].employeeCINIC.ToString();
            employeeContact.Text = employeeDetails[0].employeeContact.ToString();
            employeeDepartment.Text = employeeDetails[0].departmentName.ToString();
            employeeDesignation.Text = employeeDetails[0].designationName.ToString();
            TotalPresent.Text = employeeDetails[0].TotalPresents.ToString();
            TotalAbsent.Text = employeeDetails[0].TotalAbsents.ToString();
            RejectedLeaves.Text = employeeDetails[0].RejectedLeaves.ToString();
            AcceptedLeaves.Text = employeeDetails[0].AcceptedLeaves.ToString();
            PerDay.Text = employeeDetails[0].PerDay.ToString();
            BonusPerHour.Text = employeeDetails[0].BonusPerHour.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SalaryClass newSalary = new SalaryClass();
            string empid = EmpID.Text;
            newSalary.employeeID = Convert.ToInt16(empid);
            newSalary.Details = details.Text;
            string date = System.DateTime.Now.Date.ToString("yyyy/MM/dd");
            newSalary.Date = date;
            string Totsal = TotalSalaryAfterBonus.Text;
            newSalary.TotalSalary = Convert.ToInt32(Totsal);
            string ded = TotalDeduction.Text;
            newSalary.Deduction = Convert.ToInt32(ded);
            string bon = TotalBonus.Text;
            newSalary.Bonus = Convert.ToInt32(bon);
            cont.addNewSalary(newSalary);
            EmpID.Text = "";
            details.Text = "";
            TotalSalary.Text = "";
            TotalSalaryAfterBonus.Text = "";
            TotalDeduction.Text = "";
            TotalBonus.Text = "";
            details.Text = "";
            BonusPerHour.Text = "";
            PerDay.Text = "";
            AcceptedLeaves.Text = "";
            RejectedLeaves.Text = "";
            TotalAbsent.Text = "";
            TotalPresent.Text = "";
            employeeDesignation.Text = "";
            employeeDepartment.Text = "";
            employeeContact.Text = "";
            employeeNIC.Text = "";
            employeeName.Text = "";
            AddNewSalaryToggleTeaching.IsOpen = true;
        }
    }
}
