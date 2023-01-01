using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
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
    public sealed partial class AllEmployees : Page
    {
        List<ReadingEmployees> designations;
        List<string> emps = new List<string>();
        

        List<ReadingEmployees> employees;
        List<Employees> employeeDetails;
        Employees employe;
        DataAccess cont = new DataAccess();
        public AllEmployees()
        {
            this.InitializeComponent();
            employees = cont.getUsers();
            foreach(ReadingEmployees emp in employees)
            {
                emps.Add(emp.employeeName.ToString());
            }
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Since selecting an item will also change the text,
            // only listen to changes caused by user entering text.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suitableItems = new List<string>();
                var splitText = sender.Text.ToLower().Split(" ");
                foreach (var cat in emps)
                {
                    var found = splitText.All((key) =>
                    {
                        return cat.ToLower().Contains(key);
                    });
                    if (found)
                    {
                        suitableItems.Add(cat);
                    }
                }
                if (suitableItems.Count == 0)
                {
                    suitableItems.Add("No results found");
                }
                sender.ItemsSource = suitableItems;
            }
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterEmployees));

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            termsOfUseContentDialog.IsPrimaryButtonEnabled = true;
            ContentDialogResult result = await termsOfUseContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                
                 string empID = empIDToEdit.Text;
                int id = Convert.ToInt32(empID);  
                employeeDetails = cont.getEmployeeDetails(id);
                employe = employeeDetails[0];

                employeeID.Text = empID;
                employeeName.Text = employe.employeeName;
                employeeNIC.Text = employe.employeeNIC;
                employeeEmail.Text = employe.employeeEmail;
                employeeContact.Text = employe.employeeContact;
                gender.Text = employe.gender;
                houseNo.Text = employe.houseNo;
                street.Text = employe.street;
                town.Text = employe.town;
                city.Text = employe.city;
                employeeDOB.Text = employe.employeeDOB;
                editEmployeeDialog.IsPrimaryButtonEnabled = true;
                ContentDialogResult result2 = await editEmployeeDialog.ShowAsync();
                if (result2 == ContentDialogResult.Primary)
                {
                    Employees updatedEmployee= new Employees();
                    updatedEmployee.employeeName = employeeName.Text;
                    updatedEmployee.employeeNIC = employeeNIC.Text;
                    updatedEmployee.employeeContact = employeeContact.Text;
                    updatedEmployee.employeeDOB = employeeDOB.Text;
                    updatedEmployee.employeeEmail = employeeEmail.Text;
                    updatedEmployee.town = town.Text;
                    updatedEmployee.city = city.Text;
                    updatedEmployee.houseNo = houseNo.Text;
                    updatedEmployee.street = street.Text;
                    updatedEmployee.gender = gender.Text;

                    cont.updateEmployee(updatedEmployee,id);
                    employees = cont.getUsers();
                    employeeList.ItemsSource = null;
                    employeeList.ItemsSource = employees;
                }

            }
            else
            {
                // User pressed Cancel, ESC, or the back arrow.
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
