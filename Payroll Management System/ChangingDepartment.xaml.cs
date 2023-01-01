﻿using System;
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
    public sealed partial class ChangingDepartment : Page
    {
        DataAccess cont = new DataAccess();
        List<PrevAndNewDetails> details;
        List<ReadingEmployees> departments;
        List<string> departs = new List<string>();
        Employees current;
        public ChangingDepartment()
        {
            this.InitializeComponent();
            departments = cont.getAllDepartments();
            foreach (ReadingEmployees dep in departments)
            {
                departs.Add(dep.departmentName.ToString());
            }
            details = cont.getPrevAndNewDetails();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idd = empID.Text;
                int id = int.Parse(idd);
                current = cont.getEmployeesDetails(id);
                currentDepartment.Text = cont.getDepartName(current.employeeDepartment);
                empName.Text = current.employeeName;
                empNIC.Text = current.employeeNIC;
                updateDepartContentDialog.IsPrimaryButtonEnabled = true;
                ContentDialogResult result = await updateDepartContentDialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    string departName = empDepartments.SelectedItem.ToString();
                    int NewDepartID = cont.getDepartID(departName);
                    cont.updateDepart(id, current.employeeDepartment, NewDepartID, current.employeeDesignation, current.employeeDesignation);
                    
                    employeesDetails.ItemsSource = null;
                    details = cont.getPrevAndNewDetails();
                    employeesDetails.ItemsSource = details;

                    UpdateToggleTeaching.Subtitle = "Employee's Department Updated Successfully! Check details";
                    UpdateToggleTeaching.IsOpen = true;

                }
            }
            catch (Exception)
            {
                UpdateToggleTeaching.Title = "Error";
                UpdateToggleTeaching.Subtitle = "All Fields must be Filled";
                UpdateToggleTeaching.IsOpen = true;
            }
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
