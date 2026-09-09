using System.Configuration;
using System.Data;
using System.Windows;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "contacts.db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }

}
