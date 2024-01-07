using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Logic.Enums;
using LibraryManagementSystem.MVVM.Views.ManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tools
{
    public class CommandsCreator : ICommandsCreating
    {
        private readonly Func<Task> createAndShowConnectToServerView;
        private readonly Func<Task> openDatabase;
        private readonly Func<Task> joinFromServerFunc;

        public Func<Task> CreateAndShowConnectToServerView =>
            createAndShowConnectToServerView;

        public Func<Task> OpenDatabase =>
            openDatabase;

        public Func<Task> JoinFromServerFunc =>
            joinFromServerFunc;

        public CommandsCreator()
        {
            this.createAndShowConnectToServerView = async () =>
            {
                var connectToServerView =
                    new ConnectToServerView(DatabaseOperations.Create);

                connectToServerView.Show();
            };

            this.openDatabase = async () =>
            {
                var openDatabase =
                    new ConnectToServerView(DatabaseOperations.Open);

                openDatabase.Show();
            };

            this.joinFromServerFunc = async () =>
            {
                var joinfFromServer =
                    new ConnectToServerView(DatabaseOperations.JoinFromServer);

                joinfFromServer.Show();
            };
        }
    }
}
