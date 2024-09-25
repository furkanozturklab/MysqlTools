using MysqlTools.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MysqlTools.View.Controls
{
    /// <summary>
    /// Interaction logic for TablesControl.xaml
    /// </summary>
    public partial class TablesControl : UserControl
    {
        public TablesControl(DataVm vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ((DataVm)DataContext).ReadTable();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
