using System.Configuration;
using System.Data;
using System.Windows;

namespace MysqlTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DataTools dt = new DataTools();
            dt.Show();
        }
    }

}
