using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Threading.Tasks;
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

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            AddTaskContentDialog.IsPrimaryButtonEnabled = true;
            ContentDialogResult result = await AddTaskContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                string tas = task.Text;
                string date = System.DateTime.Now.Date.ToString("yyyy/MM/dd");
                if(task.Text == "")
                {
                    taskToggleTeaching.Subtitle = "Field must be Filled*";
                    taskToggleTeaching.IsOpen = true;
                }
                else
                {
                    cont.addNewTask(date,tas);
                    taskToggleTeaching.IsOpen= true;
                    tasks.ItemsSource = null;
                    todo = cont.getToDoList();
                    tasks.ItemsSource = todo;
                    task.Text = "";
                }
            }
            else
            {

            }
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            int index = -1;
            index = tasks.SelectedIndex;
            if(index == -1)
            {
                taskToggleTeaching.Subtitle = "Task Must be Selected ";
                taskToggleTeaching.IsOpen = true;
            }
            else
            {

            int TaskID = todo[index].taskID;
            string TaskName = todo[index].Details;
            string TaskStatus = todo[index].status;
            taskName.Text = TaskName;
            if (TaskStatus == "Pending")
            {
                taskStatus.SelectedIndex= 0;
            }
            else
            {
                taskStatus.SelectedIndex = 1;
            }
            taskName.Text = TaskName;

            UpdateTaskContentDialog.IsPrimaryButtonEnabled = true;
            ContentDialogResult result = await UpdateTaskContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                ComboBoxItem co = (ComboBoxItem)taskStatus.SelectedItem;
                string selected = co.Content.ToString();
                string task = taskName.Text;
                string sta = selected;
                string res = cont.updateTask(TaskID,task,sta);

                if(res == "Done")
                {
                    taskToggleTeaching.Subtitle = "Task Updated Successfully!";
                    taskToggleTeaching.IsOpen = true;
                    tasks.ItemsSource = null;
                    todo = cont.getToDoList();
                    tasks.ItemsSource = todo;
                }
                else
                {
                    taskToggleTeaching.Subtitle =res;
                    taskToggleTeaching.IsOpen = true;
                }

            }
            else
            {
                
            }

            }
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            int index = -1;
            index = tasks.SelectedIndex;
            if (index == -1)
            {
                taskToggleTeaching.Subtitle = "Task Must be Selected ";
                taskToggleTeaching.IsOpen = true;
            }
            else
            {
                int TaskID = todo[index].taskID;
                cont.deleteTask(TaskID);
                tasks.ItemsSource = null;
                todo = cont.getToDoList();
                tasks.ItemsSource = todo;
                taskToggleTeaching.Subtitle = "Task Deleted SuccesFully!";
                taskToggleTeaching.IsOpen = true;
            }
        }
    }
}
