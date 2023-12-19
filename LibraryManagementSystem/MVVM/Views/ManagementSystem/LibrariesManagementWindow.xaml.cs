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
            InitializeComponent();
        }
    }
}
