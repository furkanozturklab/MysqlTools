using MysqlTools.Context;
using MysqlTools.View.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MysqlTools.ViewModels
{
    public class DataVm : DataPropsVm
    {

        #region Props

        private ObservableCollection<string>? _databaseTables;

        public ObservableCollection<string>? DatabaseTables
        {
            get => _databaseTables;
            set
            {
                if (_databaseTables != value)
                {
                    _databaseTables = value;
                    OnPropertyChanged();
                }
            }
        }


        private MySqlContext? _mysqlContext;

        public MySqlContext? MysqlContext
        {
            get => _mysqlContext;
            set
            {
                if (_mysqlContext != value)
                {
                    _mysqlContext = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isOpen = false;

        #endregion



        public DataVm(ContentControl ct)
        {
            ContentController = ct;
            MysqlServer = App.config.AppSettings.Settings["mysql_server"].Value;
            MysqlDatabase = App.config.AppSettings.Settings["mysql_database"].Value;
            MysqlUser = App.config.AppSettings.Settings["mysql_user"].Value;
            MysqlPsw = App.config.AppSettings.Settings["mysql_psw"].Value;

        }


        #region LoadControl


        protected override void MysqlConnectControllerOpen_Click(object? sender)
        {
            ContentController!.Content = new ConnectControl(this);
        }

        protected override void MysqlTableControllerOpen_Click(object? sender)
        {
            if (_isOpen)
            {
                ContentController!.Content = new TablesControl(this);
            }
            else
            {

                MessageBox.Show("Lütfen Önce Bağlantı Kurun !");
            }

        }


        protected override void MysqlQueryControllerOpen_Click(object? sender)
        {
            if (_isOpen)
            {
                ContentController!.Content = new QueryControl(this);
            }
            else
            {

                MessageBox.Show("Lütfen Önce Bağlantı Kurun !");
            }

        }


        #endregion


        #region Override




        protected override void MysqlConnect_Click(object? sender)
        {
            if (MysqlServer != null && MysqlServer.Length > 0)
            {
                if (MysqlDatabase != null && MysqlDatabase.Length > 0)
                {
                    if (MysqlUser != null && MysqlUser.Length > 0)
                    {
                        if (MysqlPsw != null && MysqlPsw.Length > 0)
                        {
                            try
                            {
                                MysqlContext = new MySqlContext(MysqlServer, MysqlDatabase, MysqlUser, MysqlPsw);
                                MysqlContext.Connect();

                                App.config.AppSettings.Settings["mysql_server"].Value = MysqlServer;
                                App.config.AppSettings.Settings["mysql_database"].Value = MysqlDatabase;
                                App.config.AppSettings.Settings["mysql_user"].Value = MysqlUser;
                                App.config.AppSettings.Settings["mysql_psw"].Value = MysqlPsw;
                                App.config.Save(ConfigurationSaveMode.Modified);

                                _isOpen = true;
                                ContentController!.Content = null;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Bağlantı Başarısız");
                            }
                        }
                    }
                }
            }
        }


        #endregion


        #region Context Process


        public void ReadTable()
        {


            if (DatabaseTables == null) DatabaseTables = new ObservableCollection<string>();

            if (MysqlContext != null && MysqlDatabase != null)
            {
                var result = MysqlContext.GetAllTableNames(MysqlDatabase);
                foreach (var item in result)
                {
                    DatabaseTables.Add(item);
                }
            }
        }

        protected override void MysqlViewTable_Changed()
        {
            if (MysqlContext != null && SelectedTable != null)
            {
                DataTable = MysqlContext.GetTableData(SelectedTable);
            }
        }

        protected override void MysqlQueryExecute_Click(object? sender)
        {

            if (MysqlContext != null && MysqlQuery != null)
            {
                var result = MysqlContext.ExecuteNonQuery(MysqlQuery);

                if (result == 1)
                {
                    MysqlQueryResult = "İşlem Başarılı !";
                    MysqlQuery = string.Empty;
                }
                else MysqlQueryResult = "İşlem Başarısız !";
            }
        }
        #endregion





    }
}
