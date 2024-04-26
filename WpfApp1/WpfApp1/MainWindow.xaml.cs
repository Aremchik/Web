using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Resume> Resumes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Resumes = new ObservableCollection<Resume>();
            approveTable.ItemsSource = Resumes;
        }

        private void AddResumeButton_Click(object sender, RoutedEventArgs e)
        {
            AddResumeWindow addResumeWindow = new AddResumeWindow();
            if (addResumeWindow.ShowDialog() == true)
            {
                Resumes.Add(addResumeWindow.NewResume);
            }
        }
    }

    public class Resume
    {
        public DateTime Date { get; set; }
        public string RecruiterName { get; set; }
        public string ResumeLink { get; set; }
        public string HRApproval { get; set; }
        public string ITApproval { get; set; }
        public string Comment { get; set; }
    }
}

