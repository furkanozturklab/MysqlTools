using MysqlTools.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using static MysqlTools.Context.MySqlContext;

namespace MysqlTools
{
    public class DataPropsVm : INotifyPropertyChanged
    {


        #region Props



        private ContentControl? _content;

        private string? _mysqlServer;
        private string? _mysqlDatabase;
        private string? _mysqlUser;
        private string? _mysqlPsw;
        private string? _mysqlQuery;
        private string? _mysqlQueryResult;


        private DataTable? _dataTable;

        private string? _selectedTable;

        #endregion


        #region Props Getter and Setter


        public DataTable? DataTable
        {
            get { return _dataTable; }
            set
            {
                _dataTable = value;
                OnPropertyChanged();
            }
        }

        public string? SelectedTable
        {
            get => _selectedTable;
            set
            {
                if (_selectedTable != value)
                {
                    _selectedTable = value;
                    MysqlViewTable_Changed();
                    OnPropertyChanged();
                }
            }
        }

        public ContentControl? ContentController
        {
            get => _content;
            set
            {
                if (_content != value)
                {
                    _content = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? MysqlServer
        {
            get => _mysqlServer;
            set
            {
                if (_mysqlServer != value)
                {
                    _mysqlServer = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? MysqlDatabase
        {
            get => _mysqlDatabase;
            set
            {
                if (_mysqlDatabase != value)
                {
                    _mysqlDatabase = value;
                    OnPropertyChanged();
                }
            }
        }


        public string? MysqlUser
        {
            get => _mysqlUser;
            set
            {
                if (_mysqlUser != value)
                {
                    _mysqlUser = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? MysqlPsw
        {
            get => _mysqlPsw;
            set
            {
                if (_mysqlPsw != value)
                {
                    _mysqlPsw = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? MysqlQuery
        {
            get => _mysqlQuery;
            set
            {
                if (_mysqlQuery != value)
                {
                    _mysqlQuery = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? MysqlQueryResult
        {
            get => _mysqlQueryResult;
            set
            {
                if (_mysqlQueryResult != value)
                {
                    _mysqlQueryResult = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion


        #region Commands

        private ICommand? _mysqlConnectOpen;
        private ICommand? _mysqlConnect;
        private ICommand? _mysqlTableControllerOpen;
        private ICommand? _mysqlQueryControllerOpen;
        private ICommand? _mysqlQueryExecute;


        #endregion

        #region Commands Getter


        public ICommand? MysqlQueryControllerOpen
        {
            get
            {
                if (_mysqlQueryControllerOpen == null)
                {
                    _mysqlQueryControllerOpen = new RelayCommand(MysqlQueryControllerOpen_Click);
                }
                return _mysqlQueryControllerOpen;
            }
        }


        public ICommand? MysqlQueryExecute
        {
            get
            {
                if (_mysqlQueryExecute == null)
                {
                    _mysqlQueryExecute = new RelayCommand(MysqlQueryExecute_Click);
                }
                return _mysqlQueryExecute;
            }
        }
        public ICommand? MysqlConnectOpen
        {
            get
            {
                if (_mysqlConnectOpen == null)
                {
                    _mysqlConnectOpen = new RelayCommand(MysqlConnectControllerOpen_Click);
                }
                return _mysqlConnectOpen;
            }
        }

        public ICommand? MysqlConnect
        {
            get
            {
                if (_mysqlConnect == null)
                {
                    _mysqlConnect = new RelayCommand(MysqlConnect_Click);
                }
                return _mysqlConnect;
            }
        }

        public ICommand? MysqlTableControllerOpen
        {
            get
            {
                if (_mysqlTableControllerOpen == null)
                {
                    _mysqlTableControllerOpen = new RelayCommand(MysqlTableControllerOpen_Click);
                }
                return _mysqlTableControllerOpen;
            }
        }

        #endregion



        protected virtual void MysqlConnectControllerOpen_Click(object? sender) { }
        protected virtual void MysqlConnect_Click(object? sender) { }
        protected virtual void MysqlTableControllerOpen_Click(object? sender) { }
        protected virtual void MysqlQueryControllerOpen_Click(object? sender) { }
        protected virtual void MysqlQueryExecute_Click(object? sender) { }
        protected virtual void MysqlViewTable_Changed() { }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
