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
using APMClassLibrary;

namespace APM_of_accounting_of_academic_performance.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminChangeTeasherPage.xaml
    /// </summary>
    public partial class AdminChangeTeasherPage : Page
    {
        Teachers teacheer;
        FileManagerClass fileObj = new FileManagerClass();
        TeachersController teashObj = new TeachersController();
        UsersController userObj = new UsersController();
        RolesController roleObj = new RolesController();
        StringCheckClass strObj = new StringCheckClass();
        byte[] teasherImage;
        public AdminChangeTeasherPage(Teachers currentsTeasher)
        {
            InitializeComponent();

            teacheer = currentsTeasher;

            RoleRegistrComboBox.ItemsSource = roleObj.GetRoles();
            RoleRegistrComboBox.DisplayMemberPath = "rloe_name";
            RoleRegistrComboBox.SelectedValuePath = "id_role";
            RoleRegistrComboBox.SelectedValue = currentsTeasher.Users.id_role;

            TeasherFamilyTextBox.Text = currentsTeasher.teacher_fname;
            TeasherNameTextBox.Text = currentsTeasher.teacher_name;
            TeasherPatronomicTextBox.Text = currentsTeasher.teacher_patronomic;

            teasherImage = currentsTeasher.teacher_photo;
            PhotoImage.Source = FileManagerClass.GetBytePhotoToImage(teasherImage);

            TeasherLoginTextBox.Text = currentsTeasher.Users.user_login;
            TeasherPasswordTextBox.Text = currentsTeasher.Users.user_password;

        }
        private string SetErrors()
        {
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(TeasherFamilyTextBox.Text)
                || !strObj.NameCheck(TeasherFamilyTextBox.Text))
            {
                errorString += "Проверьте правильность написания Имени\n";
            }
            if (String.IsNullOrWhiteSpace(TeasherNameTextBox.Text)
                || !strObj.NameCheck(TeasherNameTextBox.Text))
            {
                errorString += "Проверьте правильность написания Фамилии\n";
            }
            if (String.IsNullOrWhiteSpace(TeasherPatronomicTextBox.Text)
                || !strObj.NameCheck(TeasherPatronomicTextBox.Text))
            {

                errorString += "Проверьте правильность написания Отчества\n";
            }
            if (String.IsNullOrWhiteSpace(TeasherLoginTextBox.Text)
               || !strObj.LoginCheck(TeasherLoginTextBox.Text))
            {
                errorString += "Проверьте правильность написания Логина\n";
            }
            if (String.IsNullOrWhiteSpace(TeasherPasswordTextBox.Text)
               || !strObj.PasswordCheck(TeasherPasswordTextBox.Text))
            {
                errorString += "Проверьте правильность написания Пароля\n";
            }
            return errorString;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                try
            {
                if (
                    teashObj.UpdateTeasher(
                    TeasherFamilyTextBox.Text,
                    TeasherFamilyTextBox.Text,
                    TeasherPatronomicTextBox.Text,
                    teasherImage, teacheer)
                    &&                    
                    userObj.UpdateUser(
                    TeasherLoginTextBox.Text,
                    TeasherPasswordTextBox.Text,                   
                    Convert.ToInt32(RoleRegistrComboBox.SelectedValue),
                    teacheer))
                    
                    
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

        private void SearchPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            PhotoPathTextBox.Text = fileObj.GetPhotoPath();
            teasherImage = fileObj.GetBytePhoto(PhotoPathTextBox.Text);
            if (!String.IsNullOrWhiteSpace(PhotoPathTextBox.Text))
            {
                PhotoImage.Source = FileManagerClass.GetPhotoImage(PhotoPathTextBox.Text);
            }
        }
    }
}