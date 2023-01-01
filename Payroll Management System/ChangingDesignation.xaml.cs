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
using Windows.UI.Xaml.Printing;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Payroll_Management_System
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChangingDesignation : Page
    {
        DataAccess cont = new DataAccess();
        List<PrevAndNewDetails> details;
        List<ReadingEmployees> designations;
        List<string> desigss = new List<string>();
        Employees current;
        public ChangingDesignation()
        {
            this.InitializeComponent();
            designations = cont.getAllDesignations();
            foreach (ReadingEmployees desigs in designations)
            {
                desigss.Add(desigs.designationName.ToString());
            }
            details = cont.getPrevAndNewDetails();
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string idd = empID1.Text;
                int id = int.Parse(idd);
                current = cont.getEmployeesDetails(id);
                currentDesignation.Text = cont.getDesigName(current.employeeDesignation);
                empName1.Text = current.employeeName;
                empNIC1.Text = current.employeeNIC;

                updateDesigContentDialog.IsPrimaryButtonEnabled = true;
                ContentDialogResult result = await updateDesigContentDialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    string desigName = empDesignation.SelectedItem.ToString();
                    int NewDesigID = cont.getDesigID(desigName);
                    cont.updateDesig(id, current.employeeDepartment, current.employeeDepartment, current.employeeDesignation, NewDesigID);
                    
                    employeesDetails.ItemsSource = null;
                    details = cont.getPrevAndNewDetails();
                    employeesDetails.ItemsSource = details;
                    
                    UpdateToggleTeaching.Subtitle = "Employee's Designation Updated Successfully! Check details";
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
