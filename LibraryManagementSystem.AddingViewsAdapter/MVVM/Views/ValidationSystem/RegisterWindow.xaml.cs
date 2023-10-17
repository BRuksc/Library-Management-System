﻿using LibraryManagementSystem.MVVM.ViewModels;
using LibraryManagementSystem.MVVM.ViewModels.ValidationSystem;
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

namespace LibraryManagementSystem.MVVM.Views.ValidationSystem
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = new RegisterWindowViewModel(this);

            MessageBox.Show("You have not to get data with '*' symbol");
        }
    }
}
