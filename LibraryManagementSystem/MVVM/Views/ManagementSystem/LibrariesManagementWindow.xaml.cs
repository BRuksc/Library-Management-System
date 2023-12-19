using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Autofac;
using LibraryManagementSystem.WindowsPointing;
using LibraryManagementSystem.WindowsPointing.Interfaces;

namespace LibraryManagementSystem.MVVM.Views.ManagementSystem
{
    /// <summary>
    /// Interaction logic for LibrariesManagementWindow.xaml
    /// </summary>
    public partial class LibrariesManagementWindow : Window
    {
        public LibrariesManagementWindow()
        {
            Bootstrapper.Run();

            var container = Bootstrapper.Container;
            using (var scope = container.BeginLifetimeScope())
            {
                Func<Task> show = async () => 
                {
                    this.Show();
                };

                Func<Task> close = async () =>
                {
                    this.Close();
                };         

                scope.Resolve<WindowPointersCollection>()
                    .Add(scope.Resolve<IWindowGuidContainer>().LibraryManagementWindow,
                    show, close);
            }

            InitializeComponent();
        }
    }
}
