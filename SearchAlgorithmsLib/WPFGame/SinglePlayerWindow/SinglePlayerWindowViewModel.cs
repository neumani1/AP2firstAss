﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGame
{
    public class SinglePlayerWindowViewModel : ViewModel
    {
        private ISinglePlayerWindowModel model;

        public SinglePlayerWindowViewModel(ISinglePlayerWindowModel model)
        {
            this.model = model;
        }

        //public int MazeRows
        //{
        //    get
        //    {
        //        return this.model.MazeRows;
        //    }

        //    set
        //    {
        //        this.model.MazeRows = value;
        //        this.NotifyPropertyChanged("MazeRows");
        //    }
        //}

        //public int MazeCols
        //{
        //    get
        //    {
        //        return this.model.MazeCols;
        //    }

        //    set
        //    {
        //        this.model.MazeCols = value;
        //        this.NotifyPropertyChanged("MazeCols");
        //    }
        //}

        public void SaveSettings()
        {
          //  this.model.SaveSettings();
        }


    }
}