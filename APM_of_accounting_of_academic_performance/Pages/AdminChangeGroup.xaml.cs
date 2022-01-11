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
    /// Логика взаимодействия для AdminChengeGroup.xaml
    /// </summary>
    public partial class AdminChengeGroup : Page
    {
        Groups groupp;
        GroupsController grObj = new GroupsController();
        StringCheckClass strObj = new StringCheckClass();
        public AdminChengeGroup( Groups currentGroup)
        {
            InitializeComponent();

            ChangeGroupsTextBox.Text = currentGroup.groups_name;
            groupp = currentGroup;

        }
        private string SetErrors()
        {
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(ChangeGroupsTextBox.Text)
                || ChangeGroupsTextBox.Text.Length>10 || ChangeGroupsTextBox.Text.Length < 3)
            {
                errorString += "Проверьте правильность написания называния группы\n";
            }
            return errorString;
        }
        private void GroupChangeButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                try
            {
                grObj.UpdateGroups(
                ChangeGroupsTextBox.Text, groupp);
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
