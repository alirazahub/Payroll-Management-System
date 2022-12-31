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
    public sealed partial class ChangingSalary : Page
    {
        DataAccess cont = new DataAccess();
        List<ReadingEmployees> designations;
        List<Designations> Alldesignations;
        List<ChangedSalaries> previousSalaries;
        Designations desigDetails;
        List<string> desigss = new List<string>();
        public ChangingSalary()
        {
            this.InitializeComponent();
            designations = cont.getAllDesignations();
            Alldesignations = cont.getAllDesigs();
            previousSalaries = cont.getPreviousSalaries();
            foreach (ReadingEmployees desigs in designations)
            {
                desigss.Add(desigs.designationName.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void desigsss_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string desigName = desigsss.SelectedItem.ToString();
            int desigID = cont.getDesigID(desigName);
            string desId = Convert.ToString(desigID);
            DesigID.Text= desId;
            desigDetails = cont.getDesigs(desigID);
            string PD = Convert.ToString(desigDetails.PerDay);
            perDayy.Text = PD;
            string PH = Convert.ToString(desigDetails.BonusPerHour);
            perHourr.Text = PH;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int desigID = int.Parse(DesigID.Text);
                int perDay = int.Parse(perDayy.Text);
                int perHour = int.Parse(perHourr.Text);
                string date = System.DateTime.Now.ToString("yyyy/MM/dd");
                int changedBy = MainPage.currentUser.employeeID;
                string res = cont.changeSalary(desigID, perDay, perHour, date, changedBy);
                if(res == "Done")
                {
                    SalaryChangedToggleTeaching.IsOpen= true;
                    DesigID.Text = "";
                    perDayy.Text = "";
                    perHourr.Text = "";
                    desigList.ItemsSource = null;
                    previousSalary.ItemsSource = null;
                    Alldesignations = cont.getAllDesigs();
                    previousSalaries = cont.getPreviousSalaries();
                    desigList.ItemsSource = Alldesignations;
                    previousSalary.ItemsSource = previousSalaries;
                }
                else
                {
                    SalaryChangedToggleTeaching.Title = "Faliure";
                    SalaryChangedToggleTeaching.Subtitle = res;
                    SalaryChangedToggleTeaching.IsOpen= true;
                }
            }
            catch (Exception)
            {
                SalaryChangedToggleTeaching.Title = "Faliure";
                SalaryChangedToggleTeaching.Subtitle = "All Fields Must be Filled";
                SalaryChangedToggleTeaching.IsOpen = true;
            }
        }
    }
}
