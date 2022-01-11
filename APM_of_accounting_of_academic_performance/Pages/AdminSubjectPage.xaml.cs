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
    /// Логика взаимодействия для AdminSubjectPage.xaml
    /// </summary>
    public partial class AdminSubjectPage : Page
    {
        Core db = new Core();
        SudjectsController subjuObj = new SudjectsController();
        StringCheckClass strObj = new StringCheckClass();
        public AdminSubjectPage()
        {
            InitializeComponent();
            SudjectsDataGrid.ItemsSource = subjuObj.GetSudjects().ToList();
            SudjectsDataGrid.ItemsSource = db.context.Sudjects.ToList();
        }

        private string SetErrors()
        {
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(AddSubjectTextBlock.Text)
                || AddSubjectTextBlock.Text.Length > 75 || AddSubjectTextBlock.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания называния предмета\n";
            }
            if (String.IsNullOrWhiteSpace(AddSubjectCodeTextBlock.Text)
               || AddSubjectCodeTextBlock.Text.Length > 10 || AddSubjectCodeTextBlock.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания называния кода предмета\n";
            }
            return errorString;
        }


        private void AddSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                if (AddNewSubject())
            {
                MessageBox.Show("Добавление прошло успешно!");
            }
            //обновление DataGrid
            SudjectsDataGrid.ItemsSource = db.context.Sudjects.ToList();
            }
            else
            {
                MessageBox.Show(errors);
            }
        }


        private void ChangesSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Sudjects currentSudjects = button.DataContext as Sudjects;
            this.NavigationService.Navigate(new AdminChangeSubjectPage(currentSudjects));
        }
        private void DeliteSubjectButton(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Sudjects item = button.DataContext as Sudjects;


            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {

                if (subjuObj.DropSudjects(item))
                {
                    MessageBox.Show("Данные удалены");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }

            //обновление DataGrid
            SudjectsDataGrid.ItemsSource = db.context.Sudjects.ToList();
        }


        public bool AddNewSubject()
        {
            try
            {
                bool resultSubject = subjuObj.AddNewSubjects(
                    AddSubjectTextBlock.Text,
                    AddSubjectCodeTextBlock.Text);

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }













    }



}
