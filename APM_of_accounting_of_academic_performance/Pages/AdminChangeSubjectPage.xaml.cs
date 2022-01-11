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
    /// Логика взаимодействия для AdminChangeSubjectPage.xaml
    /// </summary>
    public partial class AdminChangeSubjectPage : Page
    {


        Sudjects subjj;
        SudjectsController subjObj = new SudjectsController();
        StringCheckClass strObj = new StringCheckClass();
        public AdminChangeSubjectPage(Sudjects currentSudjects)
        {
            InitializeComponent();

            ChangeSubjectsTextBox.Text = currentSudjects.sudject_name;
            ChangeSubjectsCodeTextBox.Text = currentSudjects.sudject_code;
            subjj = currentSudjects;
        }

        private string SetErrors()
        {
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(ChangeSubjectsTextBox.Text)
                || ChangeSubjectsTextBox.Text.Length > 75 || ChangeSubjectsTextBox.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания называния предмета\n";
            }
            if (String.IsNullOrWhiteSpace(ChangeSubjectsCodeTextBox.Text)
               || ChangeSubjectsCodeTextBox.Text.Length > 10 || ChangeSubjectsCodeTextBox.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания называния кода предмета\n";
            }
            return errorString;
        }
        private void SubjectChangeButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                try
            {
                subjObj.UpdateSubjects(
                ChangeSubjectsTextBox.Text,
                ChangeSubjectsCodeTextBox.Text,
                subjj);
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
    }
}
