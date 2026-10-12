using CRUD.Models;
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

namespace CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users = new List<User>();
        public MainWindow()
        {
            InitializeComponent();

            this.users = new List<User>
            {
                new User
                {
                    Username = "JohnDoe",
                    Email = "john.doe@example.com",
                    Phone = "123-456-7890"
                }
            };

            this.DataContext = this.users;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User
            {
                Username = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };
            users.Add(newUser);
            MessageBox.Show("Create button clicked!");
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Update button clicked!");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete button clicked!");
        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contactsListView.ItemsSource = users;
        }
    }
}