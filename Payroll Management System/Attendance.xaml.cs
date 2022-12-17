using System;
using System.Collections.Generic;
using System.Data;
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
    public sealed partial class Attendance : Page
    {
        List<ReadingEmployees> employees;
        List<ReadingEmployees> EmpAttendance;
        List<TotalAttendanceNos> atted;
        DataAccess cont = new DataAccess();
        string DATE;
        public Attendance()
        {
            this.InitializeComponent();
            employees = cont.getUsers();
            string date = System.DateTime.Now.Date.ToString("yyyy/MM/dd");
            DATE = date;
            EmpAttendance = cont.getAttendance(DATE);
            atted = cont.getAttenanceNos(date);
            List<int> a = new List<int>();
            a = cont.getTotalEmployees();
            totalEmployees.Text = a[0].ToString();
            int total = a[0];
            TotalAttendanceNos obj = atted[0];
            presentEmployee.Text = obj.Presents.ToString();
            int totalLeaves = obj.AcceptedLeaves + obj.RejectedLeaves;
            totoalLeaves.Text = totalLeaves.ToString();
            int absent = total - (obj.Presents);
            absentEmployee.Text = absent.ToString();
            acceptedLeaves.Text = obj.AcceptedLeaves.ToString();
            rejectedLeaves.Text = obj.RejectedLeaves.ToString();
            datee.Text = date;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            addNewAttendanceDialog.IsPrimaryButtonEnabled = true;
            ContentDialogResult result = await addNewAttendanceDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                AddAttendanceToggleTeaching.IsOpen= true;

            }
            else
            {
                // User pressed Cancel, ESC, or the back arrow.
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string year =  attenDate.Date.Value.Year.ToString();
            string month =  attenDate.Date.Value.Month.ToString();
            string dt =  attenDate.Date.Value.Day.ToString();
            string date = year+"-"+month+"-"+dt;
            DATE = date;
            EmpAttendance = cont.getAttendance(DATE);
            atted = cont.getAttenanceNos(date);
            List<int> a = new List<int>();
            a = cont.getTotalEmployees();
            totalEmployees.Text = a[0].ToString();
            int total = a[0];
            TotalAttendanceNos obj = atted[0];
            presentEmployee.Text = obj.Presents.ToString();
            int totalLeaves = obj.AcceptedLeaves + obj.RejectedLeaves;
            totoalLeaves.Text = totalLeaves.ToString();
            int absent = total - (obj.Presents);
            absentEmployee.Text = absent.ToString();
            acceptedLeaves.Text = obj.AcceptedLeaves.ToString();
            rejectedLeaves.Text = obj.RejectedLeaves.ToString();
            listAttendance.ItemsSource = null;
            listAttendance.ItemsSource = EmpAttendance;
            datee.Text = date;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await AttendanceDialog.ShowAsync();
        }

        private void present_Checked(object sender, RoutedEventArgs e)
        {
            string dat = attendanceDate.Date.Value.ToString();
            int index = markAttendanceList.SelectedIndex;
            int empID = employees[index].employeeID;
            cont.present(dat,empID);

        }

        private void present_Unchecked(object sender, RoutedEventArgs e)
        {
            string dat = attendanceDate.Date.Value.ToString();
            int index = markAttendanceList.SelectedIndex;
            int empID = employees[index].employeeID;
            cont.deleteAttend(dat,empID);
        }

        private void absent_Checked(object sender, RoutedEventArgs e)
        {
            string dat = attendanceDate.Date.Value.ToString();
            int index = markAttendanceList.SelectedIndex;
            int empID = employees[index].employeeID;
            cont.absent(dat,empID);
        }

        private void absent_Unchecked(object sender, RoutedEventArgs e)
        {
            string dat = attendanceDate.Date.Value.ToString();
            int index = markAttendanceList.SelectedIndex;
            int empID = employees[index].employeeID;
            cont.deleteAttend(dat,empID);
        }
        private void leaveA_Checked(object sender, RoutedEventArgs e)
        {
            string dat = attendanceDate.Date.Value.ToString();
            int index = markAttendanceList.SelectedIndex;
            int empID = employees[index].employeeID;
            cont.leaveA(dat,empID);
        }

        private void leaveA_Unchecked(object sender, RoutedEventArgs e)
        {
            string dat = attendanceDate.Date.Value.ToString();
            int index = markAttendanceList.SelectedIndex;
            int empID = employees[index].employeeID;
            cont.deleteAttend(dat,empID);
        }
        private void leaveR_Checked(object sender, RoutedEventArgs e)
        {
            string dat = attendanceDate.Date.Value.ToString();
            int index = markAttendanceList.SelectedIndex;
            int empID = employees[index].employeeID;
            cont.leaveR(dat,empID);
        }

        private void leaveR_Unchecked(object sender, RoutedEventArgs e)
        {
            string dat = attendanceDate.Date.Value.ToString();
            int index = markAttendanceList.SelectedIndex;
            int empID = employees[index].employeeID;
            cont.deleteAttend(dat,empID);
        }
    }
}
