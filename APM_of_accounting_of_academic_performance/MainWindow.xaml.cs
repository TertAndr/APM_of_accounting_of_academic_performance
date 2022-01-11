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
using APM_of_accounting_of_academic_performance;
using APM_of_accounting_of_academic_performance.Pages;

namespace APM_of_accounting_of_academic_performance
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainPageFrame.Navigate(new AutorizationPage());
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainPageFrame.CanGoBack)
            {
                MainPageFrame.GoBack();
            }
        }

        private void MainPageFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (MainPageFrame.CanGoBack)
            {
                BackButton.Visibility = Visibility.Visible;
            }
            else
            {
                BackButton.Visibility = Visibility.Collapsed;
            }
        }
       
    }
}
