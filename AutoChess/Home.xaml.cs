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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoChess
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }
        private void ViewHeroes_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ViewHeroes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("This Works");
        }

        private void PlayGame_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void PlayGame_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
