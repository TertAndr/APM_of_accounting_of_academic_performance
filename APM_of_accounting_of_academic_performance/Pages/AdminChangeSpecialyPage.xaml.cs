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
    /// Логика взаимодействия для AdminSpecialyChangePage.xaml
    /// </summary>
    public partial class AdminChangeSpecialyPage : Page
    {
        Specialtys specc;
        SpecialtysController specObj = new SpecialtysController();
        StringCheckClass strObj = new StringCheckClass();
        public AdminChangeSpecialyPage( Specialtys currentSpecialtys)
        {
            InitializeComponent();
            ChangeSpecialyTextBox.Text = currentSpecialtys.specialty_name;
            ChangeSpecialyCodeTextBox.Text = currentSpecialtys.specialty_code;
            specc = currentSpecialtys;

        }

        private string SetErrors()
        {
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(ChangeSpecialyTextBox.Text)
                || ChangeSpecialyTextBox.Text.Length > 75 || ChangeSpecialyTextBox.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания называния специальности\n";
            }
            if (String.IsNullOrWhiteSpace(ChangeSpecialyCodeTextBox.Text)
               || ChangeSpecialyCodeTextBox.Text.Length > 10 || ChangeSpecialyCodeTextBox.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания называния кода специальности\n";
            }
            return errorString;
        }

        private void SpecialyChangeButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                try
            {
                specObj.UpdateSpecialtys(
                ChangeSpecialyTextBox.Text,
                ChangeSpecialyCodeTextBox.Text,
                specc);
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
