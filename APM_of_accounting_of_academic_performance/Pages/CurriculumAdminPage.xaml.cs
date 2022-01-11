using APM_of_accounting_of_academic_performance.Controllers;
using APM_of_accounting_of_academic_performance.Models;
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
    /// Логика взаимодействия для CurriculumAdminPage.xaml
    /// </summary>
    public partial class CurriculumAdminPage : Page
    {
        Core db = new Core();
        Curriculum_in_the_specialtysController currObj = new Curriculum_in_the_specialtysController();
        SpecialtysController specObj = new SpecialtysController();
        public CurriculumAdminPage()
        {
           
            InitializeComponent();
            //обновление DataGrid
            CurrentAdminsDataGrid.ItemsSource = db.context.Curriculum_in_the_specialtys.ToList();

            CurrentAdminsDataGrid.ItemsSource = currObj.GetCurriculum_in_the_specialtys().ToList();

            SpecialtysCombobox.ItemsSource = specObj.GetSpecialtys();
            SpecialtysCombobox.DisplayMemberPath = "specialty_name";
            SpecialtysCombobox.SelectedValuePath = "id_specialty";
            SpecialtysCombobox.SelectedIndex = 0;
        }

        private void AddCurrentAdminsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CurriculumAddAdminPage());
        }

        private void ChangeCurrentButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Models.Curriculum_in_the_specialtys currentCurriculum = button.DataContext as Models.Curriculum_in_the_specialtys;
            this.NavigationService.Navigate(new CurriculumСhangeAdminPage(currentCurriculum));

        }


        private void DropCurrentButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Curriculum_in_the_specialtys item = button.DataContext as Curriculum_in_the_specialtys;


            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {

                if (currObj.DropCurriculum_in_the_specialtys(item))
                {
                    MessageBox.Show("Данные удалены");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }

            //обновление DataGrid
            CurrentAdminsDataGrid.ItemsSource = db.context.Curriculum_in_the_specialtys.ToList();
        }

        private void AllTimesButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentAdminsDataGrid.ItemsSource = currObj.GetCurriculum_in_the_specialtys().ToList();
        }

        private void YearsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string selectedYears = YearsTextBox.Text;
            if (selectedYears.Length > 0)
            {
                int selectedIntYears = Convert.ToInt32(selectedYears);
                CurrentAdminsDataGrid.ItemsSource = currObj.GetCurriculum_in_the_specialtysYears(selectedIntYears).ToList();
            }
            if  (selectedYears.Length == 0)
            {
                CurrentAdminsDataGrid.ItemsSource = currObj.GetCurriculum_in_the_specialtys().ToList();
            }
        }

        private void SpecialtysCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedSpecial = Convert.ToInt32(SpecialtysCombobox.SelectedValue);
            CurrentAdminsDataGrid.ItemsSource = currObj.GetCurriculum_in_the_specialtysSpecialtys(selectedSpecial).ToList();
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
