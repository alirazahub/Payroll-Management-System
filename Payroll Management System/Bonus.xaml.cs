using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
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
    public sealed partial class Bonus : Page
    {
        List<BonusClass> bonus;
        DataAccess cont = new DataAccess();
        public Bonus()
        {
            this.InitializeComponent();
            bonus = cont.getBonus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BonusClass newBonus = new BonusClass();

            try
            {
                newBonus.employeeID = Int32.Parse(empID.Text);
                newBonus.date = Datee.Date.Value.ToString();
                newBonus.hours = Int32.Parse(hourss.Text);
                newBonus.details = detailss.Text;
                DataAccess cont = new DataAccess();
                string res = cont.addBonus(newBonus);
                if (res == "Done")
                {
                    bonus = cont.getBonus();
                    empID.Text = "";
                    hourss.Text = "";
                    detailss.Text = "";
                    bonusList.ItemsSource = null;
                    bonusList.ItemsSource = bonus;
                    BonusToggleTeaching.IsOpen = true;
                }
                else
                {
                    faliureToggleTeaching.Subtitle = res;
                    faliureToggleTeaching.IsOpen = true;
                }
            }catch(Exception ex)
            {
                faliureToggleTeaching.Title = "Error";
                faliureToggleTeaching.Subtitle = "Error: "+ex;
                faliureToggleTeaching.IsOpen = true;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
            int  st = Int32.Parse(empID.Text);
            List < String > lis = new List < String >();
            lis = cont.getEmployeeName(st);
            EmployeeName.Text = lis[0];
            }
            catch (Exception)
            {
            EmployeeName.Text = "Not Found";
            }
        }
    }
}
