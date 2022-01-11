using APM_of_accounting_of_academic_performance.Controllers;
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
    /// Логика взаимодействия для AdminAddLoud.xaml
    /// </summary>
    public partial class AdminAddLoud : Page
    {
        Core db = new Core();
        Curriculum_in_the_specialtysController currObj = new Curriculum_in_the_specialtysController();
        TeachersController teashObj = new TeachersController();
        GroupsController groupObj = new GroupsController();
        Type_of_clocksController clockObj = new Type_of_clocksController();
        LoadsController loudObj = new LoadsController();
        StringCheckClass strObj = new StringCheckClass();
        public AdminAddLoud()
        {
            InitializeComponent();

            DateLoudDatePicker.SelectedDate = DateTime.Today;

            FIOCombobox.ItemsSource = teashObj.GetTeachers();
            FIOCombobox.DisplayMemberPath = "TeacherFIO";
            FIOCombobox.SelectedValuePath = "id_teacher";
            FIOCombobox.SelectedIndex = 0;

            SpecialityCombobox.ItemsSource = currObj.GetCurriculum_in_the_specialtys();
            SpecialityCombobox.DisplayMemberPath = "specialtystInfo";
            SpecialityCombobox.SelectedValuePath = "id_curriculum_in_the_specialty";
            SpecialityCombobox.SelectedIndex = 0;

            GroupsCombobox.ItemsSource = groupObj.GetGroups();
            GroupsCombobox.DisplayMemberPath = "groups_name";
            GroupsCombobox.SelectedValuePath = "id_group";
            GroupsCombobox.SelectedIndex = 0;


            ClocksTypeCombobox.ItemsSource = clockObj.GetType_of_clocks();
            ClocksTypeCombobox.DisplayMemberPath = "type_of_clock_name";
            ClocksTypeCombobox.SelectedValuePath = "id_type_of_clock";
            ClocksTypeCombobox.SelectedIndex = 0;

        }
        private string SetErrors()
        {
            string errorString = String.Empty;

            if (String.IsNullOrWhiteSpace(HoursTextBox.Text)
                || HoursTextBox.Text.Length > 3)
            {
                errorString += "Проверьте правильность написания колличества часов\n";
            }
            return errorString;
        }
        private void LoudsAddCombobox_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetErrors();
            if (errors == String.Empty)
            {
                if (AddNewLouds())
                 {
                MessageBox.Show("Добавление прошло успешно!");
                this.NavigationService.Navigate(new AdminLoudPage());
                }
            }
            else
            {
                MessageBox.Show(errors);
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

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AddNewLouds()
            {
                try
                {
                    bool resultLouds = loudObj.AddNewLouds(
                         Convert.ToInt32(FIOCombobox.SelectedValue),
                          Convert.ToInt32(GroupsCombobox.SelectedValue),
                          Convert.ToInt32(SpecialityCombobox.SelectedValue),                          
                          Convert.ToDateTime(DateLoudDatePicker.SelectedDate),
                          Convert.ToInt32(HoursTextBox.Text),
                        Convert.ToInt32(ClocksTypeCombobox.SelectedValue));
                    return true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }


        }

        private void HoursTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void GroupsCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int resultGroupType;
            string groupName = "";
            int com;
            com = Convert.ToInt32(GroupsCombobox.SelectedValue);
            groupName = db.context.Groups.Where(x=> x.id_group == com ).FirstOrDefault().groups_name;
            resultGroupType = TypeHoursClass.TypeHours(groupName);
            ClocksTypeCombobox.SelectedIndex = resultGroupType;
            Console.WriteLine(resultGroupType);
        }
    }
}
