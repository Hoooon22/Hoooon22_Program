﻿using System;
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

namespace Hoooon22_Program
{
    /// <summary>
    /// Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        // GotFocus ID, PW
        private void IDTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            IDTextBox.Text = "";
        }
        private void PwTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PwTextBox.Text = "";
        }

        // LostFocus ID, PW
        private void IDTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }
        private void PwTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
