using APM_of_accounting_of_academic_performance.Controllers;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using APM_of_accounting_of_academic_performance.Models;
using APMClassLibrary;

namespace APM_of_accounting_of_academic_performance.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminGroupPage.xaml
    /// </summary>
    public partial class AdminGroupPage : Page
    {
        Core db = new Core();
        GroupsController groupObj = new GroupsController();
        StringCheckClass strObj = new StringCheckClass();
        public AdminGroupPage()
        {
            InitializeComponent();
            GroupsDataGrid.ItemsSource = groupObj.GetGroups().ToList();
        }

        private string SetErrors()
        {
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(AddGroupsTextBlock.Text)
                || AddGroupsTextBlock.Text.Length > 10 || AddGroupsTextBlock.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания называния группы\n";
            }
            return errorString;
        }
        private void AddGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                if (AddNewGroups())
            {
                MessageBox.Show("Добавление прошло успешно!");
            }
            //обновление DataGrid       
            GroupsDataGrid.ItemsSource = db.context.Groups.ToList();
            }
            else
            {
                MessageBox.Show(errors);
            }
        }
        private void ChangeGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Groups currentGroups = button.DataContext as Groups;
            this.NavigationService.Navigate(new AdminChengeGroup(currentGroups));

        }

        private void DeliteGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Groups item = button.DataContext as Groups;


            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (groupObj.DropGroups(item))
                {
                    MessageBox.Show("Данные удалены");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }

            //обновление DataGrid
            GroupsDataGrid.ItemsSource = db.context.Groups.ToList();

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

        public bool AddNewGroups()
        {
            try
            {
                bool resultGroup = groupObj.AddNewGroups(
                    AddGroupsTextBlock.Text);
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
