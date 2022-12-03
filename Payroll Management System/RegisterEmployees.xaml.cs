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
        
        public RegisterEmployees()
        {
            this.InitializeComponent();
        }
        private void registerEmployee_Click(object sender, RoutedEventArgs e)
        {
            var gend = "";
            if (gender.SelectedIndex == 0)
            {
                gend = "Male";
            }
            else
            {
                gend = "Female";
            }
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
            newEmployee.employeeDepartment = employeeDepartment.SelectedIndex;
            newEmployee.employeeDesignation = employeeDesignation.SelectedIndex;
            // newEmployee.joiningDate = joiningDate;
            newEmployee.employeeDOB = employeeDOB.ToString();
            newEmployee.employeeDesignation = employeeDesignation.SelectedIndex;

            DataAccess cont = new DataAccess();
            cont.addEmployee(newEmployee);
            

        }
    }
}
