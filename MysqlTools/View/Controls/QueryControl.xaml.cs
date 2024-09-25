﻿using MysqlTools.ViewModels;
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
    /// Interaction logic for QueryControl.xaml
    /// </summary>
    public partial class QueryControl : UserControl
    {
        public QueryControl(DataVm vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
