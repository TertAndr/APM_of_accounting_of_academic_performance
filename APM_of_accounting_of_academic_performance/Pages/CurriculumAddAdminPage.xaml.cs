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
    /// Логика взаимодействия для CurriculumAddAdminPage.xaml
    /// </summary>
    public partial class CurriculumAddAdminPage : Page
    {
        Curriculum_in_the_specialtysController currObj = new Curriculum_in_the_specialtysController();
        SudjectsController subjObj = new SudjectsController();
        SpecialtysController specObj = new SpecialtysController();
        private int CurrAllHours;

        public CurriculumAddAdminPage()
        {
            InitializeComponent();
            CurrentAddCoboBox.ItemsSource = specObj.GetSpecialtys();
            CurrentAddCoboBox.DisplayMemberPath = "specialty_name";
            CurrentAddCoboBox.SelectedValuePath = "id_specialty";
            CurrentAddCoboBox.SelectedIndex = 0;

            CurrentAddubjectComboBox.ItemsSource = subjObj.GetSudjects();
            CurrentAddubjectComboBox.DisplayMemberPath = "sudject_name";
            CurrentAddubjectComboBox.SelectedValuePath = "id_sudject";
            CurrentAddubjectComboBox.SelectedIndex = 0;
        }
        private string SetErrors()
        {
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(CurrentAddSemesterTextBox.Text)
                || Convert.ToInt32(CurrentAddSemesterTextBox.Text) > 2 || Convert.ToInt32(CurrentAddSemesterTextBox.Text) < 1)
            {
                errorString += "Проверьте правильность написания семестра\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentAddYearsTextBox.Text)
               || CurrentAddYearsTextBox.Text.Length > 2 )
            {
                errorString += "Пожалуйсто запишите год в формате 2 последних цифр\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentAddAllHoursTextBox.Text)
               || CurrentAddAllHoursTextBox.Text.Length > 4)
            {
                errorString += "Проверьте правильность написания общих часов называния предмета\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentAddHoursTheoryTextBox.Text)
               || CurrentAddHoursTheoryTextBox.Text.Length > 4)
            {
                errorString += "Проверьте правильность написания теоритических часов\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentAddHoursPracticTextBox.Text)
              || CurrentAddHoursPracticTextBox.Text.Length > 4)
            {
                errorString += "Проверьте правильность написания практических часов\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentAddHoursCoursTextBox.Text)
              || CurrentAddHoursCoursTextBox.Text.Length > 4)
            {
                errorString += "Проверьте правильность написания курсовых часов\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentAddCodePlaneTextBox.Text)
               || CurrentAddCodePlaneTextBox.Text.Length > 10 || CurrentAddCodePlaneTextBox.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания называния кода плана\n";
            }        
            return errorString;
        }


        private void CurriculumsAddButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                if (AddNewCurriculums())
            {
                MessageBox.Show("Добавление прошло успешно!");
                this.NavigationService.GoBack();
            }
            }
            else
            {
                MessageBox.Show(errors);
            }

            /// <summary>
            /// Осуществление добавления нового пользователя
            /// </summary>
            /// <returns>
            /// Возвращает:
            /// true - если все данные были введены корректно
            /// false - если произошла ошибка или данные введены некорректно  
            /// </returns>
            /// 

        }
        public bool AddNewCurriculums()
        {

            bool resultCurriculums = currObj.AddNewCurriculums(
                 Convert.ToInt32(CurrentAddCoboBox.SelectedValue),
                  Convert.ToInt32(CurrentAddubjectComboBox.SelectedValue),
                    Convert.ToInt32(CurrentAddAllHoursTextBox.Text),
                    Convert.ToInt32(CurrentAddHoursTheoryTextBox.Text),
                    Convert.ToInt32(CurrentAddHoursPracticTextBox.Text),
                    Convert.ToInt32(CurrentAddHoursCoursTextBox.Text),
                    Convert.ToInt32(CurrentAddSemesterTextBox.Text),
                     Convert.ToInt32(CurrentAddYearsTextBox.Text),
                    CurrentAddCodePlaneTextBox.Text
                    );
            return true;

        }

        private void CurrentAddSemesterTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }     
   
    }

}


  
