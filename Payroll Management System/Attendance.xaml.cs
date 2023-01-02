using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
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
            try
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
                if(obj.Presents == 0)
                {
                    AddAttendanceToggleTeaching.Title = "Not Found";
                    AddAttendanceToggleTeaching.Subtitle = "Attendance is not found for this date";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
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
            }catch(Exception ex)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Error: "+ex;
                AddAttendanceToggleTeaching.IsOpen = true;
            }
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await AttendanceDialog.ShowAsync();
        }

        private void present_Checked(object sender, RoutedEventArgs e)
        {
            string dat = "-";
            int index = -1;
            try
            {
                dat = attendanceDate.Date.Value.ToString();
            }
            catch (Exception)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select Date First";
                AddAttendanceToggleTeaching.IsOpen= true;
            }
            
            index = markAttendanceList.SelectedIndex;
            if (index == -1)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select the Employee Item First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }
            else
            {
                int empID = employees[index].employeeID;
                string res = cont.present(dat, empID);
                if (res == "Done")
                {
                    AddAttendanceToggleTeaching.Title = "Marked";
                    AddAttendanceToggleTeaching.Subtitle = "Employee with empployeeID: "+empID+" is Present";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
                else
                {
                    AddAttendanceToggleTeaching.Title = "Error";
                    AddAttendanceToggleTeaching.Subtitle = "Already Marked";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
            }

        }

        private void present_Unchecked(object sender, RoutedEventArgs e)
        {
            string dat = "-";
            int index = -1;
            try
            {
                dat = attendanceDate.Date.Value.ToString();
            }
            catch (Exception)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select Date First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }

            index = markAttendanceList.SelectedIndex;
            if (index == -1)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select the Employee Item First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }
            else
            {
                int empID = employees[index].employeeID;
                string res = cont.deleteAttend(dat, empID);
                if (res == "Done")
                {
                    AddAttendanceToggleTeaching.Title = "UnMarked";
                    AddAttendanceToggleTeaching.Subtitle = "Attendance Removed";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
                else
                {
                    AddAttendanceToggleTeaching.Title = "Error";
                    AddAttendanceToggleTeaching.Subtitle = "Attendance not Marked";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
            }
        }

        private void absent_Checked(object sender, RoutedEventArgs e)
        {
            string dat = "-";
            int index = -1;
            try
            {
                dat = attendanceDate.Date.Value.ToString();
            }
            catch (Exception)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select Date First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }

            index = markAttendanceList.SelectedIndex;
            if (index == -1)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select the Employee Item First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }
            else
            {
                int empID = employees[index].employeeID;
                string res = cont.absent(dat, empID);
                if (res == "Done")
                {
                    AddAttendanceToggleTeaching.Title = "Marked";
                    AddAttendanceToggleTeaching.Subtitle = "Employee with empployeeID: " + empID + " is absent";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
                else
                {
                    AddAttendanceToggleTeaching.Title = "Error";
                    AddAttendanceToggleTeaching.Subtitle = "Already Marked";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
            }
        }

        private void absent_Unchecked(object sender, RoutedEventArgs e)
        {
            string dat = "-";
            int index = -1;
            try
            {
                dat = attendanceDate.Date.Value.ToString();
            }
            catch (Exception)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select Date First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }

            index = markAttendanceList.SelectedIndex;
            if (index == -1)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select the Employee Item First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }
            else
            {
                int empID = employees[index].employeeID;
                string res = cont.deleteAttend(dat, empID);
                if(res == "Done")
                {
                    AddAttendanceToggleTeaching.Title = "UnMarked";
                    AddAttendanceToggleTeaching.Subtitle = "Attendance Removed";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
                else
                {
                    AddAttendanceToggleTeaching.Title = "Error";
                    AddAttendanceToggleTeaching.Subtitle = "Attendance not Marked";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
            }
        }
        private void leaveA_Checked(object sender, RoutedEventArgs e)
        {
            string dat = "-";
            int index = -1;
            try
            {
                dat = attendanceDate.Date.Value.ToString();
            }
            catch (Exception)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select Date First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }

            index = markAttendanceList.SelectedIndex;
            if (index == -1)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select the Employee Item First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }
            else
            {
                int empID = employees[index].employeeID;
                string res = cont.leaveA(dat, empID);
                if (res == "Done")
                {
                    AddAttendanceToggleTeaching.Title = "Marked";
                    AddAttendanceToggleTeaching.Subtitle = "Employee with empployeeID: " + empID + " is on Leave and Leave is Accepted";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
                else
                {
                    AddAttendanceToggleTeaching.Title = "Error";
                    AddAttendanceToggleTeaching.Subtitle = "Already Marked";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
            }
        }

        private void leaveA_Unchecked(object sender, RoutedEventArgs e)
        {
            string dat = "-";
            int index = -1;
            try
            {
                dat = attendanceDate.Date.Value.ToString();
            }
            catch (Exception)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select Date First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }

            index = markAttendanceList.SelectedIndex;
            if (index == -1)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select the Employee Item First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }
            else
            {
                int empID = employees[index].employeeID;
                string res = cont.deleteAttend(dat, empID);
                if (res == "Done")
                {
                    AddAttendanceToggleTeaching.Title = "UnMarked";
                    AddAttendanceToggleTeaching.Subtitle = "Attendance Removed";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
                else
                {
                    AddAttendanceToggleTeaching.Title = "Error";
                    AddAttendanceToggleTeaching.Subtitle = "Attendance is not Marked";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
            }
        }
        private void leaveR_Checked(object sender, RoutedEventArgs e)
        {
            string dat = "-";
            int index = -1;
            try
            {
                dat = attendanceDate.Date.Value.ToString();
            }
            catch (Exception)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select Date First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }

            index = markAttendanceList.SelectedIndex;
            if (index == -1)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select the Employee Item First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }
            else
            {
                int empID = employees[index].employeeID;
                string res = cont.leaveR(dat, empID);
                if (res == "Done")
                {
                    AddAttendanceToggleTeaching.Title = "Marked";
                    AddAttendanceToggleTeaching.Subtitle = "Employee with empployeeID: " + empID + " is on Leave and leave is Rejected";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
                else
                {
                    AddAttendanceToggleTeaching.Title = "Error";
                    AddAttendanceToggleTeaching.Subtitle = "Already Marked";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
            }
        }

        private void leaveR_Unchecked(object sender, RoutedEventArgs e)
        {
            string dat = "-";
            int index = -1;
            try
            {
                dat = attendanceDate.Date.Value.ToString();
            }
            catch (Exception)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select Date First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }

            index = markAttendanceList.SelectedIndex;
            if (index == -1)
            {
                AddAttendanceToggleTeaching.Title = "Error";
                AddAttendanceToggleTeaching.Subtitle = "Select the Employee Item First";
                AddAttendanceToggleTeaching.IsOpen = true;
            }
            else
            {
                int empID = employees[index].employeeID;
                string res = cont.deleteAttend(dat, empID);
                if(res == "Done")
                {
                    AddAttendanceToggleTeaching.Title = "UnMarked";
                    AddAttendanceToggleTeaching.Subtitle = "Attendance Removed";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
                else
                {
                    AddAttendanceToggleTeaching.Title = "Error";
                    AddAttendanceToggleTeaching.Subtitle = "Attendance is not Marked";
                    AddAttendanceToggleTeaching.IsOpen = true;
                }
            }
        }
    }
}
