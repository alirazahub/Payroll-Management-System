using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
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
    public sealed partial class RegisterEmployees : Page
    {
        DataAccess cont = new DataAccess();
        List<ReadingEmployees> departments;
        List<ReadingEmployees> designations;
        List<string> departs = new List<string>();
        List<string> desigss = new List<string>();
        
        public RegisterEmployees()
        {
            this.InitializeComponent();
            departments = cont.getAllDepartments();
            designations = cont.getAllDesignations();
            foreach(ReadingEmployees dep in departments)
            {
                departs.Add(dep.departmentName.ToString());
            }
            foreach (ReadingEmployees desigs in designations)
            {
                desigss.Add(desigs.designationName.ToString());
            }
        }
        private void registerEmployee_Click(object sender, RoutedEventArgs e)
        {
            DataAccess cont = new DataAccess();
            ComboBoxItem combo = (ComboBoxItem)gender.SelectedItem;
            string gend = combo.Content.ToString();

            //ComboBoxItem combo2 = (ComboBoxItem)empDepartments.SelectedItem;
            string departName = empDepartments.SelectedItem.ToString();
            int departID = cont.getDepartID(departName);

            //ComboBoxItem combo3 = (ComboBoxItem)empDesignation.SelectedItem;
            string desigName = empDesignation.SelectedItem.ToString();
            int desigID = cont.getDesigID(desigName);

            Employees newEmployee = new Employees();
            newEmployee.employeeName = employeeName.Text;
            newEmployee.employeeNIC = employeeNIC.Text;
            newEmployee.employeeContact = employeeContact.Text;
            newEmployee.employeeEmail = employeeEmail.Text;
            newEmployee.gender = gend;
            newEmployee.houseNo = houseNo.Text;
            newEmployee.street = street.Text;
            newEmployee.town = town.Text;
            newEmployee.city = city.Text;
            newEmployee.employeeDepartment = departID;
            newEmployee.employeeDesignation = desigID;
            newEmployee.joiningDate = joiningDate.Date.Value.ToString();
            newEmployee.employeeDOB = employeeDOB.Date.Value.ToString();

            string res = cont.addEmployee(newEmployee);
            if(res == "Done")
            {
                RegisterToggleTeaching.IsOpen = true;
                employeeName.Text = "";
                employeeNIC.Text = "";
                employeeContact.Text = "";
                employeeEmail.Text = "";
                houseNo.Text = "";
                street.Text = "";
                town.Text = "";
                city.Text = "";
            }
            else
            {
                FailToggleTeaching.Subtitle = res;
                FailToggleTeaching.IsOpen = true;
            }
        }
    }
}
