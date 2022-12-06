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
    public sealed partial class UpdateEmployee : Page
    {
        public UpdateEmployee()
        {
            this.InitializeComponent();
        }
        private async void ShowTermsOfUseContentDialogButton_Click(object sender, RoutedEventArgs e)
        {
            termsOfUseContentDialog.IsPrimaryButtonEnabled = true;
            ContentDialogResult result = await termsOfUseContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                // Terms of use were accepted.
            }
            else
            {
                // User pressed Cancel, ESC, or the back arrow.
                // Terms of use were not accepted.
            }
        }
    }
}
