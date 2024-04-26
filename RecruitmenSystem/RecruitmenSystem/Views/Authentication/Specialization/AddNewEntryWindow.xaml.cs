using RecruitmenSystem.Models;
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

namespace RecruitmenSystem.Views.Authentication.Specialization
{
    /// <summary>
    /// Логика взаимодействия для AddNewEntryWindow.xaml
    /// </summary>
    public partial class AddNewEntryWindow : Window
    {
        public Approves approves { get; private set; }

        public AddNewEntryWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            approves = new Approves
            {
                DateAdded = DateTime.Now.ToString(), 
                Summary = summaryTextBox.Text, 
                Contacts = contactsTextBox.Text,
                Comment = commentTextBox.Text, // Пример получения значения из текстового поля для свойства Comment
                ApprovedByIT = 0 // Пример получения значения из флажка для свойства ApprovedByIT
            };

            DialogResult = true; // Закрытие окна с результатом DialogResult = true
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Закрытие окна с результатом DialogResult = false
        }
    }
}
