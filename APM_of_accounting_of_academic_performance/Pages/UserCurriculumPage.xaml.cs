using APM_of_accounting_of_academic_performance.Controllers;
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
    /// Логика взаимодействия для UserCurriculumPage.xaml
    /// </summary>
    public partial class UserCurriculumPage : Page
    {
        Core db = new Core();
        SpecialtysController specObj = new SpecialtysController();
        Curriculum_in_the_specialtysController currObj = new Curriculum_in_the_specialtysController();
        public UserCurriculumPage()
        {
            InitializeComponent();
            //обновление DataGrid
            CurrentUsersDataGrid.ItemsSource = db.context.Curriculum_in_the_specialtys.ToList();

            CurrentUsersDataGrid.ItemsSource = currObj.GetCurriculum_in_the_specialtys().ToList();

            SpecialtysCombobox.ItemsSource = specObj.GetSpecialtys();
            SpecialtysCombobox.DisplayMemberPath = "specialty_name";
            SpecialtysCombobox.SelectedValuePath = "id_specialty";
            SpecialtysCombobox.SelectedIndex = 0;
        }
        private void AllTimesButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentUsersDataGrid.ItemsSource = currObj.GetCurriculum_in_the_specialtys().ToList();
        }

        private void YearsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string selectedYears = YearsTextBox.Text;
            if (selectedYears.Length > 0)
            {
                int selectedIntYears = Convert.ToInt32(selectedYears);
                CurrentUsersDataGrid.ItemsSource = currObj.GetCurriculum_in_the_specialtysYears(selectedIntYears).ToList();
            }
            if (selectedYears.Length == 0)
            {
                CurrentUsersDataGrid.ItemsSource = currObj.GetCurriculum_in_the_specialtys().ToList();
            }
        }

        private void SpecialtysCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedSpecial = Convert.ToInt32(SpecialtysCombobox.SelectedValue);
            CurrentUsersDataGrid.ItemsSource = currObj.GetCurriculum_in_the_specialtysSpecialtys(selectedSpecial).ToList();
        }

        private void YearsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

    }
}
