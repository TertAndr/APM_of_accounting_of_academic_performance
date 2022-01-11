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
using APM_of_accounting_of_academic_performance.Controllers;
using APM_of_accounting_of_academic_performance.Pages;

namespace APM_of_accounting_of_academic_performance.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        UsersController objUser = new UsersController();
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginLoginBox!= null && LoginPassBox != null) 
            {

                switch (objUser.UserAuth(LoginLoginBox.Text, LoginPassBox.Password))
                {
                    case 0:
                        MessageBox.Show("Авторизационные данные введены не верно!");
                        break;
                    case 1:
                        this.NavigationService.Navigate(new AdminMainPage());
                        break;
                    case 2:
                        this.NavigationService.Navigate(new UsersLoudPage());
                        break;
                }

            }
            else
            {
                MessageBox.Show("В поля не внесены данные");
            }   
        }
    }
}
