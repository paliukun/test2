﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using IfcGDB.DatabaseAccess;

namespace IfcGDB.UI
{
    class LoginViewModel : ObservableObject
    {
        public LoginViewModel()
        {
            _logInModel = new LoginModel();

            Server = "127.0.0.1";
            Port = 5432;
            UserId = "postgres";
            DataBase = "TestDB";
        }

        private readonly LoginModel _logInModel;

        private string _server;
        private int _port;
        private string _dataBase;
        private string _userId;

        public string Server { get => _server; set => Set(ref _server, value); }
        public int Port { get => _port; set => Set(ref _port, value); }
        public string DataBase { get => _dataBase; set => Set(ref _dataBase, value); }
        public string UserId { get => _userId; set => Set(ref _userId, value); }

        public event EventHandler<IPostgreServer> GoForwardEvent = (object sender, IPostgreServer postgreServer) => { };

        public void LogIn(string password)
        {
            if (_server == string.Empty
                || _dataBase == string.Empty
                || _userId == string.Empty
                || password == string.Empty
                || _port <= 0)
            {
                throw new ConnectionException();
            }

            var connectionSettings = new ConnectionSettings()
            {
                Host = Server,
                Port = Port,
                UserId = UserId,
                Database = DataBase
            };

            _logInModel.CreateServer(connectionSettings, password);

            GoForwardEvent(this, _logInModel.PostgreServer);
        }
    }
}
