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
    /// Логика взаимодействия для CurriculumСhangeAdminPage.xaml
    /// </summary>
    public partial class CurriculumСhangeAdminPage : Page
    {
        Curriculum_in_the_specialtys curriculum;
        Curriculum_in_the_specialtysController currObj = new Curriculum_in_the_specialtysController();
        SudjectsController subjObj = new SudjectsController();
        SpecialtysController specObj = new SpecialtysController();

        public CurriculumСhangeAdminPage(Curriculum_in_the_specialtys currentCurriculum)
        {
            InitializeComponent();

            curriculum = currentCurriculum;

            CurrentChangeCoboBox.ItemsSource = specObj.GetSpecialtys();
            CurrentChangeCoboBox.DisplayMemberPath = "specialty_name";
            CurrentChangeCoboBox.SelectedValuePath = "id_specialty";
            CurrentChangeCoboBox.SelectedValue = currentCurriculum.id_specialty ;

            CurrentChangeSubjectComboBox.ItemsSource = subjObj.GetSudjects();
            CurrentChangeSubjectComboBox.DisplayMemberPath = "sudject_name";
            CurrentChangeSubjectComboBox.SelectedValuePath = "id_sudject";
            CurrentChangeSubjectComboBox.SelectedValue = currentCurriculum.id_sudject ;

            CurrentChangeSemesterTextBox.Text = (currentCurriculum.semester_numbers).ToString();
            CurrentChangeYearsTextBox.Text = (currentCurriculum.year_of_study).ToString();
            CurrentChangeAllHoursTextBox.Text = (currentCurriculum.all_hours).ToString();
            CurrentChangeCodePlaneTextBox.Text = currentCurriculum.code;
            CurrentChangeHoursTheoryTextBox.Text = (currentCurriculum.sudject_hours_theory).ToString();
            CurrentChangeHoursPracticTextBox.Text = (currentCurriculum.sudject_hours_practice).ToString();
            CurrentChangeHoursCoursTextBox.Text = (currentCurriculum.sudject_hours_course_design).ToString();

        }
        private string SetErrors()
        {
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(CurrentChangeSemesterTextBox.Text)
                || Convert.ToInt32(CurrentChangeSemesterTextBox.Text) > 2 || Convert.ToInt32(CurrentChangeSemesterTextBox.Text) < 1)
            {
                errorString += "Проверьте правильность написания семестра\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentChangeYearsTextBox.Text)
               || CurrentChangeYearsTextBox.Text.Length > 2)
            {
                errorString += "Пожалуйсто запишите год в формате 2 последних цифр\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentChangeAllHoursTextBox.Text)
               || CurrentChangeAllHoursTextBox.Text.Length > 4)
            {
                errorString += "Проверьте правильность написания общих часов называния предмета\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentChangeHoursTheoryTextBox.Text)
               || CurrentChangeHoursTheoryTextBox.Text.Length > 4)
            {
                errorString += "Проверьте правильность написания теоритических часов\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentChangeHoursPracticTextBox.Text)
              || CurrentChangeHoursPracticTextBox.Text.Length > 4)
            {
                errorString += "Проверьте правильность написания практических часов\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentChangeHoursCoursTextBox.Text)
              || CurrentChangeHoursCoursTextBox.Text.Length > 4)
            {
                errorString += "Проверьте правильность написания курсовых часов\n";
            }
            if (String.IsNullOrWhiteSpace(CurrentChangeCodePlaneTextBox.Text)
               || CurrentChangeCodePlaneTextBox.Text.Length > 10 || CurrentChangeCodePlaneTextBox.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания называния кода плана\n";
            }         
            return errorString;
        }
        private void UpdateCurrentButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                try
            {
                bool resultCurriculums = currObj.UpdateCurriculums(
                  Convert.ToInt32(CurrentChangeCoboBox.SelectedValue),
                   Convert.ToInt32(CurrentChangeSubjectComboBox.SelectedValue),
                     Convert.ToInt32(CurrentChangeAllHoursTextBox.Text),
                     Convert.ToInt32(CurrentChangeHoursTheoryTextBox.Text),
                     Convert.ToInt32(CurrentChangeHoursPracticTextBox.Text),
                     Convert.ToInt32(CurrentChangeHoursCoursTextBox.Text),
                     Convert.ToInt32(CurrentChangeSemesterTextBox.Text),
                      Convert.ToInt32(CurrentChangeYearsTextBox.Text),
                     CurrentChangeCodePlaneTextBox.Text,
                      curriculum);
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

        private void CurrentChangeSemesterTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
