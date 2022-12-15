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
    public sealed partial class MainFrame : Page
    {
        public MainFrame()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(HomePage));
            
        }

        private void NavView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            if(NavView.SelectedItem == RegisterEmployee)
            {
                mainFrame.Navigate(typeof(RegisterEmployees));

            }
            else if (NavView.SelectedItem == home)
            {
                mainFrame.Navigate(typeof(HomePage));

            }
            else if (NavView.SelectedItem == AllEmployee)
            {
                mainFrame.Navigate(typeof(AllEmployees));

            }
            else if (NavView.SelectedItem == attendance)
            {
                mainFrame.Navigate(typeof(Attendance));

            }
            else if (NavView.SelectedItem == salary)
            {
                mainFrame.Navigate(typeof(Salary));

            }
            else if (NavView.SelectedItem == bonus)
            {
                mainFrame.Navigate(typeof(Bonus));

            }
            else if (NavView.SelectedItem == report)
            {
                mainFrame.Navigate(typeof(Report));

            }
        }
    }
}
