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
    /// Логика взаимодействия для AdminTeasherPage.xaml
    /// </summary>
    public partial class AdminTeasherPage : Page
    {
        Core db = new Core();
        byte[] teasherImage;
        public Teachers currentsTeasher;
        AttachmentController attObj = new AttachmentController();
        SudjectsController subjOdj = new SudjectsController();
        LoadsController loudObj = new LoadsController();
        public AdminTeasherPage(Teachers currentTeasher )
        {
            InitializeComponent();
            TeasherSubjectGrid.ItemsSource = attObj.GetAttachmentUser(currentTeasher.id_teacher).ToList();

            SubjectComboBox.ItemsSource = subjOdj.GetSudjects();
            SubjectComboBox.DisplayMemberPath = "sudject_name";
            SubjectComboBox.SelectedValuePath = "id_sudject";
            SubjectComboBox.SelectedIndex = 0;


            AllHoursTextBlock.Text = loudObj.AllLoudsHours(Convert.ToInt32(currentTeasher.id_teacher)).ToString();
            BudjHoursTextBlock.Text = loudObj.BudjLoudsHours(Convert.ToInt32(currentTeasher.id_teacher)).ToString();
            DonHoursTextBlock.Text = loudObj.DonLoudsHours(Convert.ToInt32(currentTeasher.id_teacher)).ToString();
            TeasherFamilyTextBox.Text = currentTeasher.teacher_fname;
            TeasherNameTextBox.Text = currentTeasher.teacher_name;
            TeasherPatronomicTextBox.Text = currentTeasher.teacher_patronomic;

            teasherImage = currentTeasher.teacher_photo;
            PhotoImage.Source = FileManagerClass.GetBytePhotoToImage(teasherImage);

            TeasherLoginTextBox.Text = currentTeasher.Users.user_login;
            TeasherPasswordTextBox.Text = currentTeasher.Users.user_password;


            currentsTeasher = currentTeasher;

        }


        private void AdminUserChengeButton(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminChangeTeasherPage(currentsTeasher));
        }

        private string SetErrors()
        {
            string errorString = String.Empty;
            Console.WriteLine(SubjectComboBox.SelectedValue);
            if (!attObj.CheckSubjectDuplication(Convert.ToInt32(SubjectComboBox.SelectedValue), currentsTeasher.id_teacher))
            {
                errorString += "Данный предмет уже добавлен\n";               
            }
            return errorString;
        }

        private void AddSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            
            Button button = sender as Button;
            Models.Attachment currentAttachment = button.DataContext as Models.Attachment;
            if (AddNewSubject())
            {   
                MessageBox.Show("Добавление прошло успешно!");
            }
        }
            
        

    public bool AddNewSubject()
    {
        string errorString = SetErrors();
        if (String.IsNullOrEmpty(errorString))
        {
            try
            {
                bool resultTeash = attObj.AddNewSubject(
               currentsTeasher.id_teacher,
                Convert.ToInt32(SubjectComboBox.SelectedValue));
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        else
        {
            MessageBox.Show(errorString);
            return false;
        }
    }

        private void DeliteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Attachment item = button.DataContext as Attachment;

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (attObj.DropAttachment(item))
                {
                    MessageBox.Show("Данные удалены");
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
            //обновление DataGrid
            TeasherSubjectGrid.ItemsSource = attObj.GetAttachmentUser(currentsTeasher.id_teacher).ToList();

        }

        private void AdminMoreUserLoudButton(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AbminTeashersLoudPage(currentsTeasher));
        }
    }
}