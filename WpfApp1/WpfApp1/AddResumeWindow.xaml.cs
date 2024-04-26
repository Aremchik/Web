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
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class AddResumeWindow : Window
    {
        public Resume NewResume { get; set; }

        public AddResumeWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(recruiterNameTextBox.Text) || string.IsNullOrWhiteSpace(resumeLinkTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            NewResume = new Resume()
            {
                Date = datePicker.SelectedDate ?? DateTime.Now,
                RecruiterName = recruiterNameTextBox.Text,
                ResumeLink = resumeLinkTextBox.Text,
                HRApproval = hrApprovalComboBox.SelectedItem?.ToString(),
                ITApproval = itApprovalComboBox.SelectedItem?.ToString(),
                Comment = commentTextBox.Text
            };

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
