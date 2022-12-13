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
    public sealed partial class HomePage : Page
    {
            List<ReadingEmployees> empByDeparts;
            List<ReadingEmployees> directors;
            List<ToDoList> todo;
            DataAccess cont = new DataAccess();
        public HomePage()
        {
            this.InitializeComponent();
            empByDeparts = cont.getEmployeeByDep("Research & Developement");
            directors = cont.getManagingDirectors();
            UserName.Text = MainPage.currentUser.employeeName.ToString();
            displayName.DisplayName = MainPage.currentUser.employeeName.ToString();
            UserEmail.Text = MainPage.currentUser.employeeEmail.ToString();
            Userusername.Text = MainPage.currentUser.username.ToString();
            todo = cont.getToDoList();
        }

        private void empDepart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comb = (ComboBoxItem)empDepart.SelectedItem;
            string seleted = comb.Content.ToString();
            empByDeparts = cont.getEmployeeByDep(seleted);
            empByDepart.ItemsSource = null;
            empByDepart.ItemsSource = empByDeparts;
        }
    }
}
