using RecruitmenSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RecruitmenSystem.Views.Authentication.Specialization
{
    /// <summary>
    /// Логика взаимодействия для СalendarPage.xaml
    /// </summary>
    public partial class СalendarPage : Page
    {
        public СalendarPage()
        {
            InitializeComponent();
            ApprovedInfoList();
        }
        private void ApprovedInfoList()
        {
            ObservableCollection<RecruitmenSystem.Models.Calendar> calendars = Database.GetCalendarInfo(App.SessionData.EmployeesId);
            CalendarView.ItemsSource = calendars;
        }

        private void AddNewEntry_Click(object sender, RoutedEventArgs e)
        {
            // Логика для добавления новой записи через модальное окно
            AddNewEntryWindow newEntryWindow = new AddNewEntryWindow();
            if (newEntryWindow.ShowDialog() == true)
            {
                // Обновление данных после добавления новой записи
                Database.AddNewApprove(newEntryWindow.approves, App.SessionData.EmployeesId);
                ApprovedInfoList();
                Database.UpdateStatisticApprovedCount(Database.GetApprovedCount(App.SessionData.EmployeesId) + 1, App.SessionData.EmployeesId);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Statistics());
        }

        private void AddNewInterv_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
