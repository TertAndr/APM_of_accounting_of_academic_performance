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
    /// Логика взаимодействия для AbminTeashersLoudPage.xaml
    /// </summary>
    public partial class AbminTeashersLoudPage : Page
    {
        FileManagerClass fileObj = new FileManagerClass();
        LoadsController loadObj = new LoadsController();
        List<Models.Loads> currentLoads;

        /// <summary>
        /// Инициализация данных на странице AbminTeashersLoudPage
        /// </summary>
        public AbminTeashersLoudPage(Teachers currentsTeasher)
        {
            InitializeComponent();
            ProfileClass.Id_Teasher = currentsTeasher.id_teacher;

            LoudsAdminDataGrid.ItemsSource = loadObj.GetLoadsAdmin(ProfileClass.Id_Teasher).ToList();
            currentLoads = loadObj.GetLoadsAdmin(ProfileClass.Id_Teasher).ToList();
        }

        private void LoudsDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = Convert.ToDateTime(LoudsDatePicker.SelectedDate);
            LoudsAdminDataGrid.ItemsSource = loadObj.GetLoadsDateAdmin(selectedDate , ProfileClass.Id_Teasher).ToList();
        }

        private void AdminSaveCSVButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, List<string>> currentLoadableData = new Dictionary<string, List<string>>();
                currentLoadableData.Add("Фамилия", new List<string>());
                currentLoadableData.Add("Имя", new List<string>());
                currentLoadableData.Add("Отчество", new List<string>());
                currentLoadableData.Add("Группа", new List<string>());
                currentLoadableData.Add("Код плана", new List<string>());
                currentLoadableData.Add("Специальность", new List<string>());
                currentLoadableData.Add("Предмет", new List<string>());
                currentLoadableData.Add("Дата", new List<string>());
                currentLoadableData.Add("Часов", new List<string>());
                currentLoadableData.Add("Тип часов", new List<string>());
                foreach (var item in currentLoads)
                {
                    currentLoadableData["Фамилия"].Add(item.Teachers.teacher_fname);
                    currentLoadableData["Имя"].Add(item.Teachers.teacher_name);
                    currentLoadableData["Отчество"].Add(item.Teachers.teacher_patronomic);
                    currentLoadableData["Группа"].Add(item.Groups.groups_name);
                    currentLoadableData["Код плана"].Add(item.Curriculum_in_the_specialtys.code);
                    currentLoadableData["Специальность"].Add(item.Curriculum_in_the_specialtys.Specialtys.specialty_name);
                    currentLoadableData["Предмет"].Add(item.Curriculum_in_the_specialtys.Sudjects.sudject_name);
                    currentLoadableData["Дата"].Add(item.date.ToString());
                    currentLoadableData["Часов"].Add(item.loud_hours.ToString());
                    currentLoadableData["Тип часов"].Add(item.Type_of_clocks.type_of_clock_name);
                }

                if (fileObj.DownLoadToCsvFile(currentLoadableData))
                {
                    MessageBox.Show("Сохранение прошло успешно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AllTimesButton_Click(object sender, RoutedEventArgs e)
        {
            LoudsAdminDataGrid.ItemsSource = loadObj.GetLoadsAdmin(ProfileClass.Id_Teasher).ToList();
        }

        private void AdminAddLoudButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminAddLoud());
        }
    }
}
