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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Payroll_Management_System
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewAdmins : Page
    {
        DataAccess cont = new DataAccess();
        ReadingEmployees employee;
        List<ReadingEmployees> nonAdmins;
        
        public ViewAdmins()
        {
            this.InitializeComponent();
            nonAdmins = cont.getNonAdmins();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int EmpID = int.Parse(emppIdd.Text);
                employee = cont.getEmpDetail(EmpID);
                EmpName.Text = employee.employeeName;
                EmpDepart.Text = employee.departmentName;
                EmpDesig.Text = employee.designationName;
            }
            catch(Exception)
            {
                AdminsToggleTeaching.Title ="Error!";
                AdminsToggleTeaching.Subtitle ="Error Occurs";
                AdminsToggleTeaching.IsOpen = true;
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(emppIdd.Text);
                string UN = username.Text;
                string PD = password.Text;
                string res = cont.makeAdmin(id,UN,PD);
                if(res == "Done")
                {
                    AdminsToggleTeaching.Title = "Success!";
                    AdminsToggleTeaching.Subtitle = "This Employee Now can Access the System";
                    AdminsToggleTeaching.IsOpen = true;

                    WhoHaveAccess.ItemsSource = null;
                    nonAdmins = cont.getNonAdmins();
                    WhoHaveAccess.ItemsSource = nonAdmins;

                    emppIdd.Text = "";
                    username.Text = "";
                    password.Text = "";
                }
                else
                {
                    AdminsToggleTeaching.Title = "Error!";
                    AdminsToggleTeaching.Subtitle = "All Fields Must be Filled";
                    AdminsToggleTeaching.IsOpen = true;
                }
            }
            catch(Exception)
            {
                AdminsToggleTeaching.Title = "Error!";
                AdminsToggleTeaching.Subtitle = "All Fields Must be Filled";
                AdminsToggleTeaching.IsOpen = true;
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            int index = -1;
            index = WhoHaveAccess.SelectedIndex;
            if (index == -1)
            {
                AdminsToggleTeaching.Title = "Error!";
                AdminsToggleTeaching.Subtitle = "Select The Employee First";
                AdminsToggleTeaching.IsOpen = true;
            }
            else
            {
                int empID = nonAdmins[index].employeeID;
                string res = cont.passwordReset(empID);
                if (res == "Done")
                {
                    AdminsToggleTeaching.Title = "Success!";
                    AdminsToggleTeaching.Subtitle = "Password RESET Successfully";
                    AdminsToggleTeaching.IsOpen = true;
                }
                else
                {
                    AdminsToggleTeaching.Title = "Error!";
                    AdminsToggleTeaching.Subtitle = "Error: " + res;
                    AdminsToggleTeaching.IsOpen = true;
                }
            }

        }
        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            int index =-1;
            index = WhoHaveAccess.SelectedIndex;
            if(index == -1)
            {
                AdminsToggleTeaching.Title = "Error!";
                AdminsToggleTeaching.Subtitle = "Select The Employee First";
                AdminsToggleTeaching.IsOpen = true;
            }
            else
            {
                int empID = nonAdmins[index].employeeID;
                string res = cont.removeAdmin(empID);
                if(res == "Done")
                {
                    AdminsToggleTeaching.Title = "Success!";
                    AdminsToggleTeaching.Subtitle = "Now No More Admin";
                    AdminsToggleTeaching.IsOpen = true;

                    WhoHaveAccess.ItemsSource = null;
                    nonAdmins = cont.getNonAdmins();
                    WhoHaveAccess.ItemsSource = nonAdmins;
                }
                else
                {
                    AdminsToggleTeaching.Title = "Error!";
                    AdminsToggleTeaching.Subtitle = "Error: "+res;
                    AdminsToggleTeaching.IsOpen = true;
                }
            }
            
        }
    }
}
