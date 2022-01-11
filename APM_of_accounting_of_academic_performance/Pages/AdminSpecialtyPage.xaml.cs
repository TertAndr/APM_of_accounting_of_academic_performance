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
    /// Логика взаимодействия для AdminSpecialtyPage.xaml
    /// </summary>
    public partial class AdminSpecialtyPage : Page
    {
        Core db = new Core();
        SpecialtysController specObj = new SpecialtysController();
        StringCheckClass strObj = new StringCheckClass();
        public AdminSpecialtyPage()
        {
            InitializeComponent();
            SpecialtysDataGrid.ItemsSource = specObj.GetSpecialtys().ToList();
            SpecialtysDataGrid.ItemsSource = db.context.Specialtys.ToList();
        }

        private string SetErrors()
        {
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(SpecialtysNameTextBlock.Text)
                || SpecialtysNameTextBlock.Text.Length > 75 || SpecialtysNameTextBlock.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания называния специальности\n";
            }
            if (String.IsNullOrWhiteSpace(SpecialtysCodeTextBox.Text)
               || SpecialtysCodeTextBox.Text.Length > 10 || SpecialtysCodeTextBox.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания кода специальности\n";
            }
            return errorString;
        }


        private void AddSpecialtysButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                if (AddNewSpecialtys())
            {
                MessageBox.Show("Добавление прошло успешно!");
            }
            //обновление DataGrid
            SpecialtysDataGrid.ItemsSource = db.context.Specialtys.ToList();
            }
            else
            {
                MessageBox.Show(errors);
            }
        }
        private void ChangeSpecialtysButton(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Specialtys currentSpecialtys = button.DataContext as Specialtys;
            this.NavigationService.Navigate(new AdminChangeSpecialyPage(currentSpecialtys));
        }
        private void DeliteSpecialtysButton(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Specialtys item = button.DataContext as Specialtys;


            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (specObj.DropSpecialtys(item))
                {
                    MessageBox.Show("Данные удалены");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }

            //обновление DataGrid
            SpecialtysDataGrid.ItemsSource = db.context.Specialtys.ToList();
        }
        public bool AddNewSpecialtys()
        {
            try
            {
                bool resultSpecialtys = specObj.AddNewSpecialtys(
                    SpecialtysNameTextBlock.Text,
                    SpecialtysCodeTextBox.Text);

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
