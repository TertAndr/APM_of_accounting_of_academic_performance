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
    /// Логика взаимодействия для AdminLoudPage.xaml
    /// </summary>
    public partial class AdminLoudPage : Page
    {   
        LoadsController loadObj = new LoadsController();
        Core db = new Core();
        public AdminLoudPage()
        {
            InitializeComponent();
            LoudsAdminDataGrid.ItemsSource = loadObj.GetLoads().ToList();
  
        }

        private void AdminAddLoudButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminAddLoud());
        }

        private void ChengeLoudButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            this.NavigationService.Navigate(new AdminChangeLoudPage(button.DataContext as Models.Loads));

        }
       
        private void DropLoudButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Loads item = button.DataContext as Loads;
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {              
                if (loadObj.DropLoud(item))
                {
                    MessageBox.Show("Данные удалены");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }

            //обновление DataGrid
            LoudsAdminDataGrid.ItemsSource = db.context.Loads.ToList();
        }

        private void AllTimesButton_Click(object sender, RoutedEventArgs e)
        {
            LoudsAdminDataGrid.ItemsSource = loadObj.GetLoads().ToList();
        }
        private void LoudsDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = Convert.ToDateTime(LoudsDatePicker.SelectedDate);
            LoudsAdminDataGrid.ItemsSource = loadObj.GetLoadsDate(selectedDate).ToList();
        }
    }
}
