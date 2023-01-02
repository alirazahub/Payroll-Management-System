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
    public sealed partial class NewDesignationOrDepartment : Page
    {
        DataAccess cont = new DataAccess();
        List<DesigDeparts> departs;
        List<DesigDeparts> desigs;
        public NewDesignationOrDepartment()
        {
            this.InitializeComponent();
            departs = cont.getDepartments();
            depart.ItemsSource = departs;
            desigs = cont.getDesignations();
            desig.ItemsSource = desigs;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DepartmentName.Text == "")
                {
                    throw new Exception("All Fields Must Be filled");
                }
                string dname = DepartmentName.Text;
                string res = cont.addNewDepartment(dname);
                if (res == "Done")
                {
                    ToggleTeaching.Title = "Added !";
                    ToggleTeaching.Subtitle = "Department Added Successfully!";
                    ToggleTeaching.IsOpen = true;

                    departs = cont.getDepartments();
                    depart.ItemsSource = null;
                    depart.ItemsSource = departs;
                }
                else
                {
                    ToggleTeaching.Title = "Error: ";
                    ToggleTeaching.Subtitle = "Error: " + res;
                    ToggleTeaching.IsOpen = true;
                }
            }catch(Exception ex)
            {
                ToggleTeaching.Title = "Error: ";
                ToggleTeaching.Subtitle = "Error: " + ex;
                ToggleTeaching.IsOpen = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DesignationName.Text == "" || perDay.Text == "" || BonusperHour.Text == "")
                {
                    throw new Exception("All Fields Must Be filled");
                }
                string dname = DesignationName.Text;
                int perDayy = int.Parse(perDay.Text);
                int perhour = int.Parse(BonusperHour.Text);
                string res = cont.addNewDesignation(dname, perDayy, perhour);
                if (res == "Done")
                {
                    ToggleTeaching.Title = "Added !";
                    ToggleTeaching.Subtitle = "Designation Added Successfully!";
                    ToggleTeaching.IsOpen = true;

                    desigs = cont.getDesignations();
                    desig.ItemsSource = null;
                    desig.ItemsSource = desigs;
                }
                else
                {
                    ToggleTeaching.Title = "Added !";
                    ToggleTeaching.Subtitle = "Department Added Successfully!";
                    ToggleTeaching.IsOpen = true;
                }
            }catch(Exception ex)
            {
                ToggleTeaching.Title = "Error";
                ToggleTeaching.Subtitle = "Error: "+ex;
                ToggleTeaching.IsOpen = true;
            }
        }
    }
}
