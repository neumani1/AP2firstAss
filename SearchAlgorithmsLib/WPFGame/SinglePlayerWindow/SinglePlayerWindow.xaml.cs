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

namespace WPFGame
{
    /// <summary>
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window
    {
        private SinglePlayerWindowViewModel vm;
        private ISinglePlayerWindowModel model;

        public SinglePlayerWindow()
        {
            {
                this.model = new ApplicationSinglePlayerWindow();
                //InitializeComponent();
                this.vm = new SinglePlayerWindowViewModel(this.model);
                this.DataContext = this.vm;
            }
        }

        private void Restart_Game_Button_Click(object sender, RoutedEventArgs e)
        {
            this.vm.SaveSettings();
            SinglePlayerWindow win = new SinglePlayerWindow();
            win.Show();
            this.Close();
        }

        private void Solve_Game_Button_Click(object sender, RoutedEventArgs e)
        {
            //this.vm.SaveSettings();
            //MainWindow win = (MainWindow)Application.Current.MainWindow;
            //win.Show();
            //this.Close();
        }

        private void Back_To_Main_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

    }
}