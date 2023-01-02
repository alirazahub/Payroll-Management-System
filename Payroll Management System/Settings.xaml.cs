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
    public sealed partial class Settings : Page
    {
        DataAccess cont = new DataAccess();
        public Settings()
        {
            this.InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ChangingDesignation));
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ChangingDepartment));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ChangingSalary));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewAdmins));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomSearching));

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click_8(object sender, RoutedEventArgs e)
        {
            username.Text = MainPage.currentUser.username;
            password.Text = MainPage.currentUser.password;
            ChangeContentDialog.IsPrimaryButtonEnabled = true;
            ContentDialogResult result = await ChangeContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                string UN = username.Text;
                string PD = password.Text;
                int id = MainPage.currentUser.employeeID;
                string res = cont.makeAdmin(id,UN,PD);
                if(res == "Done")
                {
                    SettingToggleTeaching.Title = "Success";
                    SettingToggleTeaching.Subtitle = "Username or Password Changed Successfully";
                    SettingToggleTeaching.IsOpen= true;
                }
                else
                {
                    SettingToggleTeaching.Title = "Error";
                    SettingToggleTeaching.Title = "Error: "+res;
                    SettingToggleTeaching.IsOpen = true;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewDesignationOrDepartment));
        }
    }
}
