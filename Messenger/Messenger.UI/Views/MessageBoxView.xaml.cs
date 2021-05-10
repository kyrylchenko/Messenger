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

namespace Messenger.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для MessageBoxView.xaml
    /// </summary>
    public partial class MessageBoxView : Window
    {
        public MessageBoxView(string message)
        {
            InitializeComponent();
            MessageTextBox.Text = message;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
