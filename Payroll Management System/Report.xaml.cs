using System;
using System.Collections.Generic;
using System.Globalization;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Payroll_Management_System
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Report : Page
    {
        DataAccess cont = new DataAccess();
        List<Payroll> payroll;
        PayrollDetailsss payrollDetails;
        public Report()
        {
            this.InitializeComponent();
            try
            {
                payrollList.ItemsSource = null;
                payroll = cont.Payroll();
                payrollList.ItemsSource = payroll;
            }
            catch (Exception)
            {
                payrollList.ItemsSource = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string year = monthAndYear.Date.Date.Year.ToString();
            string month = monthAndYear.Date.Date.Month.ToString();
            try
            {
                payrollList.ItemsSource = null;
                payroll = cont.PayrollMonth(year,month);
                payrollList.ItemsSource = payroll;
            }
            catch (Exception)
            {
                payrollList.ItemsSource = null;
            }
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            int index = -1;
            index = payrollList.SelectedIndex;
            if(index == -1)
            {
                ToggleTeaching.Title = "Error! ";
                ToggleTeaching.Subtitle = "Select the Employee First ";
                ToggleTeaching.IsOpen = true;
            }
            else
            {
                int empID = payroll[index].employeeID;
                string monthh = payroll[index].Month;
                string year = payroll[index].Year;
                DateTime date = DateTime.ParseExact(monthh, "MMMM", CultureInfo.InvariantCulture);
                string month = date.Month.ToString();
                try
                {
                    payrollDetails = cont.SalaryPayrollDetails(empID, year, month);
                    EmpName.Text = payrollDetails.employeeName;
                    empContact.Text = payrollDetails.employeeContact;
                    departName.Text = payrollDetails.DepartmentName;
                    desigName.Text = payrollDetails.DesignationName;
                    perDay.Text = payrollDetails.PerDay.ToString();
                    perHour.Text = payrollDetails.BonusPerHour.ToString();
                    present.Text = payrollDetails.TotalPresents.ToString();
                    absent.Text = payrollDetails.TotalAbsents.ToString();
                    rleave.Text = payrollDetails.RejectedLeaves.ToString();
                    aleave.Text = payrollDetails.AcceptedLeaves.ToString();
                    salary.Text = payrollDetails.TotalSalary.ToString();
                    bonus.Text = payrollDetails.TotalBonus.ToString();
                    deduction.Text = payrollDetails.TotalDeduction.ToString();
                    totalSalary.Text = payrollDetails.TotalSalaryAfterBonus.ToString();
                }
                catch (Exception)
                {
                    ToggleTeaching.Title = "Error! ";
                    ToggleTeaching.Subtitle = "Not Found ";
                    ToggleTeaching.IsOpen = true;
                }
                ContentDialogResult result = await ContentDialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ToggleTeaching.Title = "Feature! ";
            ToggleTeaching.Subtitle = "Comming Soon ";
            ToggleTeaching.IsOpen = true;
        }
    }
}
