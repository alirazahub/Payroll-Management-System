using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Timers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Timer = System.Timers.Timer;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Payroll_Management_System
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static ReadingEmployees currentUser;
        List<ReadingEmployees> employees;
        DataAccess cont = new DataAccess();
        public MainPage()
        {
            this.InitializeComponent();
            employees = cont.getUsers();
        }
        public void CheckBox_Changed (object sender, RoutedEventArgs e)
        {
            if (revealModeCheckBox.IsChecked == true)
            {
                passwordBox.PasswordRevealMode = PasswordRevealMode.Visible;
            }
            else
            {
                passwordBox.PasswordRevealMode = PasswordRevealMode.Hidden;
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Trace.TraceInformation(employees[0].ToString());
            foreach (ReadingEmployees ee in employees)
            {
                if (username.Text == ee.username && passwordBox.Password.ToString() == ee.password)
                {
                    currentUser = ee;
                  Frame.Navigate(typeof(MainFrame));
                }
               
                else
                {
                  errorTxt.Text = "* Invalid UserName or Password";
                }
            }
        }
    }
}
