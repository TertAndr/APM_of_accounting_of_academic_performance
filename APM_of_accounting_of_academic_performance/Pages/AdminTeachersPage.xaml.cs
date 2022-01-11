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
using APM_of_accounting_of_academic_performance.Models;
using APM_of_accounting_of_academic_performance.Controllers;

namespace APM_of_accounting_of_academic_performance.Pages
{
    public partial class AdminTeachersPage : Page
    {
        Core db = new Core();
        TeachersController teashObj = new TeachersController();
        UsersController userObj = new UsersController();
        public AdminTeachersPage()
        {
            InitializeComponent();
            UsersDataGrid.ItemsSource = teashObj.GetTeachers().ToList();

        }


        /// <summary>
        /// Нажатие на кнопку изменения  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeashersButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Models.Teachers currentTeasher = button.DataContext as Models.Teachers;
            this.NavigationService.Navigate(new AdminTeasherPage(currentTeasher));
        }

        private void AddTeasherButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminAddTeasherPage());
        }

        private void TeashersDeliteButton_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            Teachers item = button.DataContext as Teachers;
            
          MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (teashObj.DropTeachers(item))
                {
                    MessageBox.Show("Данные удалены");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
                //обновление DataGrid
                UsersDataGrid.ItemsSource = db.context.Teachers.ToList();

            }
        }
    }
}

