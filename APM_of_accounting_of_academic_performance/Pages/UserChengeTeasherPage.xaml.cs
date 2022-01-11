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
    /// Логика взаимодействия для UserChengeTeasherPage.xaml
    /// </summary>
    public partial class UserChengeTeasherPage : Page
    {
        Teachers teacheer;
        ProfileClass prObj = new ProfileClass();
        TeachersController teashObj = new TeachersController();
        FileManagerClass fileObj = new FileManagerClass();
        UsersController userObj = new UsersController();
        RolesController roleObj = new RolesController();
        StringCheckClass strObj = new StringCheckClass();
        byte[] teasherImage;
        public UserChengeTeasherPage(Teachers currentTeachers)
        {
            InitializeComponent();
            currentTeachers = teashObj.GetTeachersIdProfile(ProfileClass.Id_Profile);
            Family_Textbox.Text = currentTeachers.teacher_name;
            Namey_Textbox.Text = currentTeachers.teacher_fname;
            Patronomic_Textbox.Text = currentTeachers.teacher_patronomic;
            Login_Textbox.Text = currentTeachers.Users.user_login;
            Password_Textbox.Text = currentTeachers.Users.user_password;
            PhotoImage.Source = FileManagerClass.GetBytePhotoToImage(currentTeachers.teacher_photo);
            teacheer = currentTeachers;
        }
        private string SetErrors()
        {         
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(Family_Textbox.Text)
                || !strObj.NameCheck(Family_Textbox.Text))
            {
                errorString += "Проверьте правильность написания Имени\n";
            }
            if (String.IsNullOrWhiteSpace(Namey_Textbox.Text)
                || !strObj.NameCheck(Namey_Textbox.Text))
            {
                errorString += "Проверьте правильность написания Фамилии\n";
            }
            if (String.IsNullOrWhiteSpace(Patronomic_Textbox.Text)
                || !strObj.NameCheck(Patronomic_Textbox.Text))
            {

                errorString += "Проверьте правильность написания Отчества\n";
            }
            if (String.IsNullOrWhiteSpace(Login_Textbox.Text)
               || !strObj.LoginCheck(Login_Textbox.Text))
            {
                errorString += "Проверьте правильность написания Логина\n";
            }
            if (String.IsNullOrWhiteSpace(Password_Textbox.Text)
               || !strObj.PasswordCheck(Password_Textbox.Text))
            {
                errorString += "Проверьте правильность написания Пароля\n";
            }
            return errorString;
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

        private void ChangeUserButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                try
                {
                    if (
                        teashObj.UpdateTeasher(
                        Family_Textbox.Text,
                        Namey_Textbox.Text,
                        Patronomic_Textbox.Text,
                        teasherImage, teacheer)
                        &&
                        userObj.UpdateAutorizUser(
                        Login_Textbox.Text,
                        Password_Textbox.Text,
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
    }
}
