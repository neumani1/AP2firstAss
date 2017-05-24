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
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Interaction logic for MultiPlayerWindow.xaml
    /// </summary>
    public partial class MultiPlayerWindow : Window
    {
        private MultiPlayerWindowViewModel vm;

        private IMultiPlayerModel model;

        public MultiPlayerWindow(IMultiPlayerModel model)
        {

            this.model = model;
            this.InitializeComponent();
            this.vm = new MultiPlayerWindowViewModel(model);
            this.DataContext = this.vm;
            this.vm.ClosingHappend += this.CloseGame;
        }

        private void CloseGame(string reason)
        {
            if (reason.Equals("lose"))
            {
                this.Dispatcher.BeginInvoke((Action)(() => {
                        LoseWindow win = new LoseWindow();
                        win.Show();
                        this.Close();
                    }));
            }
            else if (reason.Equals("technicalWin"))
            {
                this.Dispatcher.BeginInvoke((Action)(() => {
                    TechnicalWinWindow win = new TechnicalWinWindow();
                win.Show();
                this.Close();
                }));
            }
            else
            {
                //hellooooo
            }
        }

        //public string CloseReason
        //{
        //    get
        //    {
        //        return (string)GetValue(CloseReasonProperty);
        //    }

        //    set
        //    {
        //        SetValue(CloseReasonProperty, value);
        //    }
        //}

        //public static readonly DependencyProperty CloseReasonProperty =
        //    DependencyProperty.Register("CloseReason", typeof(string), typeof(MultiPlayerWindow), null);

        private void Back_To_Main_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        public void winScreen()
        {
            WinWindow win = new WinWindow();
            win.Show();
            this.Close();
        }

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            int result;
            switch (e.Key)
            {

                case Key.Left:
                    {
                        result = this.vm.KeyPressed('l');
                        if (result == 1)
                        {
                            winScreen();
                        }
                        break;
                    }
                case Key.Right:
                    {
                        result = this.vm.KeyPressed('r');
                        if (result == 1)
                        {
                            winScreen();
                        }
                        break;
                    }
                case Key.Up:
                    {
                        result = this.vm.KeyPressed('u');
                        if (result == 1)
                        {
                            winScreen();
                        }
                        break;
                    }
                case Key.Down:
                    {
                        result = this.vm.KeyPressed('d');
                        if (result == 1)
                        {
                            winScreen();
                        }
                        break;
                    }

            }

        }

        private void MazeBoard_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MultiPlayerWindow_OnClosed(object sender, EventArgs e)
        {
            this.vm.CloseGame();
        }
    }
}
