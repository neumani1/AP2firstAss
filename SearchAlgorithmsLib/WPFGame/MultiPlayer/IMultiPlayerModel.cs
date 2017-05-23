﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    using System.ComponentModel;
    using System.Windows;

    public interface IMultiPlayerModel : INotifyPropertyChanged
    {
        string MazeName { get; set; }

        int MazeRows { get; set; }

        int MazeCols { get; set; }

        string StringMaze { get; set; }

        Point CurrPoint { get; set; }

        Point EndPoint { get; }

        string Solution { get; set; }

        int KeyPressed(char direction);

        void StartGame();
    }
}