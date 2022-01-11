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
using APM_of_accounting_of_academic_performance.Models;
using APM_of_accounting_of_academic_performance.Controllers;
using APMClassLibrary;

namespace APM_of_accounting_of_academic_performance.Pages
{
    /// <summary>
    /// Логика взаимодействия для UsersTeasherPage.xaml
    /// </summary>
    public partial class UsersTeasherPage : Page
    {
        AttachmentController attObj = new AttachmentController();
        ProfileClass prObj = new ProfileClass();
        TeachersController teashObj = new TeachersController();
        Teachers currentTeachers = new Teachers();
        public UsersTeasherPage()
        {
            InitializeComponent();
            currentTeachers = teashObj.GetTeachersIdProfile(ProfileClass.Id_Profile);
            TeasherSubjectGrid.ItemsSource = attObj.GetAttachmentUser(ProfileClass.Id_Profile).ToList();
            Family_Textbox.Text = currentTeachers.teacher_name;
            Namey_Textbox.Text = currentTeachers.teacher_fname;
            Patronomic_Textbox.Text = currentTeachers.teacher_patronomic;
            PhotoImage.Source = FileManagerClass.GetBytePhotoToImage(currentTeachers.teacher_photo);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserChengeTeasherPage(currentTeachers));
        }
    }
}
