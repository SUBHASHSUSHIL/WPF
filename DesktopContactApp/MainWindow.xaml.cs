using DesktopContactApp.Classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            ReadDatabase();
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }

        void ReadDatabase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                contacts = conn.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();
            }

            if (contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchText = sender as TextBox;

            var filteredContacts = contacts.Where(c => c.Name.ToLower().Contains(searchText.Text.ToLower()) ||
                                                       c.Email.ToLower().Contains(searchText.Text.ToLower()) ||
                                                       c.Phone.ToLower().Contains(searchText.Text.ToLower())).ToList();

            var filterContacts2 = contacts.Where(c => c.Name.Contains(searchText.Text) ||
                                                       c.Email.Contains(searchText.Text) ||
                                                       c.Phone.Contains(searchText.Text)).ToList();

            contactsListView.ItemsSource = filteredContacts;
        }
    }
}