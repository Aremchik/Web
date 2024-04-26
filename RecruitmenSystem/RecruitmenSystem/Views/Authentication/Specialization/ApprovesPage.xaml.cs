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
    /// Логика взаимодействия для ApprovesPage.xaml
    /// </summary>
    public partial class ApprovesPage : Page
    {
        public ApprovesPage()
        {
            InitializeComponent();
            ApprovedInfoList();
        }
        private void ApprovedInfoList()
        {
            ObservableCollection<Approves> approves = Database.GetApprovesInfo(App.SessionData.EmployeesId, App.SessionData.UserName);
            ApprovesListView.ItemsSource = approves;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new СalendarPage());
        }
    }
}
