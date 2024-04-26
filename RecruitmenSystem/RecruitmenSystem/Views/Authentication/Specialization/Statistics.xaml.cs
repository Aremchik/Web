using RecruitmenSystem.Models;
using RecruitmenSystem.Views.Specialization;
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
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        public Statistics()
        {
            InitializeComponent();
            RecruitersInfoList();
        }
        private void RecruitersInfoList()
        {
            ObservableCollection<Recruiter> recruiter = Database.GetRecruiterInfo();
            RecruiterListView.ItemsSource = recruiter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApprovesPage());
        }
    }
}
