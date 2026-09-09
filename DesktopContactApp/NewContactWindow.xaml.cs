using DesktopContactApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                Phone = PhoneTextBox.Text
            };

            string databaseName = "contacts.db";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string databasePath = System.IO.Path.Combine(folderPath, databaseName);

            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }

            Close();
        }
    }
}
