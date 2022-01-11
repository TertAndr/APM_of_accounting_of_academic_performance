using APM_of_accounting_of_academic_performance.Controllers;
using APM_of_accounting_of_academic_performance.Models;
using APMClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace APM_of_accounting_of_academic_performance.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminChangeLoudPage.xaml
    /// </summary>
    public partial class AdminChangeLoudPage : Page
    {

        Loads curentLouds;
        Curriculum_in_the_specialtysController currObj = new Curriculum_in_the_specialtysController();
        TeachersController teashObj = new TeachersController();
        GroupsController groupObj = new GroupsController();
        Type_of_clocksController clockObj = new Type_of_clocksController();
        LoadsController loudObj = new LoadsController();
        StringCheckClass strObj = new StringCheckClass();
        public AdminChangeLoudPage(Loads currentLouds)
        {
            InitializeComponent();

            curentLouds = currentLouds;
            FIOCombobox.ItemsSource = teashObj.GetTeachers();
            FIOCombobox.DisplayMemberPath = "TeacherFIO";
            FIOCombobox.SelectedValuePath = "id_teacher";
            FIOCombobox.SelectedValue = currentLouds.Teachers.id_teacher ;



            SpecialityCombobox.ItemsSource = currObj.GetCurriculum_in_the_specialtys();
            SpecialityCombobox.DisplayMemberPath = "specialtystInfo";
            SpecialityCombobox.SelectedValuePath = "id_curriculum_in_the_specialty";
            SpecialityCombobox.SelectedValue = currentLouds.id_curriculum_in_the_specialty ;

            GroupsCombobox.ItemsSource = groupObj.GetGroups();
            GroupsCombobox.DisplayMemberPath = "groups_name";
            GroupsCombobox.SelectedValuePath = "id_group";
            GroupsCombobox.SelectedValue = currentLouds.id_group ;


            ClocksTypeCombobox.ItemsSource = clockObj.GetType_of_clocks();
            ClocksTypeCombobox.DisplayMemberPath = "type_of_clock_name";
            ClocksTypeCombobox.SelectedValuePath = "id_type_of_clock";
            ClocksTypeCombobox.SelectedValue = currentLouds.id_type_of_clock ;

            DateLoudDatePicker.SelectedDate = currentLouds.date;

            HoursTextBox.Text = (currentLouds.loud_hours).ToString();
        }
        private string SetErrors()
        {
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(HoursTextBox.Text)
                || HoursTextBox.Text.Length > 3)
            {
                errorString += "Проверьте правильность написания колличества часов\n";
            }
            return errorString;
        }
        private void LoudsChangeButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                try
            {
                         loudObj.UpdateLouds(
                         Convert.ToInt32(FIOCombobox.SelectedValue),
                          Convert.ToInt32(GroupsCombobox.SelectedValue),
                          Convert.ToInt32(SpecialityCombobox.SelectedValue),
                          Convert.ToDateTime(DateLoudDatePicker.SelectedDate),
                          Convert.ToInt32(HoursTextBox.Text),
                        Convert.ToInt32(ClocksTypeCombobox.SelectedValue),
                        curentLouds);
                {
                    MessageBox.Show("Данные успешно обновлены!");
                    this.NavigationService.GoBack();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            }
            else
            {
                MessageBox.Show(errors);
            }

        }

        private void HoursTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
