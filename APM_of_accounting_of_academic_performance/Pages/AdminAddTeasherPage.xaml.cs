using APM_of_accounting_of_academic_performance.Controllers;
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
    /// Логика взаимодействия для AdminAddTeasherPage.xaml
    /// </summary>
    public partial class AdminAddTeasherPage : Page
    {
        FileManagerClass fileObj = new FileManagerClass();
        TeachersController teashOdj = new TeachersController();
        UsersController userObj = new UsersController();
        RolesController roleObj = new RolesController();
        StringCheckClass strObj = new StringCheckClass();

        byte[] teasherImage;
        public AdminAddTeasherPage()
        {
            InitializeComponent();

            RoleRegistrComboBox.ItemsSource = roleObj.GetRoles();
            RoleRegistrComboBox.DisplayMemberPath = "rloe_name";
            RoleRegistrComboBox.SelectedValuePath = "id_role";
            RoleRegistrComboBox.SelectedIndex = 0;
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
        private void SearchPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            PhotoPathTextBox.Text = fileObj.GetPhotoPath();
            teasherImage = fileObj.GetBytePhoto(PhotoPathTextBox.Text);
            if (!String.IsNullOrWhiteSpace(PhotoPathTextBox.Text))
            {
                PhotoImage.Source = FileManagerClass.GetPhotoImage(PhotoPathTextBox.Text);
            }
        }

        private void AddTeasherButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                if (AddNewTeasher())
            {
                MessageBox.Show("Добавление прошло успешно!");
                this.NavigationService.GoBack();
            }
            }
            else
            {
                MessageBox.Show(errors);
            }
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
       
        public bool AddNewTeasher()
        {          
                    try
                    {

                    bool resultTeash = teashOdj.AddNewTeasher(
                        TeasherFamilyTextBox.Text,
                        TeasherNameTextBox.Text,
                        TeasherPatronomicTextBox.Text,
                        teasherImage,
                        userObj.AddNewUser(
                        TeasherLoginTextBox.Text,
                        TeasherPasswordTextBox.Text,
                        Convert.ToInt32(RoleRegistrComboBox.SelectedValue))
                        );              
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