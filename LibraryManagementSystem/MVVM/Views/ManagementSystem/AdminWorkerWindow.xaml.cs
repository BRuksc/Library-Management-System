﻿using LibraryManagementSystem.Tools;
using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;
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
using System.Windows.Shapes;

namespace LibraryManagementSystem.MVVM.Views.ManagementSystem
{
    /// <summary>
    /// Interaction logic for AdminWorkerWindow.xaml
    /// </summary>
    public partial class AdminWorkerWindow : Window
    {
        public AdminWorkerWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModelLocator.ViewModelManagementWindow;
        }
    }
}
